using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class ItinerarioRepositorioImpl : RepositorioImpl<tri_itinerario>, IItenarioRepositorio
    {
        public ItinerarioRepositorioImpl(tributrekContext dbContext) : base(dbContext)
        {

        }
    }
}
