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

        public IEnumerable<tri_actividades> buscarRolNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActividadesDTO>> ListarActividades()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = await (from act in _tributrekdbContext.tri_actividades
                                       select new ActividadesDTO
                                       {
                                           idActividad = act.tri_acti_id,
                                           nombreActividad = act.tri_acti_descripcion,
                                           estadoActividad= act.tri_acti_estado
                                       }).ToListAsync();

                return resultado;

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }
    }
}
