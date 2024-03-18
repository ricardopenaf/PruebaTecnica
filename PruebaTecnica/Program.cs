using Microsoft.Extensions.Hosting;
using PruebaTecnica;



var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();


startup.Configure(app, app.Environment);

/*Ejecuta la validación de si existe o no la bd y tbls para crearlas*/
DatabaseInitializer.Initialize(app.Services);

app.Run();



