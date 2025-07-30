using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{

    public class PaqueteConDiasDetDTO
    {
        public int? IdPaquete { get; set; }
        public string NombrePaquete { get; set; }
        public int CantidadDiasPaquete { get; set; }
        public string NombreNivel { get; set; }

        public List<DiaDTO> DetallesPaq { get; set; } = new();
    }

    public class ActividadDTO
    {
        public int? IdActividad { get; set; }
        public string InicioActividad { get; set; }
        public string FinActividad { get; set; }
    }

    public class DiaDTO
    {
        public int? NumeroDia { get; set; }
        public int IdPaquete { get; set; }
        public List<ActividadDTO> Actividades { get; set; } = new();
    }





}
