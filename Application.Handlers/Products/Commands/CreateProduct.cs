using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Handlers.Base;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Products.Commands
{
    public static class CreateProduct
    {
        public class Request : ICommand<Response>
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            public RequestValidator()
            {
                RuleFor(p => p.Title).NotEmpty();
                RuleFor(p => p.Description).NotEmpty();
            }
        }

        public class Response
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
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
                var product = _mapper.Map<Product>(request);

                _context.Add(product);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException exception)
                {
                    return CommandResponse<Response>.Fail(exception);
                }

                return CommandResponse<Response>.Success(_mapper.Map<Response>(product));
            }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Request, Product>();
                CreateMap<Product, Response>();
            }
        }
    }
}