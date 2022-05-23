using Microsoft.EntityFrameworkCore;
using Pokemon.Infrastructure.Data.PokemonContext;

namespace Pokemon.API.Extension
{
    public static class DatabaseConnection
    {
        public static IServiceCollection AddSqliteDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PokemonDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DevelopmentDbConnection"));
            });

            return services;
        }
        
       
    }
}