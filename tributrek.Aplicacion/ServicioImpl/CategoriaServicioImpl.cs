using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.Servicio;
using tributrek.Dominio.Modelo.Abstracciones;
using tributrek.Infraestructura.AccesoDatos;
using tributrek.Infraestructura.AccesoDatos.Repositorio;

namespace tributrek.Aplicacion.ServicioImpl
{
    public class CategoriaServicioImpl : ICategoriaServicio
    {
        private ICategoriaRepositorio categoriaRepositorio;

        public CategoriaServicioImpl(tributrekContext tributrekContext)
        {
            this.categoriaRepositorio = new CategoriaRepositorioImpl(tributrekContext);
        }
        public async Task actualizarCategoria(tri_categoria Entity)
        {
            await categoriaRepositorio.UpdateAsync(Entity);
        }

        public async Task agregarCategoria(tri_categoria TEntity)
        {
            await categoriaRepositorio.AddAsync(TEntity);
        }

        public async Task eliminarCategoria(int tri_cat_id)
        {
            await categoriaRepositorio.DeleteAsync(tri_cat_id);
        }

        public async Task<IEnumerable<tri_categoria>> listarCategorias()
        {
            return await categoriaRepositorio.GetAllAsync();
        }
    }
}
