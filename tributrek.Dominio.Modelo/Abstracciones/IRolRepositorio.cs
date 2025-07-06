using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IRolRepositorio : IRepositorio<tri_rol>
    {
        IEnumerable<tri_rol> buscarRolNombre(String nombre);
    }
}
