using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class UsuarioRepositorioImpl : RepositorioImpl<tri_usuario>, IUsuarioRepositorio
    {
        private readonly tributrekContext _tributrekContext;

        public UsuarioRepositorioImpl(tributrekContext dBContext) : base(dBContext) 
        { 
        
           this._tributrekContext = dBContext;

        }

        public IEnumerable<tri_rol> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioDTO>> ListarUsuarioPorRol()
        {
            try
            {
                var resultado = await(from usu in _tributrekContext.tri_usuario
                                      join rol in _tributrekContext.tri_rol
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
                var resultado = await (from usu in _tributrekContext.tri_usuario
                                       join rol in _tributrekContext.tri_rol on usu.tri_usu_id equals rol.tri_rol_id
                                       join iti in _tributrekContext.tri_itinerario on usu.tri_usu_id equals iti.tri_itine_usu_id
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
                var resultado = await _tributrekContext.tri_usuario
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

        public async Task<List<UsuariosDTO>> listarUsuarios()
        {
            try
            {

                {
                    var result = await(
                        from usu in _tributrekContext.tri_usuario
                        join rol in _tributrekContext.tri_rol
                            on usu.tri_usu_rol_id equals rol.tri_rol_id
                        select new UsuariosDTO
                        {
                            tri_usu_id = usu.tri_usu_id,
                            tri_rol_nombre = rol.tri_rol_nombre,
                            tri_usu_apellido = usu.tri_usu_apellido,
                            tri_usu_nombres = usu.tri_usu_nombres,
                            tri_usu_correo = usu.tri_usu_correo,
                            tri_usu_clave = usu.tri_usu_clave,
                            tri_usu_estado = usu.tri_usu_estado,
                            tri_usu_nombre_usuario = usu.tri_usu_nombre_usuario,
                            tri_usu_rol_id = usu.tri_usu_rol_id 
                        
                        }

                    ).ToListAsync();

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar itinerario" + ex.Message);
            }
        }
    }
}
