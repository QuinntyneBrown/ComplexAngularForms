using ComplexAngularForms.Api.Core;
using ComplexAngularForms.Api.Interfaces;
using ComplexAngularForms.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ComplexAngularForms.Api.Features
{
    public class RemoveDigitalAsset
    {
        public class Request : IRequest<Response>
        {
            public System.Guid DigitalAssetId { get; set; }
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
                var digitalAsset = await _context.DigitalAssets.SingleAsync(x => x.DigitalAssetId == request.DigitalAssetId);

                _context.DigitalAssets.Remove(digitalAsset);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    DigitalAsset = digitalAsset.ToDto()
                };
            }

        }
    }
}
