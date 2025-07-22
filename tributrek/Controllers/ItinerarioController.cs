using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{
    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class ItinerarioController : Controller
    {

        private IItinerarioServicio _itinerarioServicio;

        public ItinerarioController(IItinerarioServicio itinerarioServicio)
        {
            _itinerarioServicio = itinerarioServicio;
        }
        [HttpGet("ListarItinerario")]
        public async Task<IActionResult> ListarItinerario()
        {
            try
            {
                var categorias = await _itinerarioServicio.listarItinerario();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, $"Error al obtener categorías: {ex.Message}");
            }
        }

        [HttpPost("CrearItinerario")]
        public async Task<IActionResult> CrearItinerario([FromBody] tri_itinerario nuevoitinerario)
        {
          
            try
            {
                await _itinerarioServicio.ItinerarioAddAsync(nuevoitinerario);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }


        [HttpPut("ActualizarItinerario/{id}")]
        public async Task<IActionResult> ActualizarItinerario(int id, [FromBody] tri_itinerario itinerarioActualizado)

        {
            if (id != itinerarioActualizado.tri_itine_id) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _itinerarioServicio.ItinerarioUpdateAsync(itinerarioActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar itinerario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarItinerario(int id)
        {
            try
            {
                await _itinerarioServicio.ItinerarioDeleteAsync(id);
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
