using System;
using System.Collections.Generic;
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

        public async  Task<PaqueteConDiasDetDTO> ObtenerPaqueteConActividades(int idPaquete)
        {
            var query = await(
        from tpi in _context.tri_paquete_itinerario
        join tdi in _context.tri_dias_itinerario on tpi.tri_paq_idtri_itine equals tdi.tri_idtri_paq_iti
        join tad in _context.tri_actividades_dias on tdi.tri_dia_itine equals tad.tri_dia_itine
        join ta in _context.tri_actividades on tad.tri_acti_id equals ta.tri_acti_id
        join ti in _context.tri_itinerario on tpi.tri_paq_idtri_itine equals ti.tri_itine_id
        join tn in _context.tri_nivel on ti.tri_itine_niv_id equals tn.tri_niv_id
        where tpi.idtri_paq_iti == idPaquete
        select new
        {
            tpi.idtri_paq_iti,
            tpi.tri_paq_iti_descripcion,
            tpi.tri_paq_iti_cantidad_dias,
            tn.tri_niv_descripcion,
            tdi.tri_dia_numero,
            tad.tri_acti_id,
            tad.tri_acti_hora_inicio,
            tad.tri_acti_hora_fin
        }
    ).ToListAsync();

            if (!query.Any())
                return null;

            var paqueteDto = new PaqueteConDiasDetDTO
            {
                IdPaquete = query.First().idtri_paq_iti,
                NombrePaquete = query.First().tri_paq_iti_descripcion,
                CantidadDiasPaquete = query.First().tri_paq_iti_cantidad_dias ?? 0,
                NombreNivel = query.First().tri_niv_descripcion,
            };

            var diasAgrupados = query
                .GroupBy(x => x.tri_dia_numero)
                .Select(g => new DiaDTO
                {
                    NumeroDia = g.Key,
                    IdPaquete = query.First().idtri_paq_iti,
                    Actividades = g.Select(a => new ActividadDTO
                    {
                        IdActividad = a.tri_acti_id,
                        InicioActividad = a.tri_acti_hora_inicio.ToString(),
                        FinActividad = a.tri_acti_hora_fin.ToString()
                    }).ToList()
                }).ToList();

            paqueteDto.DetallesPaq = diasAgrupados;

            return paqueteDto;
        }
    }
}
