using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Aplicacion.ServicioImpl
{
    public class ItinerarioServicioImpl : IItenarioRepositorio
    {
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

        public Task UpdateAsync(tri_itinerario TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
