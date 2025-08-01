using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Aplicacion.Servicio;
using tributrek.Dominio.Modelo.Abstracciones;
using tributrek.Infraestructura.AccesoDatos;
using tributrek.Infraestructura.AccesoDatos.Repositorio;

namespace tributrek.Aplicacion.ServicioImpl
{
    public class PaqueteItinerarioServicioImpl : IPaqueteItinerarioServicio
    {
        private IPaqueteItinerarioRepositorio paqueteitenerarioRepositorio;
        private readonly tributrekContext _context;

        public PaqueteItinerarioServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;
            paqueteitenerarioRepositorio = new PaqueteItinerarioRepositorioImpl(_context);

        }
        public async Task<List<PaqueteDTO>> listarPaqueteItinerario()
        {
            return await paqueteitenerarioRepositorio.listarPaqueteItinerario();
        }
        public async Task PaqueteAddAsync(PaqueteItinerarioDTO dto)
        {
            var entidad = new tri_paquete_itinerario
            {
                tri_paq_iti_cantidad_dias = dto.CantidadDiasPaquete,
                tri_paq_iti_descripcion = dto.DescripcionPaquete,
                tri_paq_idtri_itine = dto.IdItinerario,
                //tri_paq_fecha_inicio = dto.FechaInicio.ToDateTime(new TimeOnly(0, 0)),
                //tri_paq_fecha_fin = dto.FechaFin.ToDateTime(new TimeOnly(0, 0)),
                tri_paq_nombre = dto.DescripcionPaquete,
                tri_dias_itinerario = dto.DetallesPaq.Select(d => new tri_dias_itinerario
                {
                     tri_dia_numero = d.Dianumero,
                    // idpaquete se ignora, EF lo gestiona
                        tri_actividades_dias = d.Actividades.Select(a => new tri_actividades_dias
                        {
                            tri_acti_orden = a.orden,
                            tri_acti_hora_inicio=a.HoraInicio,
                            tri_acti_hora_fin=a.HoraFin,
                            tri_acti_id=a.idActividad

                    }).ToList()
                }).ToList()
            };

            await paqueteitenerarioRepositorio.AgregarPaqueteItinerarioAsync(entidad);
        }

        public async Task PaqueteUpdateAsync(tri_paquete_itinerario Entity)
        {
            await paqueteitenerarioRepositorio.UpdateAsync(Entity);
        }

        public async Task PaqueteDeleteAsync(int id)
        {
            await paqueteitenerarioRepositorio.DeleteAsync(id);
        }

        public Task<IEnumerable<tri_paquete_itinerario>> PaqueteGetAllAsync()
        {
            return paqueteitenerarioRepositorio.GetAllAsync();
        }

        public Task<tri_paquete_itinerario> PaqueteGetByIdAsync(int id)
        {
            return paqueteitenerarioRepositorio.GetByIdAsync(id);
        }

        public Task<List<PaqueteItinerarioCategoriaDTO>> ListarPaqueteItinerarioCategoria()
        {
            throw new NotImplementedException();
        }

        public Task<tri_paquete_itinerario> PaqueteGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaqueteConDiasDetDTO> ObtenerPaqueteConActividades(int idPaquete)
        {
           var query = (
                from tpi in _context.tri_paquete_itinerario
                join tdi in _context.tri_dias_itinerario on tpi.idtri_paq_iti equals tdi.tri_idtri_paq_iti
                join tad in _context.tri_actividades_dias on tdi.tri_dia_itine equals tad.tri_dia_itine
                where tpi.idtri_paq_iti == idPaquete
                select new
                {
                    IdPaquete = tpi.idtri_paq_iti,
                    idItinerario = tpi.tri_paq_idtri_itine,
                    NombrePaquete = tpi.tri_paq_iti_descripcion,
                    CantidadDias = tpi.tri_paq_iti_cantidad_dias,
                    NumeroDia = tdi.tri_dia_numero,
                    IdActividad = tad.tri_acti_id,
                    HoraInicio = tad.tri_acti_hora_inicio,
                    HoraFin = tad.tri_acti_hora_fin
                }
            ).ToList();

            if (!query.Any())
                return null;

            var first = query.First();

            var paqueteDto = new PaqueteConDiasDetDTO
            {
                IdPaquete = first.IdPaquete,
                idItinerario= first.idItinerario,
                descripcionPaquete = first.NombrePaquete,
                CantidadDiasPaquete = first.CantidadDias ?? 0,
                DetallesPaq = query
                    .GroupBy(x => x.NumeroDia)
                    .Select(g => new DiaDTO
                    {
                        NumeroDia = g.Key,
                        IdPaquete = first.IdPaquete,
                        Actividades = g.Select(a => new ActividadDTO
                        {
                            IdActividad = a.IdActividad,
                             horaInicio = a.HoraInicio.HasValue ? a.HoraInicio.Value.ToString("HH:mm") : null,
                            horaFin = a.HoraFin.HasValue ? a.HoraFin.Value.ToString("HH:mm") : null
                        }).ToList()
                    }).ToList()
            };

            return paqueteDto;
        }
        public async Task EditarPaqueteAsync(PaqueteConDiasDetDTO dto)
        {
            var paquete = await _context.tri_paquete_itinerario
                .FirstOrDefaultAsync(p => p.idtri_paq_iti == dto.IdPaquete);

            if (paquete == null)
                throw new Exception("Paquete no encontrado");

            // Actualizar datos base
            paquete.tri_paq_iti_descripcion = dto.descripcionPaquete;
            paquete.tri_paq_iti_cantidad_dias = dto.CantidadDiasPaquete;

            // Obtener días actuales del paquete
            var dias = await _context.tri_dias_itinerario
                .Where(d => d.tri_idtri_paq_iti == dto.IdPaquete)
                .ToListAsync();

            // Obtener IDs de los días
            var idsDias = dias.Select(d => d.tri_dia_itine).ToList();

            // Obtener actividades relacionadas
            var actividades = await _context.tri_actividades_dias
                .Where(a => a.tri_dia_itine != null && idsDias.Contains(a.tri_dia_itine.Value))
                .ToListAsync();

            // Eliminar registros antiguos
            _context.tri_actividades_dias.RemoveRange(actividades);
            _context.tri_dias_itinerario.RemoveRange(dias);

            // Insertar nuevos días y actividades
            foreach (var diaDto in dto.DetallesPaq)
            {
                var nuevoDia = new tri_dias_itinerario
                {
                    tri_idtri_paq_iti = dto.IdPaquete,
                    tri_dia_numero = diaDto.NumeroDia,
                    tri_actividades_dias = diaDto.Actividades.Select(a => new tri_actividades_dias
                    {
                        tri_acti_id = a.IdActividad,
                        tri_acti_hora_inicio = !string.IsNullOrEmpty(a.horaInicio) ? TimeOnly.Parse(a.horaInicio) : null,
                        tri_acti_hora_fin = !string.IsNullOrEmpty(a.horaFin) ? TimeOnly.Parse(a.horaFin) : null
                    }).ToList()
                };

                _context.tri_dias_itinerario.Add(nuevoDia);
            }

            // Guardar cambios
            await _context.SaveChangesAsync();
        }

    }


}
