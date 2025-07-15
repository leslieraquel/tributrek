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
    public class ActividadesDiasServicioImpl : IActividadesDiasServicio
    {
        private IActividadesDiasRepositorio actividadesDiasRepositorio;
        private readonly tributrekContext _context;

        public ActividadesDiasServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;
            actividadesDiasRepositorio = new ActividadesDiasRepositorioImpl (_context);
        }

        public async Task actividadesdiasAddAsync(tri_actividades_dias TEntity)
        {
            await actividadesDiasRepositorio.AddAsync(TEntity);
        }

        public async Task actividadesdiasDeleteAsync(int id)
        {
            await actividadesDiasRepositorio.DeleteAsync(id);
        }

        public Task<IEnumerable<tri_actividades_dias>> actividadesdiasGetAllAsync()
        {
            return actividadesDiasRepositorio.GetAllAsync();
        }

        public Task<tri_actividades_dias> actividadesdiasGetByIdAsync(int id)
        {
            return actividadesDiasRepositorio.GetByIdAsync(id);
        }

        public async Task actividadesdiasUpdateAsync(tri_actividades_dias Entity)
        {
            await actividadesDiasRepositorio.UpdateAsync(Entity);
        }
    }
}
