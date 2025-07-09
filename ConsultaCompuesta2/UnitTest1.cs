using Microsoft.EntityFrameworkCore;
using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;

namespace ConsultaCompuesta2
{
    public class Tests
    {
        private IPaqueteItinerarioServicio _paqueteItinerarioServicio;
        private tributrekContext _tributrekdbContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<tributrekContext>()
                    .UseSqlServer("Data Source=DESKTOP-RAQUEL;Initial Catalog=tributrek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                    .Options;
            _tributrekdbContext = new tributrekContext(opciones);
            _paqueteItinerarioServicio = new PaqueteItinerarioServicioImpl(_tributrekdbContext);
        }

        [Test]
        public async Task Test1()
        {
            //await rolesServicio.RolesGetAllAsync();
            var result = await _paqueteItinerarioServicio.ListarPaqueteItinerarioCategoria();
            foreach (var item in result)
            {
                Console.WriteLine(item.NombrePaquete + "-" + item.NombreCategoria);
              
            }
            //
            //var result = rolesServicio.ListarolEmpleado();
            //Console.WriteLine(result);
        }

        [TearDown]
        public void DespuesTest()
        {
            _tributrekdbContext.Dispose();
        }
    }
}