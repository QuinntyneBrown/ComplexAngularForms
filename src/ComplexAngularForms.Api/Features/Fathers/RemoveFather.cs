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
    public class RemoveFather
    {
        public class Request: IRequest<Response>
        {
            public Guid FatherId { get; set; }
        }

        public class Response: ResponseBase
        {
            public FatherDto Father { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;
        
            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var father = await _context.Fathers.SingleAsync(x => x.FatherId == request.FatherId);
                
                _context.Fathers.Remove(father);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Father = father.ToDto()
                };
            }
            
        }
    }
}
