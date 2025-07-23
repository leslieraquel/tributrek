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
    public class ItinerarioServicioImpl: IItinerarioServicio
    {
        private readonly IItenarioRepositorio _iitenerarioRepositorio;
        private readonly tributrekContext _context;


        public ItinerarioServicioImpl(tributrekContext tributrekContext)
        {
            _context = tributrekContext;
            _iitenerarioRepositorio = new ItinerarioRepositorioImpl(_context);
        }

        public async Task ItinerarioAddAsync(tri_itinerario TEntity)
        {
            await _iitenerarioRepositorio.AddAsync(TEntity);

        }

        public async Task ItinerarioDeleteAsync(int id)
        {
            await _iitenerarioRepositorio.EliminarItinerarioAsync(id);

        }

        //public Task ItinerarioDeleteAsync(int id)
        //{
        //    await _iitenerarioRepositorio.EliminarItinerarioAsync(id);

        //}

        public Task<IEnumerable<tri_itinerario>> ItinerarioGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<tri_itinerario> ItinerarioGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task ItinerarioUpdateAsync(tri_itinerario TEntity)
        {
            await _iitenerarioRepositorio.UpdateAsync(TEntity);

        }

        public async Task<List<ItinerarioDTO>> listarItinerario()
        {
            return await _iitenerarioRepositorio.ListarItinerario();
        }

    

        public async Task<List<ItinerariosPorNivelCategoriaDTO>> ListarPorNivel()
        {
           return await _iitenerarioRepositorio.ListarPorNivel();
        }

        public Task<List<UsuarioItinerarioPaqueteDTO>> ListarUsuarioItinerarioPaquete()
        {
            return _iitenerarioRepositorio.ListarUsuarioItinerarioPaquete();
        }
    }
}
