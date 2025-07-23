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
    public class CategoriaServicioImpl : ICategoriaServicio
    {
        private ICategoriaRepositorio categoriaRepositorio;
        private readonly tributrekContext _context;


        public CategoriaServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;
            categoriaRepositorio = new CategoriaRepositorioImpl(_context);
        }

        public async Task CategoriaAddAsync(tri_categoria TEntity)
        {
            await categoriaRepositorio.AddAsync(TEntity);
        }

        public async Task CategoriaDeleteAsync(int id)
        {
            await categoriaRepositorio.DeleteAsync(id);
        }

        public Task<IEnumerable<tri_categoria>> CategoriaGetAllAsync()
        {
            return categoriaRepositorio.GetAllAsync();
        }

        public Task<tri_categoria> CategoriaGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CategoriaUpdateAsync(tri_categoria Entity)
        {
            await categoriaRepositorio.UpdateAsync(Entity);
        }

        public async Task<List<CategoriaDTO>> ListarCategorias()
        {
            return await categoriaRepositorio.ListarCategorias();
        }

    }
}
