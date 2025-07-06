using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Aplicacion.Servicio
{
    [ServiceContract]
    public interface IItinerarioServicio
    {

        [OperationContract]

        Task agregarItinerario(tri_categoria TEntity); //Insertar

        [OperationContract]

        Task actualizarItinerario(tri_categoria Entity);

        [OperationContract]
        Task eliminarItinerario(int tri_cat_id);
    }
}
