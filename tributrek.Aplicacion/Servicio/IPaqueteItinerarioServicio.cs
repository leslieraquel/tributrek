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
    public interface IPaqueteItinerarioServicio
    {

        [OperationContract]
        Task PaqueteAddAsync(tri_paquete_itinerario TEntity); //insertar
        [OperationContract]
        Task PaqueteUpdateAsync(tri_paquete_itinerario Entity); //Actualizar
        [OperationContract]
        Task PaqueteDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<tri_paquete_itinerario>> PaqueteGetAllAsync(); //listar todo
        [OperationContract]
        Task<tri_paquete_itinerario> PaqueteGetByIdAseync(int id); //buscar por id

        [OperationContract]
        Task<List<PaqueteItinerarioCategoriaDTO>> ListarPaqueteItinerarioCategoria();

        [OperationContract]
        Task<List<PaqueteDTO>> listarPaqueteItinerario();

    }
}
