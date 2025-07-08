using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<List<ItinerariosPorNivelCategoriaDTO>> ListarItinerariosPorNivel()
        {
            try
            {
                var result = await (from iti in _tributrekContext.tri_itinerario
                                    join cat in _tributrekContext.tri_categoria
                                    on iti.tri_itine_id equals cat.tri_cat_id
                                    join niv in _tributrekContext.tri_nivel
                                   on iti.tri_itine_id equals niv.tri_niv_id
                                   group iti by new { iti.tri_itine_nombre, iti.tri_itine_estado, cat.tri_cat_nombre , niv.tri_niv_descripcion,iti.tri_itine_id } into grupo
                                   select new ItinerariosPorNivelCategoriaDTO
                                   {
                                       idTipo = grupo.Key.tri_cat_nombre,
                                       Rp = grupo.Key.tri_itine_id,
                                       dta = grupo.Select(tmp => tmp.tri_itine_nombre).ToList(),

                                   }).ToListAsync();
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar producto por tipo" + ex.Message);

            }
        }
    }
}
