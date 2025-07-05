using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class RepositorioImpl<T> : IRepositorio<T> where T : class
    {
        private readonly tributrekContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public async Task AddAsync(T TEntity)
        {
            try
            {
                await _dbSet.AddAsync(TEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo insertar" + e.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByAsync(id);
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo eliminar los datos" + e.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo listar los datos" + e.Message);
            }
        }

        public async Task<T> GetByAsync(int id)
        {
            try
            {
                var entity = GetByAsync(id);
                return await _dbSet.FindAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se encontro nigun registro" + e.Message);
            }
        }

        public async Task UpdateAsync(T TEntity)
        {
            try
            {
                _dbSet.Update(TEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo eliminar los datos" + e.Message);
            }
        }
    }

   
}
