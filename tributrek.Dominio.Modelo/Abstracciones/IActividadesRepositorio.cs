using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IActividadesRepositorio : IRepositorio<tri_actividades>
    {
        IEnumerable<tri_actividades> buscarRolNombre(String nombre);
    }
}
