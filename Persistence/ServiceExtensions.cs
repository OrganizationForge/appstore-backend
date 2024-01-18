using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Register services here
            //services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));

            //services.AddSingleton<MongoDbContext>(serviceProvider =>
            //{
            //    var settings = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            //    return new MongoDbContext(settings.ConnectionString, settings.DatabaseName);
            //});

            //Agregamos una inyeccion donde le decimos que un tipo de RepositoryAsync va a implementar
            //un IRepositoryAsync cualquiera sea
            #region Repositories
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            #endregion

            #region Caching
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    //options.Configuration = "149.50.128.254:6379";
            //    options.Configuration = configuration.GetValue<string>("Caching:RedisConnection");
            //});
            #endregion
        }
    }
}
