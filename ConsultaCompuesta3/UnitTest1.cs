using Microsoft.EntityFrameworkCore;
using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;

namespace ConsultaCompuesta3
{
    public class Tests
    {
        private IActividadesServicio _actividadesServicio;
        private tributrekContext _tributrekdbContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<tributrekContext>()
                    .UseSqlServer("Data Source=DESKTOP-RAQUEL;Initial Catalog=tributrek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                    .Options;
            _tributrekdbContext = new tributrekContext(opciones);
            _actividadesServicio = new ActividadesServicioImpl(_tributrekdbContext);
        }

        [Test]
        public async Task Test1()
        {
            //await rolesServicio.RolesGetAllAsync();
            var actividades = await _actividadesServicio.ListarProductoPorTipo();
            foreach (var item in actividades)
            {
                Console.WriteLine($"Actividad: {item.tri_itine_nombre}, Categoría: {item.tri_cat_nombre}, Nivel: {item.tri_niv_dificultad}");

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