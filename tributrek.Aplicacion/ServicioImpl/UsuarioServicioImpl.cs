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
    public class UsuarioServicioImpl : IUsuarioServicio
    {
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicioImpl(tributrekContext dbContext)
        {
            this.usuarioRepositorio = new UsuarioRepositorioImpl(dbContext);
        }

        public async Task<List<UsuarioDTO>> ListarUsuarioPorRol()
        {
            return await usuarioRepositorio.ListarUsuarioPorRol();
        }

        public async Task<List<UsuarioRolItinerarioDTO>> ListarUsuarioRolItinerario()
        {
            return await usuarioRepositorio.ListarUsuarioRolItinerario();

        }

        public async Task usuarioAddAsync(tri_usuario TEntity)
        {
            await usuarioRepositorio.AddAsync(TEntity);
        }

        public async Task usuarioDeleteAsync(int id)
        {
            await usuarioRepositorio.DeleteAsync(id);
        }

        public Task<IEnumerable<tri_usuario>> usuarioGetAllAsync()
        {
            return usuarioRepositorio.GetAllAsync();
        }

        public Task<tri_usuario> usuarioGetByIdAsync(int id)
        {
            return usuarioRepositorio.GetByIdAsync(id);
        }

        public async Task usuarioUpdateAsync(tri_usuario Entity)
        {
            await usuarioRepositorio.UpdateAsync(Entity);
        }
    }
}





