﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base;
using Application.Handlers.Base.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Customers.Queries
{
    public static class GetCustomerById
    {
        public class Request : IQuery<Response>
        {
            public Guid Id { get; set; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
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

            public Handler(StoreDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CommandResponse<Response>> Handle(Request request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers
                    .ProjectTo<Response>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                return CommandResponse<Response>.Success(customer);
            }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Customer, Response>();
            }
        }
    }
}