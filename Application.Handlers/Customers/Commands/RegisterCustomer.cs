using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Customers.Commands
{
    public static class RegisterCustomer
    {
        public class Request : IRequest<Response>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            public DateTime? BirthDay { get; set; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(p => p.FirstName).NotEmpty();
                RuleFor(p => p.LastName).NotEmpty();
                RuleFor(p => p.Email).NotEmpty();
            }
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