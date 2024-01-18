using Application.Common.Interfaces;
using Domain.Common;
using Domain.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;

namespace Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedLayer(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services
            .AddTransient<IMediator, Mediator>()
            .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddTransient<IDateTimeService, DateTimeService>()
            .AddTransient<IEmailService, EmailService>();
        }
    }
}
