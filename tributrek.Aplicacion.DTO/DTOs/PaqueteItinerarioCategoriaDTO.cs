using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class PaqueteItinerarioCategoriaDTO
    {
        public string NombrePaquete { get; set; }
        public string NombreCategoria { get; set; }
        public List<string> Itinerario { get; set; }
    }
}
