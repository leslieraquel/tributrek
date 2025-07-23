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
    public class ItinerarioRepositorioImpl : RepositorioImpl<tri_itinerario>, IItenarioRepositorio
    {
        private readonly tributrekContext _tributrekContext;
        public ItinerarioRepositorioImpl(tributrekContext dbContext) : base(dbContext)
        {
            this._tributrekContext = dbContext;
        }
        
        public async Task ActualizarItinerarioAsync(tri_itinerario idItinerario)
        {
            try
            {
                _tributrekContext.tri_itinerario.Update(idItinerario); // Agrega el objeto al contexto
                await _tributrekContext.SaveChangesAsync();       // Guarda los cambios en la BD
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el itinerario: " + ex.Message);
            }
        }

        public async Task AgregarItinerarioAsync(tri_itinerario itinerario)
        {
            try
            {
                _tributrekContext.tri_itinerario.Add(itinerario); // Agrega el objeto al contexto
                await _tributrekContext.SaveChangesAsync();       // Guarda los cambios en la BD
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el itinerario: " + ex.Message);
            }
        }

        public async Task EliminarItinerarioAsync(int idItinerario)
        {
            try
            {
                var itinerario = await _tributrekContext.tri_itinerario.FindAsync(idItinerario);
                if (itinerario != null)
                {
                    _tributrekContext.tri_itinerario.Remove(itinerario);
                    await _tributrekContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el itinerario: " + ex.Message);
            }
        }

        public async  Task<List<ItinerarioDTO>> ListarItinerario()
        {
            try
            {

                {
                    var result = await (
                        from iti in _tributrekContext.tri_itinerario
                        join cat in _tributrekContext.tri_categoria
                            on iti.tri_itine_cat_id equals cat.tri_cat_id
                        join niv in _tributrekContext.tri_nivel
                            on iti.tri_itine_niv_id equals niv.tri_niv_id
                        select new ItinerarioDTO
                        {
                            idItinerario = iti.tri_itine_id,
                            NombreItinerario = iti.tri_itine_nombre,
                            EstadoItinerario = iti.tri_itine_estado,
                            nombreCategoria = cat.tri_cat_nombre,
                            descripcionNivel = niv.tri_niv_descripcion,
                            idCategoria = cat.tri_cat_id,
                            idNivel = niv.tri_niv_id
                        }
                        
                    ).ToListAsync();

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar itinerario" + ex.Message);
            }

        }

        public IEnumerable<tri_itinerario> listarItinerarioPorNombre(string nombre_itinerario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItinerariosPorNivelCategoriaDTO>> ListarPorNivel()
        {

            try
            {

                {
                    var result = await (from iti in _tributrekContext.tri_itinerario
                                        join cat in _tributrekContext.tri_categoria
                                        on iti.tri_itine_cat_id equals cat.tri_cat_id
                                        join niv in _tributrekContext.tri_nivel
                                       on iti.tri_itine_niv_id equals niv.tri_niv_id
                                        group iti by new
                                        {
                                            iti.tri_itine_nombre,
                                            iti.tri_itine_estado,
                                            cat.tri_cat_nombre,
                                            niv.tri_niv_dificultad,
                                            iti.tri_itine_id
                                        } into grupo
                                        select new ItinerariosPorNivelCategoriaDTO
                                        {
                                            nombreItinerario = grupo.Key.tri_itine_nombre,
                                            nombreCategoria = grupo.Key.tri_cat_nombre,

                                        }).ToListAsync();
                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar producto por tipo" + ex.Message);
            }
        }

        public async Task<List<UsuarioItinerarioPaqueteDTO>> ListarUsuarioItinerarioPaquete()
        {
            try
            {
                var resultado = await (from iti in _tributrekContext.tri_itinerario
                                       join usu in _tributrekContext.tri_usuario on iti.tri_itine_usu_id equals usu.tri_usu_id
                                       join paq in _tributrekContext.tri_paquete_itinerario on iti.tri_itine_id equals paq.tri_paq_idtri_itine
                                       select new UsuarioItinerarioPaqueteDTO
                                       {

                                           NombreItinerario = iti.tri_itine_nombre,
                                           NombrePaquete = paq.tri_paq_iti_descripcion,
                                           NombreUsuario = usu.tri_usu_nombre_usuario
                                       }).ToListAsync();



                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar producto por tipo" + ex.Message);

            }
        }
    }
}
