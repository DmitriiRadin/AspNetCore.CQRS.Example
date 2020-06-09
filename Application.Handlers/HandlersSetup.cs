using System.Reflection;
using Application.Handlers.Base.Extensions;
using Application.Handlers.Behaviours;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Handlers
{
    public static class HandlersSetup
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatRBehaviourToCommands(Assembly.GetExecutingAssembly(), typeof(LoggingBehaviour<,>));

            return services;
        }
    }
}