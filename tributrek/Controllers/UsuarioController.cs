using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.DTO.DTOs;
using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;
using tributrek.Utilidades;

namespace tributrek.Controllers
{

    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class UsuarioController: Controller
    {
        private IUsuarioServicio _usuarioServicio;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioServicio usuarioServicio, IConfiguration configuration)
        {
            _usuarioServicio = usuarioServicio;
            _configuration = configuration;
        }
        [HttpGet("ListarUsuario")]
        public async Task<IActionResult> ListarUsuario()
        {
            try
            {
                var categorias = await _usuarioServicio.listarUsuarios();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, $"Error al obtener categorías: {ex.Message}");
            }
        }

        [HttpGet]
           public Task<IEnumerable<tri_usuario>> usuarioGetAllAsync() {
             return _usuarioServicio.usuarioGetAllAsync();
           }

        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] tri_usuario nuevousuario)
        {
            try
            {
                await _usuarioServicio.usuarioAddAsync(nuevousuario);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }



        [HttpPut("ActualizarUsuario/{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] tri_usuario usuarioActualizado)

        {
            if (id != usuarioActualizado.tri_usu_id) // Asegúrate que usas el campo correcto como ID
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            try
            {
                await _usuarioServicio.usuarioUpdateAsync(usuarioActualizado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                await _usuarioServicio.usuarioDeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> AutenticarAsync([FromBody] LoginDTO login)
        {
            try
            {
                var usuario = await _usuarioServicio.AutenticarAsync(login.nombreUsuario, login.claveUsuario);

                if (usuario == null)
                    return Unauthorized("Credenciales inválidas");

                // Obtener valores de configuración
                string secretKey = _configuration["Jwt:SecretKey"];
                int expireMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"]);

                string token = JwtHelper.GenerarToken(login.nombreUsuario, secretKey, expireMinutes);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en login: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }



    }
}
