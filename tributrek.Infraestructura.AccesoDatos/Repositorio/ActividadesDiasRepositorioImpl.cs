using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class ActividadesDiasRepositorioImpl : RepositorioImpl<tri_actividades_dias>, IActividadesDiasRepositorio
    {
        public ActividadesDiasRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
        }

        public IEnumerable<tri_actividades_dias> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
