using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class ActividadesRepositorioImpl : RepositorioImpl<tri_actividades>, IActividadesRepositorio
    {
        private readonly tributrekContext _tributrekdbContext;

        public ActividadesRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            _tributrekdbContext = dBContext;
        }    

        IEnumerable<tri_actividades> IActividadesRepositorio.buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
