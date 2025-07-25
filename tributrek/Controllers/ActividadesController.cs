﻿using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{
    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class ActividadesController : Controller
    {
        private IActividadesServicio _actividadesServicio;

        public ActividadesController(IActividadesServicio actividadesServicio)
        {
            _actividadesServicio = actividadesServicio;
        }

        [HttpGet("ListarActividades")]
       
        public async Task<IActionResult> ListarActividades()
        {
            try
            {
                var actividades = await _actividadesServicio.ListarActividades();
                return Ok(actividades);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, $"Error al obtener categorías: {ex.Message}");
            }
        }

        [HttpPost("CrearActividades")]
        public async Task<IActionResult> CrearActividades([FromBody] tri_actividades nuevaActividad)
        {
            try
            {
                await _actividadesServicio.actividadesAddAsync(nuevaActividad);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }


        [HttpPut("ActualizarActividad/{id}")]
        public async Task<IActionResult> ActualizarActvidades(int id, [FromBody] tri_actividades actividadActualizado)

        {
            if (id != actividadActualizado.tri_acti_id) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _actividadesServicio.actividadesUpdateAsync(actividadActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar categoria: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("EliminarActividad/{id}")]
        public async Task<IActionResult> EliminarActividades(int id)
        {
            try
            {
                await _actividadesServicio.actividadesDeleteAsync(id);
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
