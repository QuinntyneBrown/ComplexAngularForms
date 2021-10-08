using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class GetBirthCertificates
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<BirthCertificateDto> BirthCertificates { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;
        
            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    BirthCertificates = await _context.BirthCertificates.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
