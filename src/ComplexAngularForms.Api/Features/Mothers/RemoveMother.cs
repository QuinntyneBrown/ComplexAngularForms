using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using ComplexAngularForms.Api.Models;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;

namespace ComplexAngularForms.Api.Features
{
    public class RemoveMother
    {
        public class Request: IRequest<Response>
        {
            public Guid MotherId { get; set; }
        }

        public class Response: ResponseBase
        {
            public MotherDto Mother { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;
        
            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var mother = await _context.Mothers.SingleAsync(x => x.MotherId == request.MotherId);
                
                _context.Mothers.Remove(mother);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Mother = mother.ToDto()
                };
            }
            
        }
    }
}
