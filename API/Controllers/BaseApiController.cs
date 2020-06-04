using System;
using System.Net;
using Application.Handlers.Base;
using Application.Handlers.Base.Failures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IActionResult CommandResponse<T>(
            CommandResponse<T> response,
            HttpStatusCode onSuccessHttpCode = HttpStatusCode.OK,
            Func<Failure, HttpStatusCode> onFailureHttpCodeFunc = null)
        {
            if (response)
            {
                return StatusCode((int) onSuccessHttpCode, response.Payload);
            }

            var failureCode = onFailureHttpCodeFunc?.Invoke(response.Failure) ?? HttpStatusCode.BadRequest;

            return StatusCode((int) failureCode, response.Failure.FailureReason);
        }

        protected IActionResult CreatedCommandResponse<T>(
            CommandResponse<T> response)
        {
            return CommandResponse(response,
                HttpStatusCode.Created,
                failure => failure switch
                {
                    ConflictFailure _ => HttpStatusCode.Conflict,
                    _ => HttpStatusCode.BadRequest
                });
        }
    }
}