﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class NivelRepositorioImpl : RepositorioImpl<tri_nivel>, INivelRepositorio
    {
        private readonly tributrekContext _tributrekdbContext;
        public NivelRepositorioImpl(tributrekContext dbContext) : base(dbContext)
        {
            _tributrekdbContext = dbContext;
        }

        public Task<List<tri_nivel>> listarNiveles()
        {
            throw new NotImplementedException();
        }
    }
}
