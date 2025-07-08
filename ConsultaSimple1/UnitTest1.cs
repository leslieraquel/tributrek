using Microsoft.EntityFrameworkCore;
using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;

namespace ConsultaSimple
{
    public class Tests
    {
        private ICategoriaServicio _categoriaServicio;
        private tributrekContext _tributrekdbContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<tributrekContext>()
                    .UseSqlServer("Data Source=DESKTOP-RAQUEL;Initial Catalog=tributrek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                    .Options;
            _tributrekdbContext = new tributrekContext(opciones);
            _categoriaServicio = new CategoriaServicioImpl(_tributrekdbContext);
        }

        [Test]
        public async Task Test1()
        {
            //await rolesServicio.RolesGetAllAsync();
            var result = await _categoriaServicio.CategoriaGetAllAsync();
            var nombresCategoria = result.Select(r => r.tri_cat_id).ToList();
            Console.WriteLine("Listado de categorias activos:");
            foreach (var nombre in nombresCategoria)
            {
                Console.WriteLine($"- {nombre}");
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