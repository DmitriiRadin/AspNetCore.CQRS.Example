using System;
using System.Linq;
using System.Reflection;
using Application.Handlers.Base.Interfaces;
using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Handlers.Base.Extensions
{
    public static class BehaviourServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRBehaviourToCommands(this IServiceCollection serviceCollection,
            Assembly assembly,
            Type behaviourType)
        {
            return serviceCollection.AddMediatRBehaviour(assembly, behaviourType, typeof(ICommand<>));
        }

        public static IServiceCollection AddMediatRBehaviourToQueries(this IServiceCollection serviceCollection,
            Assembly assembly,
            Type behaviourType)
        {
            return serviceCollection.AddMediatRBehaviour(assembly, behaviourType, typeof(IQuery<>));
        }

        public static IServiceCollection AddMediatRBehaviour(this IServiceCollection serviceCollection,
            Assembly assembly,
            Type behaviourType)
        {
            return serviceCollection.AddMediatRBehaviour(assembly, behaviourType, typeof(IMessage<>));
        }

        public static IServiceCollection AddMediatRBehaviour(
            this IServiceCollection serviceCollection,
            Assembly assembly,
            Type behaviourType,
            Type targetType)
        {
            var pairs = assembly.DefinedTypes
                .Where(info => info.FindInterfacesThatClose(targetType).Any())
                .Where(info => !info.GetTypeInfo().IsAbstract && !info.GetTypeInfo().IsInterface)
                .Select(info => new
                {
                    Request = info.AsType(),
                    Response = info.FindInterfacesThatClose(typeof(ICommand<>))
                        .FirstOrDefault()?
                        .GenericTypeArguments
                        .First()
                });

            foreach (var pair in pairs)
            {
                serviceCollection.AddBehaviour(pair.Request, pair.Response, behaviourType);
            }

            return serviceCollection;
        }

        private static IServiceCollection AddBehaviour(this IServiceCollection serviceCollection,
            Type requestType, Type responseType, Type behaviour)
        {
            var pipelineBehaviourType = typeof(IPipelineBehavior<,>)
                .MakeGenericType(requestType,
                    typeof(CommandResponse<>).MakeGenericType(responseType));

            var loggingBehaviourType = behaviour
                .MakeGenericType(requestType, responseType);

            serviceCollection.AddTransient(
                pipelineBehaviourType, loggingBehaviourType);

            return serviceCollection;
        }
    }
}