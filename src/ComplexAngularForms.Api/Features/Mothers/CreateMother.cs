using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Models;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;

namespace ComplexAngularForms.Api.Features
{
    public class CreateMother
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Mother).NotNull();
                RuleFor(request => request.Mother).SetValidator(new MotherValidator());
            }
        }

        public class Request: IRequest<Response>
        {
            public MotherDto Mother { get; set; }
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
                var mother = new Mother(new(
                    request.Mother.Firstname,
                    request.Mother.Lastname,
                    request.Mother.DateOfBirth,
                    request.Mother.MaidenName
                    ));
                
                _context.Mothers.Add(mother);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Mother = mother.ToDto()
                };
            }
            
        }
    }
}
