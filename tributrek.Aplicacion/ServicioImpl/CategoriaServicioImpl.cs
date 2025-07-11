﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Aplicacion.Servicio;
using tributrek.Dominio.Modelo.Abstracciones;
using tributrek.Infraestructura.AccesoDatos;
using tributrek.Infraestructura.AccesoDatos.Repositorio;

namespace tributrek.Aplicacion.ServicioImpl
{
    public class CategoriaServicioImpl : ICategoriaServicio
    {
        private ICategoriaRepositorio categoriaRepositorio;

        public CategoriaServicioImpl(tributrekContext tributrekContext)
        {
            this.categoriaRepositorio = new CategoriaRepositorioImpl(tributrekContext);
        }

        public Task CategoriaAddAsync(tri_categoria TEntity)
        {
            throw new NotImplementedException();
        }

        public Task CategoriaDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tri_categoria>> CategoriaGetAllAsync()
        {
            return categoriaRepositorio.GetAllAsync();
        }

        public Task<tri_categoria> CategoriaGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CategoriaUpdateAsync(tri_categoria Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<tri_categoria>> ListarCategorias()
        {
            return categoriaRepositorio.ListarCategorias();
        }
    }
}
