﻿using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base;
using MediatR;

namespace Application.Handlers.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, CommandResponse<TResponse>>
    {
        public async Task<CommandResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<CommandResponse<TResponse>> next)
        {
            var response = await next();

            if (response.IsSuccess)
            {
                //todo some logic
            }

            return response;
        }
    }
}