using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.DTO.DTOs;
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
        [HttpGet("ListarPaquete")]
        public async Task<IActionResult> listarPaqueteItinerario()
        {
            try
            {
                var categorias = await _paqueteServicio.listarPaqueteItinerario();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, $"Error al obtener categorías: {ex.Message}");
            }
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


        [HttpPut("ActualizarPaquete/{id}")]
        public async Task<IActionResult> ActualizarPaquete(int id, [FromBody] tri_paquete_itinerario paqueteActualizado)

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

        [HttpDelete("EliminarPaquete/{id}")]
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

        //[HttpPost("CrearConDias")]
        //public async Task<IActionResult> CrearConDias([FromBody] PaqueteConDiasDto dto)
        //{
        //    var paquete = new Paquete
        //    {
        //        tri_paq_iti_descripcion = dto.Descripcion,
        //        tri_paq_iti_cantidad_dias = dto.CantidadDias,
        //        tri_paq_idtri_itine = dto.IdItinerario
        //    };

        //    _context.Paquete.Add(paquete);
        //    await _context.SaveChangesAsync(); // para generar el ID

        //    foreach (var detalle in dto.Detalles)
        //    {
        //        var dia = new DetallePaquete
        //        {
        //            IdPaquete = paquete.Id,
        //            Descripcion = detalle.Descripcion,
        //            NumeroDia = dto.Detalles.IndexOf(detalle) + 1
        //        };
        //        _context.DetallePaquete.Add(dia);
        //    }

        //    await _context.SaveChangesAsync();
        //    return Ok(new { message = "Paquete y días creados con éxito" });
        //}
    }
}
