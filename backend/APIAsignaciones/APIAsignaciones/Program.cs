using APIAsignaciones.Model.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
    .AllowAnyHeader();
});

IConfiguration configuration = app.Services.GetRequiredService<IConfiguration>();
// Inicializacion de servcio de configuracion
ConfigurationAccess.Instance.Initialization(configuration);

// Se realiza la carga inicial a la BD desde configuracion JSON.
new CargaInicialSesiones(configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
