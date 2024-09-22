using Application;
using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Identity;
using Identity.Context;
using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Contexts;
using Persistence.Seeds;
using Serilog;
using Serilog.Events;
using Shared;
using System.Text.Json.Serialization;
using WebApi.Extensions;
using WebApi.Extensions.HealthCheck;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

/***** INSTANCIAMOS CAPAS *****/
//Aca Agrego el servicio de la capa de aplicacion
builder.Services.AddApplicationLayer(builder.Configuration);

//Agrego el service de JWT
builder.Services.AddIdentityInfrastructureLayer(builder.Configuration);

//Aca Agrego el servicio de la capa Shared
builder.Services.AddSharedLayer(builder.Configuration);

//Aca agrego capa de persistencia
builder.Services.AddPersistenceLayer(builder.Configuration);

//Configuro Health Ckeck
//builder.Services.ConfigureHealthChecks(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

//Agrego instancia para versionado
builder.Services.AddApiVersioningExtension();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
       builder =>
       {
           builder.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
       });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
//}

app.UseHttpsRedirection();

//HealthCheck Middleware
//app.MapHealthChecks("/api/health", new HealthCheckOptions()
//{
//    Predicate = _ => true,
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});
//app.UseHealthChecksUI(delegate (Options options)
//{
//    options.UIPath = "/healthcheck-ui";
//    options.AddCustomStylesheet("./Extensions/HealthCheck/healthcheck.css");

//});

app.UseCors("AllowAll");

app.UseStaticFiles();

var resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

if (Directory.Exists(resourcesPath) && Directory.EnumerateFiles(resourcesPath, "*", SearchOption.AllDirectories).Any())
{
    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(resourcesPath),
        RequestPath = new PathString("/Resources")
    });
}


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//Aca usamos el middleware de errores
app.UseErrorHandlingMiddleware();

app.MapControllers();

try
{
    Log.Information("Iniciando Web API");

    await CargarSeeds();

    Log.Information("Corriendo en:");
    Log.Information("https://localhost:44361");

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");

    return;
}
finally
{
    Log.CloseAndFlush();
}

app.Run();


async Task CargarSeeds()
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var identityContext = services.GetRequiredService<IdentityContext>();
    identityContext.Database.EnsureCreated();

    await DefaultRoles.SeedAsync(userManager, roleManager, identityContext);
    await DefaultUsers.SeedAsync(userManager, roleManager, identityContext);

    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    await ProductSeed.SeedAvailabilityAsync(context);
    await ProductSeed.SeedBrandAsync(context);
    await ProductSeed.SeedCategoryAsync(context);
    await ProductSeed.SeedQuantityTypesyAsync(context);
    await ProductSeed.SeedSpecsyAsync(context);
    await ProductSeed.SeedShippingMethodAsync(context);
    await ProductSeed.SeedProductAsync(context);
}