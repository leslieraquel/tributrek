using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{
    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class NivelController: Controller
    {
        private INivelServicio _nivelServicio;

        public NivelController(INivelServicio nivelServicio)
        {
            _nivelServicio = nivelServicio;
        }

        [HttpGet("ListarNivel")]
        public async Task<IActionResult> ListarNivel()
        {
            try
            {
                var categorias = await _nivelServicio.listarNivel();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, $"Error al obtener nivel: {ex.Message}");
            }
        }

        [HttpPost("CrearNivel")]
        public async Task<IActionResult> CrearNivel([FromBody] tri_nivel nuevonivel)
        {
            try
            {
                await _nivelServicio.agregarNivel(nuevonivel);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarNivel(int id, [FromBody] tri_nivel nivelActualizado)

        {
            if (id != nivelActualizado.tri_niv_id) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _nivelServicio.actualizarNivel(nivelActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar nivel: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPaquete(int id)
        {
            try
            {
                await _nivelServicio.eliminarNivel(id);
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
