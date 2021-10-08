using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class GetFatherById
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
                return new () {
                    Father = (await _context.Fathers.SingleOrDefaultAsync(x => x.FatherId == request.FatherId)).ToDto()
                };
            }
            
        }
    }
}
