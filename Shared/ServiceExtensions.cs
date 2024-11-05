using Application.Common.Interfaces;
using Application.Common.Mailing;
using Domain.Common;
using Domain.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.DependencyInjection;
using Shared.Mailing;
using Shared.Services;

namespace Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedLayer(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));

            services
            .AddTransient<IMediator, Mediator>()
            .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddTransient<IDateTimeService, DateTimeService>()
            .AddTransient<IEmailService, EmailService>()
            .AddTransient<IFileService, FileService>()
            .AddTransient<IPaymentService, MercadoPagoService>()
            .AddTransient<IEmailTemplateService, EmailTemplateService>()
            .AddTransient<IExcelWriterService, ExcelWriterService>()
            .AddTransient<IRazorViewRenderer, RazorViewRenderer>();
            services.AddSingleton<ICompositeViewEngine, CompositeViewEngine>(); // Agregar esta línea puede resolver la falta de ICompositeViewEngine

            // Configuración adicional
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/Orders/{0}.cshtml");
            });
        }
    }
}
