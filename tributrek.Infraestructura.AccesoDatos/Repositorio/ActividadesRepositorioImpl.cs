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
    public class ActividadesRepositorioImpl : RepositorioImpl<tri_actividades>, IActividadesRepositorio
    {
        private readonly tributrekContext _tributrekdbContext;

        public ActividadesRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            _tributrekdbContext = dBContext;
        }

        public IEnumerable<tri_actividades> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActividadesDTO>> ListarProductoPorTipo()
        {
            var resultado = await(from act in _tributrekdbContext.tri_actividades
                                  join actDia in _tributrekdbContext.tri_actividades_dias on act.tri_acti_id equals actDia.tri_acti_id
                                  join dia in _tributrekdbContext.tri_dias_itinerario on actDia.tri_dia_itine equals dia.tri_dia_itine
                                  join paquete in _tributrekdbContext.tri_paquete_itinerario on dia.tri_idtri_paq_iti equals paquete.idtri_paq_iti
                                  join iti in _tributrekdbContext.tri_itinerario on paquete.tri_paq_idtri_itine equals iti.tri_itine_id
                                  join cat in _tributrekdbContext.tri_categoria on iti.tri_itine_cat_id equals cat.tri_cat_id
                                  join niv in _tributrekdbContext.tri_nivel on iti.tri_itine_niv_id equals niv.tri_niv_id
                                  select new ActividadesDTO
                                  {
                                      tri_itine_nombre = act.tri_acti_descripcion,
                                      tri_cat_nombre = cat.tri_cat_nombre,
                                      tri_niv_dificultad = niv.tri_niv_dificultad
                                  }).ToListAsync();

            return resultado;
        }
    }
}
