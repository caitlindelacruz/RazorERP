using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorERP.Application.Interfaces;
using RazorERP.Infrastructure.Persistence;
using RazorERP.Infrastructure.Persistence.Repositories;
using RazorERP.Infrastructure.Services;
using System.Text;

namespace RazorERP.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DefaultConnection") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, DapperUnitOfWork>(c => new DapperUnitOfWork(connectionString));
            services.AddSingleton(new SqlConnectionFactory(connectionString));
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddScoped<IJwtTokenGenerator>(provider => new JwtTokenGenerator(configuration["Jwt:SecretKey"]));

            return services;
        }
    }
}
