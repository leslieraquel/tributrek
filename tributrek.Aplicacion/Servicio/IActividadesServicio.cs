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
    public interface IActividadesServicio
    {
        [OperationContract]
        Task actividadesAddAsync(tri_actividades TEntity); //insertar
        [OperationContract]
        Task actividadesUpdateAsync(tri_actividades Entity); //actualizar
        [OperationContract]
        Task actividadesDeleteAsync(int id); //eliminar por ID
        [OperationContract]
        Task<IEnumerable<tri_actividades>> actividadesGetAllAsync(); //listar todo
        [OperationContract]
        Task<tri_actividades> actividadesGetByIdAsync(int id); //buscar por ID
        [OperationContract]

        Task<List<ActividadesDTO>> ListarProductoPorTipo();
    }
}
