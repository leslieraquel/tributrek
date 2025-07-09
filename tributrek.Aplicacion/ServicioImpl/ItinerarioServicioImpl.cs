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
    public class ItinerarioServicioImpl: IItinerarioServicio
    {
        private readonly IItenarioRepositorio _iitenerarioRepositorio;

        public ItinerarioServicioImpl(tributrekContext tributrekContext)
        {
            this._iitenerarioRepositorio = new ItinerarioRepositorioImpl(tributrekContext);
        }

        public Task ItinerarioAddAsync(tri_itinerario TEntity)
        {
            throw new NotImplementedException();
        }

        public Task ItinerarioDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tri_itinerario>> ItinerarioGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<tri_itinerario> ItinerarioGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public Task ItinerarioUpdateAsync(tri_itinerario Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItinerariosPorNivelCategoriaDTO>> ListarPorNivel()
        {
           return await _iitenerarioRepositorio.ListarPorNivel();
        }

        public Task<List<UsuarioItinerarioPaqueteDTO>> ListarUsuarioItinerarioPaquete()
        {
            return _iitenerarioRepositorio.ListarUsuarioItinerarioPaquete();
        }
    }
}
