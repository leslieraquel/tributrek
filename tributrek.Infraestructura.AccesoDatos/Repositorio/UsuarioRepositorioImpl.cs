using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class UsuarioRepositorioImpl : RepositorioImpl<tri_usuario>, IUsuarioRepositorio
    {
        private readonly tributrekContext _tributrekDBContext;

        public UsuarioRepositorioImpl(tributrekContext dBContext) : base(dBContext) 
        { 
        
           this._tributrekDBContext = dBContext;

        }

        public IEnumerable<tri_rol> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioDTO>> ListarUsuarioPorRol()
        {
            try
            {
                var resultado = await(from usu in _tributrekDBContext.tri_usuario
                                      join rol in _tributrekDBContext.tri_rol
                                      on usu.tri_usu_rol_id equals rol.tri_rol_id
                                      group usu by new { rol.tri_rol_nombre, rol.tri_rol_id } into grupo
                                      select new UsuarioDTO
                                      {
                                          idRol = grupo.Key.tri_rol_id,
                                          NombreRol = grupo.Key.tri_rol_nombre,
                                          NombresUsuarios = grupo.Select(tmp => tmp.tri_usu_nombres).ToList()
                                      }).ToListAsync();
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar usuarios por roles" + ex.Message);

            }
        }

        public async Task<List<UsuarioRolItinerarioDTO>> ListarUsuarioRolItinerario()
        {
            try
            {
                var resultado = await (from usu in _tributrekDBContext.tri_usuario
                                       join rol in _tributrekDBContext.tri_rol on usu.tri_usu_id equals rol.tri_rol_id
                                       join iti in _tributrekDBContext.tri_itinerario on usu.tri_usu_id equals iti.tri_itine_usu_id
                                       select new UsuarioRolItinerarioDTO
                                       {

                                           NombreUsuario = usu.tri_usu_nombres,
                                           NombreRol = rol.tri_rol_nombre,
                                           Itinerario = iti.tri_itine_nombre
                                       }).ToListAsync();



                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar producto por tipo" + ex.Message);

            }
        }

        public async Task<List<LoginDTO>> AutenticarAsync(string nombre, string clave)
        {
            try
            {
                var resultado = await _tributrekDBContext.tri_usuario
                    .Where(u => u.tri_usu_nombre_usuario == nombre && u.tri_usu_clave == clave)
                    .Select(u => new LoginDTO
                    {
                        nombreUsuario = u.tri_usu_nombre_usuario,
                        claveUsuario = u.tri_usu_clave
                    })
                    .ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al autenticar: " + ex.Message);
            }
        }
    }
}
