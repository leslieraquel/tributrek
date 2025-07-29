using System;
using System.Collections.Generic;
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
                tri_paq_fecha_inicio = dto.FechaInicio.ToDateTime(new TimeOnly(0, 0)),
                tri_paq_fecha_fin = dto.FechaFin.ToDateTime(new TimeOnly(0, 0)),
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
    }
}
