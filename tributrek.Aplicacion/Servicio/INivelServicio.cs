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
    public interface INivelServicio
    {
        [OperationContract]
        Task agregarNivel(tri_nivel TEntity); //Insertar

        [OperationContract]

        Task actualizarNivel(tri_nivel Entity);

        [OperationContract]
        Task eliminarNivel(int tri_niv_id);

        [OperationContract]
        Task<List<NivelDTO>> listarNiveles();//listar todo
    }
}
