using MediatR;

namespace Application.Handlers.Base
{
    public interface IQuery<TResponse> : IRequest<CommandResponse<TResponse>>
    {
    }
}