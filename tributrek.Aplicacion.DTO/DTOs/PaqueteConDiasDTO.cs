using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class PaqueteConDiasDTO
    {

        public string Descripcion { get; set; }
        public int CantidadDias { get; set; }
        public int IdItinerario { get; set; }
        public List<DetalleDiaDTO> Detalles { get; set; }
        public int IdPaquete { get; set; }
        public string NombrePaquete { get; set; }
        public int CantidadDiasPaquete { get; set; }
    }
}
