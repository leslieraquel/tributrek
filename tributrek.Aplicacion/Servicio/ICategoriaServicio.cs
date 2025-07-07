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
    public interface ICategoriaServicio
    {

        [OperationContract]

        Task agregarCategoria(tri_categoria TEntity); //Insertar

        [OperationContract]

        Task actualizarCategoria(tri_categoria Entity);

        [OperationContract]
        Task eliminarCategoria(int tri_cat_id);

        [OperationContract]
        Task<List<tri_categoria>> listarCategorias();//listar todo
    }
}
