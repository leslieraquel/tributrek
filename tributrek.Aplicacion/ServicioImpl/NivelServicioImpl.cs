using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Aplicacion.ServicioImpl
{
    public class NivelServicioImpl : INivelRepositorio
    {
        public Task AddAsync(tri_nivel TEntity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tri_nivel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<tri_nivel> GetByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<tri_nivel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(tri_nivel TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
