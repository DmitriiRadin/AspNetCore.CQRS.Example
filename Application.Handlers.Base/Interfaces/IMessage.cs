using MediatR;

namespace Application.Handlers.Base.Interfaces
{
    public interface IMessage<TResponse> : IRequest<CommandResponse<TResponse>>
    {
    }
}