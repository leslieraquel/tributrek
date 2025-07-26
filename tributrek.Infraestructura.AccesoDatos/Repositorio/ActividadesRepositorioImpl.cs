using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Dominio.Modelo.Abstracciones;

namespace tributrek.Infraestructura.AccesoDatos.Repositorio
{
    public class ActividadesRepositorioImpl : RepositorioImpl<tri_actividades>, IActividadesRepositorio
    {
        private readonly tributrekContext _tributrekdbContext;

        public ActividadesRepositorioImpl(tributrekContext dBContext) : base(dBContext)
        {
            _tributrekdbContext = dBContext;
        }

        public  async Task ActualizarActividadAsync(tri_actividades actividad)
        {
            try
            {
                _tributrekdbContext.tri_actividades.Update(actividad);
                await _tributrekdbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la actividad: " + ex.Message);
            }
        }

        public IEnumerable<tri_actividades> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }

  

        public async Task AgregarActividadAsync(tri_actividades actividad)
        {
            try
            {
                _tributrekdbContext.tri_actividades.Add(actividad);
                await _tributrekdbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la actividad: " + ex.Message);
            }
        }

        // Eliminar actividad por ID
        public async Task EliminarActividadAsync(tri_actividades idActividad)
        {
            try
            {
                var actividad = await _tributrekdbContext.tri_actividades.FindAsync(idActividad);
                if (actividad != null)
                {
                    _tributrekdbContext.tri_actividades.Remove(actividad);
                    await _tributrekdbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la actividad: " + ex.Message);
            }
        }

        public async Task<List<ActividadesDTO>> ListarActividades()
        {
            try
            {
                var resultado = await (
                    from act in _tributrekdbContext.tri_actividades
                    select new ActividadesDTO
                    {
                        idActividad = act.tri_acti_id,
                        nombreActividad = act.tri_acti_descripcion,
                        estadoActividad = act.tri_acti_estado,
                        tri_acti_fecha_creacion = act.tri_acti_fecha_creacion,
                        tri_acti_fecha_mod = act.tri_acti_fecha_mod
                    }
                ).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las actividades: " + ex.Message);
            }
        }
    }
}
