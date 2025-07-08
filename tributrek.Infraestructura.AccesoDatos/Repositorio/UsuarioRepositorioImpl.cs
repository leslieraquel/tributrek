using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}
