using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using ComplexAngularForms.Api.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ComplexAngularForms.Api.Features
{
    public class CreateBirthCertificate
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
                var birthCertificate = new BirthCertificate(new(
                    request.BirthCertificate.Firstname,
                    request.BirthCertificate.Lastname,
                    request.BirthCertificate.Email,
                    request.BirthCertificate.City,
                    request.BirthCertificate.Province,
                    request.BirthCertificate.DateOfBirth,
                    request.BirthCertificate.FatherId,
                    request.BirthCertificate.MotherId
                    ));
                
                _context.BirthCertificates.Add(birthCertificate);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    BirthCertificate = birthCertificate.ToDto()
                };
            }
            
        }
    }
}
