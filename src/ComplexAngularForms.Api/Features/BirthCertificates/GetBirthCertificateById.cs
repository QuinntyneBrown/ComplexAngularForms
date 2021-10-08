using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class GetBirthCertificateById
    {
        public class Request: IRequest<Response>
        {
            public Guid BirthCertificateId { get; set; }
        }

        public class Response: ResponseBase
        {
            public BirthCertificateDto BirthCertificate { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;
        
            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    BirthCertificate = (await _context.BirthCertificates.SingleOrDefaultAsync(x => x.BirthCertificateId == request.BirthCertificateId)).ToDto()
                };
            }
            
        }
    }
}
