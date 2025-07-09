using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class RolRepositorioImpl : RepositorioImpl<tri_rol>, IRolRepositorio
    {
        private readonly tributrekContext _tributrekdbContext;

        public RolRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            this._tributrekdbContext = dBContext;

        }

        public IEnumerable<tri_rol> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<List<tri_rol>> ListarRoles()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = from rol in _tributrekdbContext.tri_rol
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
