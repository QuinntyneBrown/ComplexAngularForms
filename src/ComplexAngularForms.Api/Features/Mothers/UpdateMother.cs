using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class UpdateMother
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
                var mother = await _context.Mothers.SingleAsync(x => x.ParentId == request.Mother.ParentId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Mother = mother.ToDto()
                };
            }
            
        }
    }
}
