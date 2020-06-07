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

namespace Application.Handlers.Orders.Commands
{
    public static class CreateOrder
    {
        public class Request : ICommand<Response>
        {
            public Guid CustomerId { get; set; }
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
            public Guid CustomerId { get; set; }
            public string Status { get; set; }
            public DateTime? InitialDate { get; set; }
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
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(p => p.Id == request.CustomerId, cancellationToken);

                if (customer == null)
                {
                    return CommandResponse<Response>.Fail(Failure.NotFound("Customer with such Id was not found"));
                }

                var order = new Order
                {
                    Customer = customer,
                    InitialDate = _dateTimeManager.Now()
                };

                _context.Add(order);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException exception)
                {
                    return CommandResponse<Response>.Fail(exception);
                }

                return CommandResponse<Response>.Success(_mapper.Map<Response>(order));
            }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Order, Response>();
            }
        }
    }
}