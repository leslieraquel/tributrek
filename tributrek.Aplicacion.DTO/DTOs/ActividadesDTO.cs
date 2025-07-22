using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class ActividadesDTO
    {
        public string tri_itine_nombre { get; set; }
        public string tri_cat_nombre { get; set; }
        public string tri_niv_dificultad { get; set; }

        public int idActividad { get; set; }
        public string nombreActividad { get; set; }
        public string estadoActividad { get; set; }


    }
}
