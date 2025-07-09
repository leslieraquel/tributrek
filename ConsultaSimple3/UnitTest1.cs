using Microsoft.EntityFrameworkCore;
using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;

namespace ConsultaSimple3
{
    public class Tests
    {
        private IRolServicio IRolServicio;
        private tributrekContext _tributrekdbContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<tributrekContext>()
                    .UseSqlServer("Data Source=DESKTOP-RAQUEL;Initial Catalog=tributrek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                    .Options;
            _tributrekdbContext = new tributrekContext(opciones);
            IRolServicio = new RolServicioImpl(_tributrekdbContext);
        }

        [Test]
        public async Task Test1()
        {
            //await rolesServicio.RolesGetAllAsync();
            var result = await IRolServicio.rolGetAllAsync();
            var roles = result.Select(r => r.tri_rol_nombre).ToList();
            Console.WriteLine("Listado de roles activos:");
            foreach (var nombre in roles)
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