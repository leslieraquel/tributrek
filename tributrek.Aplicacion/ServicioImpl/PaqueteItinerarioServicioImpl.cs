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
        private readonly IPaqueteItinerarioRepositorio _ipaqueteitenerarioRepositorio;
        private readonly tributrekContext _context;


        public PaqueteItinerarioServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;
            _ipaqueteitenerarioRepositorio = new PaqueteItinerarioRepositorioImpl(_context);

        }

        public Task<List<PaqueteItinerarioCategoriaDTO>> ListarPaqueteItinerarioCategoria()
        {
            return this._ipaqueteitenerarioRepositorio.ListarPaqueteItinerarioCategoria();
        }

        public Task PaqueteAddAsync(tri_paquete_itinerario TEntity)
        {
            throw new NotImplementedException();
        }

        public Task PaqueteDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<tri_paquete_itinerario>> PaqueteGetAllAsync()
        {
            return await this._ipaqueteitenerarioRepositorio.ListarPaquetes();
        }

        public Task<tri_paquete_itinerario> PaqueteGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public Task PaqueteUpdateAsync(tri_paquete_itinerario Entity)
        {
            throw new NotImplementedException();
        }
    }
}
