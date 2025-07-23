using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface IActividadesRepositorio : IRepositorio<tri_actividades>
    {
        IEnumerable<tri_actividades> buscarRolNombre(String nombre);
        Task<List<ActividadesDTO>> ListarActividades();

        Task ActualizarActividadAsync(tri_actividades idActividad);


    }
}
