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
    public class NivelServicioImpl : INivelServicio
    {
        private INivelRepositorio nivelRepositorio;
        private readonly tributrekContext _context;


        public NivelServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;
            nivelRepositorio = new NivelRepositorioImpl(_context);
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

        public async Task<List<NivelDTO>> listarNiveles()
        {
            return await nivelRepositorio.listarNiveles();

        }

        public async Task<List<NivelListarDTO>> listarNivel()
        {
            return await nivelRepositorio.listarNivel();
        }
    }
}
