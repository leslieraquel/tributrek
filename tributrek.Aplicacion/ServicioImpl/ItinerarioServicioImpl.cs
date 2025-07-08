using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Dominio.Modelo.Abstracciones;
using tributrek.Infraestructura.AccesoDatos;
using tributrek.Infraestructura.AccesoDatos.Repositorio;

namespace tributrek.Aplicacion.ServicioImpl
{
    public class ItinerarioServicioImpl : IItenarioRepositorio
    {
        private IItenarioRepositorio itinerarioRepositorio;

        public ItinerarioServicioImpl(tributrekContext tributrekContext)
        {
            this.itinerarioRepositorio = new ItinerarioRepositorioImpl(tributrekContext);
        }
        public Task AddAsync(tri_itinerario TEntity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tri_itinerario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<tri_itinerario> GetByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<tri_itinerario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItinerariosPorNivelCategoriaDTO>> ListarItinerariosPorNivel()
        {
            return itinerarioRepositorio.ListarItinerariosPorNivel();
        }

        public Task UpdateAsync(tri_itinerario TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
