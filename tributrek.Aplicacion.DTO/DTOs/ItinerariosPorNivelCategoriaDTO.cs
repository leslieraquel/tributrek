using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class ItinerariosPorNivelCategoriaDTO
    {
        public int Rp { get; set; } //recuperar nombre del tipo producto

        public string idTipo { get; set; }
        public List<string> dta { get; set; }//listar todo los productos de acuerdo al tipo
    }
}
