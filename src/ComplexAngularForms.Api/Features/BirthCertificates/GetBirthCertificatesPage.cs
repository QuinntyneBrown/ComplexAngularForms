using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ComplexAngularForms.Api.Extensions;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using ComplexAngularForms.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class GetBirthCertificatesPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<BirthCertificateDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;
        
            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from birthCertificate in _context.BirthCertificates
                    select birthCertificate;
                
                var length = await _context.BirthCertificates.CountAsync();
                
                var birthCertificates = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = birthCertificates
                };
            }
            
        }
    }
}
