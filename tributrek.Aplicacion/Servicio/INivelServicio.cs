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
    public interface INivelServicio
    {
        [OperationContract]

        Task agregarNivel(tri_categoria TEntity); //Insertar

        [OperationContract]

        Task actualizarNivel(tri_categoria Entity);

        [OperationContract]
        Task eliminarNivel(int tri_cat_id);
    }
}
