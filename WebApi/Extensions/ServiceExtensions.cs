using Asp.Versioning;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions= true;
            });
        }

        //Configure CORS to allow any origin, header and method.
        //Change the CORS policy based on your requirements.
        //More info see: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.0

        public static void AddCorsExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration["CORS:HostsPermitidos"];
            if (corsSettings == null) return;

            var origins = new List<string>();
            if (corsSettings is not null)
                origins.AddRange(corsSettings.Split(';', StringSplitOptions.RemoveEmptyEntries));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost" || new Uri(origin).Host == "myweb.local");
                    builder//.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .SetIsOriginAllowed(origin => true) // allow any origin
                                                               //.WithOrigins(origins.ToArray())
                           ;
                });
            });
        }
    }
}
