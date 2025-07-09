using Microsoft.EntityFrameworkCore;
using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;

namespace ConsultaSimple2
{
    public class Tests
    {
        private IPaqueteItinerarioServicio _PaqueteItinerarioServicio;
        private tributrekContext _tributrekdbContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<tributrekContext>()
                    .UseSqlServer("Data Source=DESKTOP-RAQUEL;Initial Catalog=tributrek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                    .Options;
            _tributrekdbContext = new tributrekContext(opciones);
            _PaqueteItinerarioServicio = new PaqueteItinerarioServicioImpl(_tributrekdbContext);
        }

        [Test]
        public async Task Test1()
        {
            //await rolesServicio.RolesGetAllAsync();
            var result = await _PaqueteItinerarioServicio.PaqueteGetAllAsync();
            var paquetes = result.Select(r => r.tri_paq_iti_descripcion).ToList();
            Console.WriteLine("Listado de paquetes activos:");
            foreach (var nombre in paquetes)
            {
                Console.WriteLine($"- {nombre}");
            }
        }

        [TearDown]
        public void DespuesTest()
        {
            _tributrekdbContext.Dispose();
        }
    }
}