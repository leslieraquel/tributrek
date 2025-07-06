using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class CategoriaRepositorioImpl : RepositorioImpl<tri_categoria>, ICategoriaRepositorio
    {
        private const char V = '1';
        private readonly tributrekContext _tributrekDBContext;

        public CategoriaRepositorioImpl(tributrekContext dbContext) : base(dbContext)
        {

            _tributrekDBContext = dbContext;
        }

        public Task<List<tri_categoria>> listarCategorias()
        {
            try
            {
                //select* from tipo_producto where estado_registro = 1
                var categorias = from cat in _tributrekDBContext.tri_categoria
                                 select cat;
                return categorias.ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }
    }
}
