using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IUsuarioRepositorio : IRepositorio<tri_usuario>
    {
        IEnumerable<tri_rol> buscarRolNombre(String nombre);

        Task<List<UsuarioDTO>> ListarUsuarioPorRol(); 

        Task<List<UsuarioRolItinerarioDTO>> ListarUsuarioRolItinerario(); 

    }
}
