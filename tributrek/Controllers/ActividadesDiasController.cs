using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{
    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class ActividadesDiasController : Controller
    {
        private IActividadesDiasServicio _actividadesDiasServicio;

        public ActividadesDiasController(IActividadesDiasServicio actividadesDiasServicio)
        {
            _actividadesDiasServicio = actividadesDiasServicio;
        }
        [HttpGet("ListarActividadesDias")]
        public async Task<IEnumerable<tri_actividades_dias>> ListarActividadesDias()
        {
            return await _actividadesDiasServicio.actividadesdiasGetAllAsync();
        }

        [HttpPost("CrearActividadesDias")]
        public async Task<IActionResult> CrearActividadesDias([FromBody] tri_actividades_dias nuevaActividadesDias)
        {
            try
            {
                await _actividadesDiasServicio.actividadesdiasAddAsync(nuevaActividadesDias);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }


        [HttpPut("ActividadesDias/{id}")]
        public async Task<IActionResult> ActualizarActvidadesDias(int id, [FromBody] tri_actividades_dias actidiasActualizado)

        {
            if (id != actidiasActualizado.tri_acti_dia_id) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _actividadesDiasServicio.actividadesdiasUpdateAsync(actidiasActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar categoria: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("ActividadesDias/{id}")]
        public async Task<IActionResult> EliminarActividadesServicio(int id)
        {
            try
            {
                await _actividadesDiasServicio.actividadesdiasDeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la categoria: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

    }
}
