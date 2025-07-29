using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IPaqueteItinerarioRepositorio : IRepositorio<tri_paquete_itinerario>
    {
        Task<List<tri_paquete_itinerario>> ListarPaquetes();

        Task<List<PaqueteItinerarioCategoriaDTO>> ListarPaqueteItinerarioCategoria();

        Task<List<PaqueteDTO>> listarPaqueteItinerario();

        Task AgregarPaqueteItinerarioAsync(tri_paquete_itinerario paqueteItinerario);





    }
}
