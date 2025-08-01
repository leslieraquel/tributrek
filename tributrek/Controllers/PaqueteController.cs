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
   

        public async Task<IActionResult> CrearPaquete([FromBody] PaqueteItinerarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _paqueteServicio.PaqueteAddAsync(dto);
            return Ok(new { mensaje = "Paquete creado exitosamente" });
        }


        [HttpPut("ActualizarPaquete/{id}")]
        public async Task<IActionResult> ActualizarPaquete(int id, [FromBody] PaqueteConDiasDetDTO dto)

        {
            if (id != dto.IdPaquete)
                return BadRequest("El ID no coincide");

            try
            {
                await _paqueteServicio.EditarPaqueteAsync(dto);
                return Ok("Actualizado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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

        [HttpGet("obtener-paquete/{id}")]
        public async Task<IActionResult> ObtenerPaquetePorId(int id)
        {
            var paquete = await _paqueteServicio.ObtenerPaqueteConActividades(id);
            if (paquete == null)
                return NotFound("No existe el paquete");

            return Ok(paquete);
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
