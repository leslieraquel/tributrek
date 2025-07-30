using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class PaqueteItinerarioDTO
    {
        public int CantidadDiasPaquete { get; set; }
        public string DescripcionPaquete { get; set; }
        public int IdItinerario { get; set; }
        //public DateOnly FechaInicio { get; set; }
        //public DateOnly FechaFin { get; set; }
        public List<PaqueteDias> DetallesPaq { get; set; } = new List<PaqueteDias>();
    }

    public class PaqueteDias
    {
        public int Dianumero { get; set; }
        public int IdPaquete { get; set; }

        public List<ActividadDiaDTO> Actividades { get; set; } = new List<ActividadDiaDTO>();
    }
    public class ActividadDiaDTO
    {
        public int orden { get; set; }
        public int idPaqueteItinerario { get; set; }
        public int idActividad { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }


    }
}
