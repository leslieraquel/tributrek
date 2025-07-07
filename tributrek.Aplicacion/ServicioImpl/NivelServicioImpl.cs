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
    public class NivelServicioImpl : INivelServicio
    {
        private INivelRepositorio nivelRepositorio;

        public NivelServicioImpl(tributrekContext tributrekContext)
        {
            this.nivelRepositorio = new NivelRepositorioImpl(tributrekContext);
        }

        public Task actualizarNivel(tri_nivel Entity)
        {
            throw new NotImplementedException();
        }

        public async Task agregarNivel(tri_nivel TEntity)
        {
            await nivelRepositorio.AddAsync(TEntity);

        }

        public Task eliminarNivel(int tri_niv_id)
        {
            throw new NotImplementedException();
        }

        public Task<List<tri_nivel>> listarNiveles()
        {
            throw new NotImplementedException();
        }
    }
}
