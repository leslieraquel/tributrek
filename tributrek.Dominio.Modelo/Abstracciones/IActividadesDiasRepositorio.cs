using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IActividadesDiasRepositorio : IRepositorio<tri_actividades_dias>
    {
        IEnumerable<tri_actividades_dias> buscarRolNombre(String nombre);
    }
}
