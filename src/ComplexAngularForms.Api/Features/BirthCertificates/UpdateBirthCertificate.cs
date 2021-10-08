using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class UpdateBirthCertificate
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.BirthCertificate).NotNull();
                RuleFor(request => request.BirthCertificate).SetValidator(new BirthCertificateValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public BirthCertificateDto BirthCertificate { get; set; }
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
                var birthCertificate = await _context.BirthCertificates.SingleAsync(x => x.BirthCertificateId == request.BirthCertificate.BirthCertificateId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    BirthCertificate = birthCertificate.ToDto()
                };
            }
            
        }
    }
}
