using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Aplicacion.Servicio
{
    [ServiceContract]
    public interface IRolServicio
    {
        [OperationContract]
        Task rolAddAsync(tri_rol TEntity); //insertar
        [OperationContract]
        Task rolUpdateAsync(tri_rol Entity);//actualizar
        [OperationContract]
        Task rolDeleteAsync(int id);//eliminar por ID
        [OperationContract]
        Task<IEnumerable<tri_rol>> rolGetAllAsync();//listar todo
        [OperationContract]
        Task<tri_rol> rolGetByIdAsync(int id);//buscar por ID

        [OperationContract]
        Task<List<RolDTO>> listarRol();


    }
}
