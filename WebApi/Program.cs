using Application;
using Identity;
using Identity.Models;
using Identity.Seeds;
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

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

/***** INSTANCIAMOS CAPAS *****/
//Aca Agrego el servicio de la capa de aplicacion
builder.Services.AddApplicationLayer();

//Agrego el service de JWT
builder.Services.AddIdentityInfrastructureLayer(builder.Configuration);

//Aca Agrego el servicio de la capa Shared
builder.Services.AddSharedLayer(builder.Configuration);

//Aca agrego capa de persistencia
builder.Services.AddPersistenceLayer(builder.Configuration);

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

app.UseCors("AllowAll");

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});

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

    await DefaultRoles.SeedAsync(userManager, roleManager);
    await DefaultAdminUser.SeedAsync(userManager, roleManager);
    await DefaultBasicUser.SeedAsync(userManager, roleManager);

    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    //await BookSeed.SeedLanguagesAsync(context);
    //await BookSeed.SeedBooksAsync(context);

    await ProductSeed.SeedAvailabilityAsync(context);
    await ProductSeed.SeedBrandAsync(context);
    await ProductSeed.SeedCategoryAsync(context);
    await ProductSeed.SeedQuantityTypesyAsync(context);
    //await ProductSeed.SeedProductAsync(context);
}