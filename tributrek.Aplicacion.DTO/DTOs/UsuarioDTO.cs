using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
   public class UsuarioDTO
   {

        public string NombreRol { get; set; } 

        public int idRol { get; set; }
        public List<string> NombresUsuarios { get; set; }
    }
}
