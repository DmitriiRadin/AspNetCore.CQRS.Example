using System.Reflection;
using Application.Handlers.Base;
using Application.Handlers.Base.Pipeline;
using Application.Handlers.Customers.Queries;
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

            services.AddTransient(
                typeof(IPipelineBehavior<GetCustomers.Request, CommandResponse<GetCustomers.Response>>),
                typeof(LoggingBehaviour<GetCustomers.Request, GetCustomers.Response>));

            return services;
        }
    }
}