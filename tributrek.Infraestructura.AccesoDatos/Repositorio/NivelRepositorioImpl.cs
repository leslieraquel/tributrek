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
