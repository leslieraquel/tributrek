using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{
    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class  CategoriaController : Controller
    {

        private ICategoriaServicio _categoriaServicio;

        public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }


        [HttpGet("ListarCategoria")]
        public async Task<IActionResult> ListarCategorias()
        {
            try
            {
                var categorias = await _categoriaServicio.ListarCategorias();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, $"Error al obtener categorías: {ex.Message}");
            }
        }

        [HttpPost("CrearCategoria")]
        public async Task<IActionResult> CrearCategoria([FromBody] tri_categoria nuevacategoria)
        {
            try
            {
                await _categoriaServicio.CategoriaAddAsync(nuevacategoria);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizarcategoria(int id, [FromBody] tri_categoria categoriaActualizado)

        {
            if (id != categoriaActualizado.tri_cat_id) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _categoriaServicio.CategoriaUpdateAsync(categoriaActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar categoria: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            try
            {
                await _categoriaServicio.CategoriaDeleteAsync(id);
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
