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
        private readonly tributrekContext _tributrekdbContext;
        public CategoriaRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            _tributrekdbContext = dBContext;
        }

        public Task<List<tri_categoria>> ListarCategorias()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = from cat in _tributrekdbContext.tri_categoria
                                where cat.tri_cat_estado.Equals(1)
                                select cat;
                return resultado.ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }
    }
}
