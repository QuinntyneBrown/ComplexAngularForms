using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Models;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;

namespace ComplexAngularForms.Api.Features
{
    public class CreateFather
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Father).NotNull();
                RuleFor(request => request.Father).SetValidator(new FatherValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public FatherDto Father { get; set; }
        }

        public class Response: ResponseBase
        {
            public FatherDto Father { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;
        
            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var father = new Father();
                
                _context.Fathers.Add(father);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Father = father.ToDto()
                };
            }
            
        }
    }
}
