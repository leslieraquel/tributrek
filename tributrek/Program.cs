using tributrek.Aplicacion.Servicio;
using tributrek.Aplicacion.ServicioImpl;
using tributrek.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//leer la variable de conexion a la BD 

var conexiondb = builder.Configuration.GetConnectionString("ConexionDBTributrek");
// configurar en dbcontext con la conexion string


builder.Services.AddDbContext<tributrekContext>(options =>
    options.UseSqlServer(conexiondb), ServiceLifetime.Scoped);

//configurar servicios
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicioImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
