using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class NivelListarDTO
    {
        public int tri_niv_id { get; set; }

        public string tri_niv_dificultad { get; set; }

        public string tri_niv_estado { get; set; }

        public string tri_niv_descripcion { get; set; }
    }
}
