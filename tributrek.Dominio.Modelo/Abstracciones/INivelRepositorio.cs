﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface INivelRepositorio:IRepositorio<tri_nivel>
    {
        Task<List<tri_nivel>> listarNiveles();

    }
}
