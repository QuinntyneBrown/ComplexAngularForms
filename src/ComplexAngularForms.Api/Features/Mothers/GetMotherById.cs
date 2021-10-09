using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class GetMotherById
    {
        public class Request: IRequest<Response>
        {
            public Guid ParentId { get; set; }
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
                return new () {
                    Mother = (await _context.Mothers.SingleOrDefaultAsync(x => x.ParentId == request.ParentId)).ToDto()
                };
            }
            
        }
    }
}
