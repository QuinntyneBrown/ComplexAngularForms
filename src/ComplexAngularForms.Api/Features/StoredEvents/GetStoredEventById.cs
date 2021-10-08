using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class GetStoredEventById
    {
        public class Request: IRequest<Response>
        {
            public Guid StoredEventId { get; set; }
        }

        public class Response: ResponseBase
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;
        
            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    StoredEvent = (await _context.StoredEvents.SingleOrDefaultAsync(x => x.StoredEventId == request.StoredEventId)).ToDto()
                };
            }
            
        }
    }
}
