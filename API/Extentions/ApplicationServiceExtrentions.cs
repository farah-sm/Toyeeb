using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Services;


namespace API.Extentions
{
    public static class ApplicationServiceExtrentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {

                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));

            });
            services.AddCors();

            // This is from the Token Services/ ITokenServices
            services.AddScoped<ITokenService, TokenServices>();

            return services;
        }
    }
}