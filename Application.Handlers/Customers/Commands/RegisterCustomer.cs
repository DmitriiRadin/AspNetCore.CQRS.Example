using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Handlers.Customers.Commands
{
    public static class RegisterCustomer
    {
        public class Request : IRequest<Response>
        {

        }

        public class RequestValidator
        {

        }

        public class Response
        {

        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }

        public class Mapping
        {
            public Mapping()
            {
                
            }
        }
    }
}
