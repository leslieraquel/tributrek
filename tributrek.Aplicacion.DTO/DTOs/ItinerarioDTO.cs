using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class ItinerarioDTO
    {
        public int idItinerario { get; set; }
        public string NombreItinerario { get; set; }

        public string EstadoItinerario { get; set; }

        public int idCategoria { get; set; }


        public string nombreCategoria { get; set; }

        public int idNivel { get; set; }

        public string descripcionNivel { get; set; }

    }
}
