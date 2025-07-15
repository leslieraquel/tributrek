using Microsoft.AspNetCore.Mvc;

namespace tributrek.Controllers
{
    [ApiController]
    [Route("api/tributrek/[controller]")]
    public class DemoControladorcs : ControllerBase
    {
        [HttpGet]

        public string mensaje()
        {
            return "Hola mundo";
        }

        [HttpGet("{nombre}")]

        public string GetMensajeHola(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return "Hola, visitante";
            }

            return $"Hola, {nombre}";
        }

        
    }
}
