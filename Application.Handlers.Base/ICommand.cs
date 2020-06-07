using MediatR;

namespace Application.Handlers.Base
{
    public interface ICommand<TResponse> : IRequest<CommandResponse<TResponse>>
    {

    }
}