using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Dominio.Modelo.Abstracciones;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class PaqueteItinerarioRepositorioImpl : RepositorioImpl<tri_paquete_itinerario>, IPaqueteItinerarioRepositorio
    {

        private readonly tributrekContext _tributrekdbContext;
        public PaqueteItinerarioRepositorioImpl(tributrekContext dbContext) : base(dbContext)
        {
            this._tributrekdbContext = dbContext;
        }

        public async Task AgregarPaqueteItinerarioAsync(tri_paquete_itinerario paqueteItinerario)
        {
            try
            {
                // Insertar el paquete con sus días itinerario (en cascada)
                _tributrekdbContext.tri_paquete_itinerario.Add(paqueteItinerario);
                await _tributrekdbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar paquete itinerario: " + ex.Message);
            }
        }


        public async Task<List<PaqueteDTO>> listarPaqueteItinerario()
        {
            try
            {

                {
                    var result = await (from iti in _tributrekdbContext.tri_itinerario
                                        join paq in _tributrekdbContext.tri_paquete_itinerario
                                        on iti.tri_itine_id equals paq.tri_paq_idtri_itine
                                        select new PaqueteDTO
                                        {
                                            tri_itine_nombre = iti.tri_itine_nombre,
                                            tri_paq_idtri_itine = paq.tri_paq_idtri_itine,
                                            tri_paq_iti_cantidad_dias = paq.tri_paq_iti_cantidad_dias,
                                            tri_paq_iti_descripcion = paq.tri_paq_iti_descripcion,
                                            tri_paq_nombre = paq.tri_paq_nombre,
                                            idtri_paq_iti = paq.idtri_paq_iti

                                        }).ToListAsync();

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar" + ex.Message);
            }
        }
        

        public async Task<List<PaqueteItinerarioCategoriaDTO>> ListarPaqueteItinerarioCategoria()
        {
            try
            {

                {
                    var result = await(from iti in _tributrekdbContext.tri_itinerario
                                       join paq in _tributrekdbContext.tri_paquete_itinerario
                                       on iti.tri_itine_id equals paq.tri_paq_idtri_itine
                                       join cat in _tributrekdbContext.tri_categoria
                                      on iti.tri_itine_cat_id equals cat.tri_cat_id
                                       select new PaqueteItinerarioCategoriaDTO{
                                          NombrePaquete = paq.tri_paq_iti_descripcion,
                                          NombreCategoria = cat.tri_cat_nombre
                                           }).ToListAsync();

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar" + ex.Message);
            }
        }

        public Task<List<tri_paquete_itinerario>> ListarPaquetes()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = from paq in _tributrekdbContext.tri_paquete_itinerario
                                select paq;
                return resultado.ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }

    }
}
