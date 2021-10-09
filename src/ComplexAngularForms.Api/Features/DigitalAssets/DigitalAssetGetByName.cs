using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComplexAngularForms.Api.Features
{
    public class GetDigitalAssetByFilename
    {
        public class Request : IRequest<Response>
        {
            public string Filename { get; set; }
        }

        public class Response : ResponseBase
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComplexAngularFormsDbContext _context;

            public Handler(IComplexAngularFormsDbContext context)
                => _context = context;
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    DigitalAsset = (await _context.DigitalAssets
                    .SingleOrDefaultAsync(x => x.Name == request.Filename))
                    .ToDto()
                };
            }
        }
    }
}
