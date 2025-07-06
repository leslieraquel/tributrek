using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class UsuarioRepositorioImpl : RepositorioImpl<tri_usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
        }

        public IEnumerable<tri_rol> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
