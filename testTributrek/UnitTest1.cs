
using Microsoft.EntityFrameworkCore;
using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;

namespace testTributrek
{
    public class Tests
    {
        private tributrekContext _tributrekdbContext;
        private IRolServicio _rolServicio;
        private IUsuarioServicio _usuarioServicio;
        private ICategoriaServicio _categoriaServicio;
        private INivelServicio _nivelServicio;


        [SetUp]
        public void Setup()
        {
            {
                var opciones = new DbContextOptionsBuilder<tributrekContext>()
                    .UseSqlServer("Data Source=DESKTOP-RAQUEL;Initial Catalog=tributrek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                    .Options;
                _tributrekdbContext = new tributrekContext(opciones);
                _categoriaServicio = new CategoriaServicioImpl(_tributrekdbContext);
                _rolServicio = new RolServicioImpl(_tributrekdbContext);
                _usuarioServicio = new UsuarioServicioImpl(_tributrekdbContext);
                _nivelServicio = new NivelServicioImpl(_tributrekdbContext);

            }
        }

        [Test]
        public async Task Test1()
        {
            //var rol = new tri_rol
            //{
            //    tri_rol_nombre = "Usuario",
            //    tri_rol_estado = "1"
            //};

            //await _rolServicio.rolAddAsync(rol);
            await _rolServicio.rolGetAllAsync();


            //var usuario = new tri_usuario
            //{
            //    tri_usu_nombres = "Juan Jose",
            //    tri_usu_apellido = "Gonzales",
            //    tri_usu_fecha_nacimiento = new DateOnly(1990, 2, 2),
            //    tri_usu_correo = "jjgonzales@info.com",
            //    tri_usu_nombre_usuario = "jjgonzales",
            //    tri_usu_clave = "123456",
            //    tri_usu_rol_id = 1, // Asegúrate de que el rol con ID 1 exista en la base de datos
            //};


            //var categoria = new tri_categoria
            //{
            //    tri_cat_nombre = "SERVICES"
            //};
            //await _categoriaServicio.agregarCategoria(categoria);

            var niveles = new tri_nivel
            {
                tri_niv_descripcion = "Modo dificil",
                tri_niv_dificultad="dificil"
            };
            await _nivelServicio.agregarNivel(niveles);
            //await _usuarioServicio.usuarioAddAsync(usuario);
            await _usuarioServicio.usuarioGetAllAsync();
            var categorias = await _categoriaServicio.listarCategorias();

            foreach (var cat in categorias)
            {
                Console.WriteLine($"Id: {cat.tri_cat_id}, Nombre: {cat.tri_cat_nombre}");
            }


        }

        [TearDown]
        public void DespuesTest()
        {
            _tributrekdbContext.Dispose();
        }
    }
}