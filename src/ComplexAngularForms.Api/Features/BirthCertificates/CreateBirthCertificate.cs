using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.DomainEvents;
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
            private readonly IOrchestrationHandler _orchestrationHandler;
        
            public Handler(IComplexAngularFormsDbContext context, IOrchestrationHandler orchestrationHandler)
            {
                _context = context;
                _orchestrationHandler = orchestrationHandler;
            }
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var startWith = new CreateParents(
                    request.BirthCertificate.Mother?.Firstname,
                    request.BirthCertificate.Mother?.Lastname,
                    request.BirthCertificate.Mother?.DateOfBirth,
                    request.BirthCertificate.Mother?.MaidenName,
                    request.BirthCertificate.Father?.Firstname,
                    request.BirthCertificate.Father?.Lastname,
                    request.BirthCertificate.Father?.DateOfBirth
                    );

                return await _orchestrationHandler.Handle<Response>(startWith, (ctx) => async message =>
                {
                    switch (message)
                    {
                        case CreatedParents @event:
                            var birthCertificate = new BirthCertificate(new(
                                request.BirthCertificate.Firstname,
                                request.BirthCertificate.Lastname,
                                request.BirthCertificate.Email,
                                request.BirthCertificate.City,
                                request.BirthCertificate.Province,
                                request.BirthCertificate.DateOfBirth,
                                @event.FatherId,
                                @event.MotherId
                                ));

                            _context.BirthCertificates.Add(birthCertificate);

                            await _context.SaveChangesAsync(cancellationToken);

                            ctx.SetResult(new()
                            {
                                BirthCertificate = birthCertificate.ToDto()
                            });
                            break;
                    }
                });
            }
            
        }
    }
}
