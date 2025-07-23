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
    public class NivelRepositorioImpl : RepositorioImpl<tri_nivel>, INivelRepositorio
    {
        private readonly tributrekContext _tributrekContext;
        public NivelRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            this._tributrekContext = dBContext;
        }

        public async Task<List<NivelListarDTO>> listarNivel()
        {
            try
            {

                {
                    var result = await(
                        from niv in _tributrekContext.tri_nivel
                        select new NivelListarDTO
                        {
                               tri_niv_descripcion = niv.tri_niv_descripcion,
                               tri_niv_dificultad = niv.tri_niv_dificultad,
                               tri_niv_id = niv.tri_niv_id,
                               tri_niv_estado = niv.tri_niv_estado,
                               

                        }

                    ).ToListAsync();

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar nivel" + ex.Message);
            }
        }

        public async Task<List<NivelDTO>> listarNiveles()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = await(from niv in _tributrekContext.tri_nivel
                                      select new NivelDTO
                                      {
                                          nombreNivel = niv.tri_niv_descripcion,
                                          idNivel = niv.tri_niv_id
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
