using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base;
using Application.Handlers.Base.Interfaces;
using AutoMapper;
using FluentValidation;
using Infrastructure.Data;
using MediatR;

namespace Application.Handlers.Customers.Commands
{
    public static class EditCustomer
    {
        public class Request : ICommand<Response>
        {
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
            }
        }

        public class Response
        {
        }

        public class Handler : IRequestHandler<Request, CommandResponse<Response>>
        {
            private readonly StoreDbContext _context;
            private readonly IMapper _mapper;

            public Handler(StoreDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CommandResponse<Response>> Handle(Request request, CancellationToken cancellationToken)
            {
                return CommandResponse<Response>.Success(null);
            }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
            }
        }
    }
}