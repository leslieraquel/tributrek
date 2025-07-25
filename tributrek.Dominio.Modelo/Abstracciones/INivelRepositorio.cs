﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface INivelRepositorio:IRepositorio<tri_nivel>
    {
        Task<List<NivelDTO>> listarNiveles();
        Task<List<NivelListarDTO>> listarNivel();

        Task AgregarNivelAsync(tri_nivel nivel);
        Task ActualizarNivelAsync(tri_nivel idNivel);



    }
}
