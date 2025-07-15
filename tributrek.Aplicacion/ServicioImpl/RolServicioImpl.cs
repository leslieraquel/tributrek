using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.Servicio;
using tributrek.Dominio.Modelo.Abstracciones;
using tributrek.Infraestructura.AccesoDatos;
using tributrek.Infraestructura.AccesoDatos.Repositorio;

namespace tributrek.Aplicacion.ServicioImpl
{
    public class RolServicioImpl : IRolServicio
    {
        private IRolRepositorio rolRepositorio;
        private readonly tributrekContext _context;

        public RolServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;
            rolRepositorio = new RolRepositorioImpl(_context);
        }

        public async Task rolAddAsync(tri_rol TEntity)
        {
            await rolRepositorio.AddAsync(TEntity);

        }

        public async Task rolDeleteAsync(int id)
        {
            await rolRepositorio.DeleteAsync(id);
        }

        public Task<IEnumerable<tri_rol>> rolGetAllAsync()
        {
            return rolRepositorio.GetAllAsync();
        }

        public Task<tri_rol> rolGetByIdAsync(int id)
        {
            return rolRepositorio.GetByIdAsync(id);
        }

        public async Task rolUpdateAsync(tri_rol Entity)
        {
            await rolRepositorio.UpdateAsync(Entity);
        }
    }
}
