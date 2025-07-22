using System;
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
    public class ActividadesServicioImpl : IActividadesServicio
    {
        private IActividadesRepositorio actividadesRepositorio;
        private readonly tributrekContext _context;

        public ActividadesServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;

            actividadesRepositorio = new ActividadesRepositorioImpl(_context);
        }

        public async Task actividadesAddAsync(tri_actividades TEntity)
        {
            await actividadesRepositorio.AddAsync(TEntity);
        }

        public async Task actividadesUpdateAsync(tri_actividades Entity)
        {
            await actividadesRepositorio.UpdateAsync(Entity);
        }

        public async Task actividadesDeleteAsync(int id)
        {
            await actividadesRepositorio.DeleteAsync(id);
        }

        public Task<IEnumerable<tri_actividades>> actividadesGetAllAsync()
        {
            return actividadesRepositorio.GetAllAsync();
        }

        public Task<tri_actividades> actividadesGetByIdAsync(int id)
        {
            return actividadesRepositorio.GetByIdAsync(id);
        }

        public Task<List<ActividadesDTO>> ListarActividades()
        {
            return actividadesRepositorio.ListarActividades();
        }
    }
}
