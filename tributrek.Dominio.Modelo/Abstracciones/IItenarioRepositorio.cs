﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IItenarioRepositorio : IRepositorio<tri_itinerario>
    {
        IEnumerable<tri_itinerario> listarItinerarioPorNombre(string nombre_itinerario);

        Task<List<ItinerariosPorNivelCategoriaDTO>> ListarPorNivel();

        Task<List<UsuarioItinerarioPaqueteDTO>> ListarUsuarioItinerarioPaquete();

        Task<List<ItinerarioDTO>> ListarItinerario();

        Task AgregarItinerarioAsync(tri_itinerario itinerario);

        Task ActualizarItinerarioAsync(tri_itinerario idItinerario);

        Task EliminarItinerarioAsync(int idItinerario);



    }
}
