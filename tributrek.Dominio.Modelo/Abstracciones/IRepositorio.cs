using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IRepositorio<T> where T : class
    {

        Task AddAsync(T TEntity); /// para insertar
        Task UpdateAsync(T TEntity); /// actualizar

        Task DeleteAsync(int id); /// delete 

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByAsync(int id);

        Task<T> GetByIdAsync(int id);//buscar por ID

    }

}
