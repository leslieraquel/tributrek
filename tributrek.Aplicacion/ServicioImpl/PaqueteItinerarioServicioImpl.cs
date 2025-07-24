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
        public async Task PaqueteAddAsync(tri_paquete_itinerario TEntity)
        {
            await paqueteitenerarioRepositorio.AddAsync(TEntity);
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
