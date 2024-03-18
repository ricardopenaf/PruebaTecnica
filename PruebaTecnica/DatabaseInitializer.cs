using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica
{
    /// <summary>
    /// Crea la bd y las tbls sino existen de acuerdo a la migración creada
    /// </summary>
    public class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
