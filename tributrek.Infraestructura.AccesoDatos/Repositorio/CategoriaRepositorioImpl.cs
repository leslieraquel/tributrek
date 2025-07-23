using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class CategoriaRepositorioImpl : RepositorioImpl<tri_categoria>, ICategoriaRepositorio
    {
        private readonly tributrekContext _tributrekContext;
        public CategoriaRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            this._tributrekContext = dBContext;
        }

        public async Task AgregarCategoriaAsync(tri_categoria categoria)
        {
            try
            {
                _tributrekContext.tri_categoria.Add(categoria);
                await _tributrekContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la categoría: " + ex.Message);
            }
        }

        public async Task ActualizarCategoriaAsync(tri_categoria categoria)
        {
            try
            {
                _tributrekContext.tri_categoria.Update(categoria);
                await _tributrekContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la categoría: " + ex.Message);
            }
        }

        public async Task EliminarCategoriaAsync(int idCategoria)
        {
            try
            {
                var categoria = await _tributrekContext.tri_categoria.FindAsync(idCategoria);
                if (categoria != null)
                {
                    _tributrekContext.tri_categoria.Remove(categoria);
                    await _tributrekContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría: " + ex.Message);
            }
        }

        public async  Task<List<CategoriaDTO>> ListarCategorias()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = await (from cat in _tributrekContext.tri_categoria
                                       select new CategoriaDTO
                                       {
                                           tri_id_cat = cat.tri_cat_id,
                                           tri_cat_nombre = cat.tri_cat_nombre
                                       }).ToListAsync();

                return resultado;

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }

    }
}
