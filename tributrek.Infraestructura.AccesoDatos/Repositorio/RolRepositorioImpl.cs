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
    public class RolRepositorioImpl : RepositorioImpl<tri_rol>, IRolRepositorio
    {
        private readonly tributrekContext _tributrekContext;

        public RolRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            this._tributrekContext = dBContext;

        }

        public IEnumerable<tri_rol> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RolDTO>> listarRol()
        {
            try
            {

                {
                    var result = await(
                        from rol in _tributrekContext.tri_rol
                        select new RolDTO
                        {
                            tri_rol_estado = rol.tri_rol_estado,
                            tri_rol_id = rol.tri_rol_id,
                            tri_rol_nombre = rol.tri_rol_nombre,


                        }

                    ).ToListAsync();

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar nivel" + ex.Message);
            }
        }

        public Task<List<tri_rol>> ListarRoles()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = from rol in _tributrekContext.tri_rol
                                select rol;
                return resultado.ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }
    }
}
