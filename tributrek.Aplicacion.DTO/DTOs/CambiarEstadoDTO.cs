using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class CambiarEstadoDTO
    {
        public int Id { get; set; }
        public bool Estado { get; set; }  // string porque eso llega desde Angular
    }
}
