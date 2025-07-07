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
    public interface IActividadesDiasServicio
    {
        [OperationContract]
        Task actividadesdiasAddAsync(tri_actividades_dias TEntity); //insertar
        [OperationContract]
        Task actividadesdiasUpdateAsync(tri_actividades_dias Entity); //actualizar
        [OperationContract]
        Task actividadesdiasDeleteAsync(int id); //eliminar por ID
        [OperationContract]
        Task<IEnumerable<tri_actividades_dias>> actividadesdiasGetAllAsync(); //listar todo
        [OperationContract]
        Task<tri_actividades_dias> actividadesdiasGetByIdAsync(int id); //buscar por ID
    }
}
