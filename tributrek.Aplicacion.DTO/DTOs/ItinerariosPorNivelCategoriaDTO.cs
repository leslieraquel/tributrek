using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class ItinerariosPorNivelCategoriaDTO
    {
        public string nombreItinerario { get; set; } //recuperar nombre del tipo producto

        public string nombreCategoria { get; set; }
        public string nivel { get; set; }//listar todo los productos de acuerdo al tipo
    }
}
