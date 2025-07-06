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
    public interface IUsuarioServicio
    {
        [OperationContract]
        Task usuarioAddAsync(tri_usuario TEntity); //insertar
        [OperationContract]
        Task usuarioUpdateAsync(tri_usuario Entity); //actualizar
        [OperationContract]
        Task usuarioDeleteAsync(int id); //eliminar por ID
        [OperationContract]
        Task<IEnumerable<tri_usuario>> usuarioGetAllAsync(); //listar todo
        [OperationContract]
        Task<tri_usuario> usuarioGetByIdAsync(int id); //buscar por ID
    }
}
