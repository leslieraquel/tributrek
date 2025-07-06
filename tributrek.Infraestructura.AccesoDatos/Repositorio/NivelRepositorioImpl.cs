using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class NivelRepositorioImpl : RepositorioImpl<tri_nivel>, INivelRepositorio
    {

        public NivelRepositorioImpl(tributrekContext dbContext) : base(dbContext)
        {

        }
    }
}
