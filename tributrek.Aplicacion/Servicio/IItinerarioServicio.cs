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
    public interface IItinerarioServicio
    {

        [OperationContract]
        Task ItinerarioAddAsync(tri_itinerario TEntity); //insertar
        [OperationContract]
        Task ItinerarioUpdateAsync(tri_itinerario Entity); //Actualizar
        [OperationContract]
        Task ItinerarioDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<tri_itinerario>> ItinerarioGetAllAsync(); //listar todo
        [OperationContract]
        Task<tri_itinerario> ItinerarioGetByIdAseync(int id); //buscar por id
        
        [OperationContract]
        Task<List<ItinerariosPorNivelCategoriaDTO>> ListarPorNivel();

        [OperationContract]
        Task<List<UsuarioItinerarioPaqueteDTO>> ListarUsuarioItinerarioPaquete();

        [OperationContract]
        Task<List<ItinerarioDTO>> listarItinerario();

    }
}
