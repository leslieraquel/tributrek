using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tributrek.Aplicacion.DTO.DTOs
{
    public class UsuariosDTO
    {
        public int tri_usu_id { get; set; }

        public string tri_usu_nombres { get; set; }

        public string tri_usu_apellido { get; set; }

        public string tri_usu_correo { get; set; }

        public string tri_usu_estado { get; set; }

        public string tri_usu_nombre_usuario { get; set; }

        public string tri_usu_clave { get; set; }

        public int? tri_usu_rol_id { get; set; }

        public string tri_rol_nombre { get; set; }
    }
}
