using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Customers.Commands
{
    public static class RegisterCustomer
    {
        public class Request : IRequest<CommandResponse<Response>>
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
            public Guid Id { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            public DateTime? BirthDay { get; set; }
            public DateTime RegistrationDate { get; set; }
        }

        public class Handler : IRequestHandler<Request, CommandResponse<Response>>
        {
            private readonly StoreDbContext _context;
            private readonly IMapper _mapper;
            private readonly IDateTimeManager _dateTimeManager;

            public Handler(StoreDbContext context, IMapper mapper, IDateTimeManager dateTimeManager)
            {
                _context = context;
                _mapper = mapper;
                _dateTimeManager = dateTimeManager;
            }

            public async Task<CommandResponse<Response>> Handle(Request request, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<Customer>(request);
                customer.RegistrationDate = _dateTimeManager.Now();

                _context.Add(customer);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException exception)
                {
                    return CommandResponse<Response>.Fail(exception);
                }

                return CommandResponse<Response>.Success(_mapper.Map<Response>(customer));
            }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Request, Customer>();
                CreateMap<Customer, Response>();
            }
        }
    }
}