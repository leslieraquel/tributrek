using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class PaqueteDTO
    {
        public int idtri_paq_iti { get; set; }

        public int? tri_paq_iti_cantidad_dias { get; set; }

        public string tri_paq_iti_descripcion { get; set; }
        public string tri_paq_nombre { get; set; }

        public int? tri_paq_idtri_itine { get; set; }

        public string tri_itine_nombre { get; set; }

    }
}
