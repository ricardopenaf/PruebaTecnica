using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace PruebaTecnica
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration=configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApiPruebas",
                    Version = "v1",
                    Description = "Este es un webapi para pruebas",
                    Contact = new OpenApiContact
                    {
                        Email = "ricardo@gmail.com",
                        Name = "Ricardo Peña Forero",
                        Url = new Uri("https://google.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT"
                    }
                });
                c.SchemaGeneratorOptions.UseInlineDefinitionsForEnums = true;
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v0", new OpenApiInfo { Title = "WebApiPruebas", Version = "v0" });

               


            });


            services.AddHttpContextAccessor();


            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnections")));

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddEndpointsApiExplorer();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v0/swagger.json", "webApiPruebas v0");
                });
                app.UseHttpsRedirection();

                app.UseStaticFiles();

                app.UseRouting();

                //CORS
                app.UseCors();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });


               

            }
        }

    }
}
