using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Aplicacion.Servicio
{
    [ServiceContract]
    public interface ICategoriaServicio
    {

        [OperationContract]
        Task CategoriaAddAsync(tri_categoria TEntity); //insertar
        [OperationContract]
        Task CategoriaUpdateAsync(tri_categoria Entity); //Actualizar
        [OperationContract]
        Task CategoriaDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<tri_categoria>> CategoriaGetAllAsync(); //listar todo
        [OperationContract]
        Task<tri_categoria> CategoriaGetByIdAseync(int id); //buscar por id

        [OperationContract]
        Task<List<CategoriaDTO>> ListarCategorias();



    }
}
