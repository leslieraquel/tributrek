﻿using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{

    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class RolController: Controller
    {
        private IRolServicio _rolServicio;

        public RolController(IRolServicio rolServicio)
        {
            _rolServicio = rolServicio;
        }

        [HttpGet("ListarRol")]
        public async Task<IActionResult> listarRol()
        {
            try
            {
                var roles = await _rolServicio.listarRol();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, $"Error al obtener categorías: {ex.Message}");
            }
        }

        [HttpPost("CrearRol")]
        public async Task<IActionResult> CrearRol([FromBody] tri_rol nuevorol)
        {
            try
            {
                await _rolServicio.rolAddAsync(nuevorol);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }


        [HttpPut("ActualizarRol/{id}")]
        public async Task<IActionResult> ActualizarRol(int id, [FromBody] tri_rol rolActualizado)

        {
            if (id != rolActualizado.tri_rol_id) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _rolServicio.rolUpdateAsync(rolActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar rol: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("EliminarRol/{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            try
            {
                await _rolServicio.rolDeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
