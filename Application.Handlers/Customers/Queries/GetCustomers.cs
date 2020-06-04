using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Customers.Queries
{
    public static class GetCustomers
    {
        public class Request : IRequest<CommandResponse<Response>>
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
            public IEnumerable<CustomerModel> CustomerCollection { get; set; }

            public class CustomerModel
            {
                public Guid Id { get; set; }

                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string PhoneNumber { get; set; }
                public string Email { get; set; }

                public DateTime? BirthDay { get; set; }
                public DateTime RegistrationDate { get; set; }
            }
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
                var customers = await _context.Customers
                    .ProjectTo<Response.CustomerModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);
                return CommandResponse<Response>.Success(new Response
                {
                    CustomerCollection = customers
                });
            }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Customer, Response.CustomerModel>();
            }
        }
    }
}