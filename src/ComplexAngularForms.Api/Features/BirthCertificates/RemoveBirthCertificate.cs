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
    public class RemoveBirthCertificate
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
                var birthCertificate = await _context.BirthCertificates.SingleAsync(x => x.BirthCertificateId == request.BirthCertificateId);
                
                _context.BirthCertificates.Remove(birthCertificate);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    BirthCertificate = birthCertificate.ToDto()
                };
            }
            
        }
    }
}
