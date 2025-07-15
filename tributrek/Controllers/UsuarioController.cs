using Microsoft.AspNetCore.Mvc;
using tributrek.Aplicacion.Servicio;
using tributrek.Controllers;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Controllers
{

    [ApiController]

    [Route("api/tributrek/[controller]")]
    public class UsuarioController: Controller
    {
        private IUsuarioServicio _usuarioServicio;


        [HttpGet]
        public string mensaje()
        {
            return "Hola tabla usuario";
        }

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
           public Task<IEnumerable<tri_usuario>> usuarioGetAllAsync() {
             return _usuarioServicio.usuarioGetAllAsync();
            }

        [HttpPost]
        public async Task<IActionResult>CrearUsuario([FromBody] tri_usuario nuevousuario)
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




    }
}
