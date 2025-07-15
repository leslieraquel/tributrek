using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{
    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class PaqueteController : Controller
    {
        private IPaqueteItinerarioServicio _paqueteServicio;

        public PaqueteController(IPaqueteItinerarioServicio paqueteServicio)
        {
            _paqueteServicio = paqueteServicio;
        }

        [HttpGet]
        public Task<IEnumerable<tri_paquete_itinerario>> ListarPaquete()
        {
            return _paqueteServicio.PaqueteGetAllAsync();
        }

        [HttpPost("CrearPaquete")]
        public async Task<IActionResult> CrearPaquete([FromBody] tri_paquete_itinerario nuevopaquete)
        {
            try
            {
                await _paqueteServicio.PaqueteAddAsync(nuevopaquete);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRol(int id, [FromBody] tri_paquete_itinerario paqueteActualizado)

        {
            if (id != paqueteActualizado.idtri_paq_iti) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _paqueteServicio.PaqueteUpdateAsync(paqueteActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar paquete: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPaquete(int id)
        {
            try
            {
                await _paqueteServicio.PaqueteDeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar paquete: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
