using ComplexAngularForms.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ComplexAngularForms.Api.Features
{
    public class UpdatePhoto
    {
        public class Request : IRequest<Response> {
            public Guid BirthCertificateId { get; set; }
            public Guid PhotoDigitalAssetId { get; set; }
        }

        public class Response
        {
            public BirthCertificateDto BirthCertificate { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;

            public Handler(IComplexAngularFormsDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var birthCertificate = await _context.BirthCertificates.SingleAsync(x => x.BirthCertificateId == request.BirthCertificateId);

                birthCertificate.Apply(new DomainEvents.UpdatePhoto(request.PhotoDigitalAssetId));

                await _context.SaveChangesAsync(cancellationToken);

                return new () { 
                    BirthCertificate = birthCertificate.ToDto()
                };
            }
        }
    }
}
