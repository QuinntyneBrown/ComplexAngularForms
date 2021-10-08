using System.Net;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComplexAngularForms.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BirthCertificateController
    {
        private readonly IMediator _mediator;

        public BirthCertificateController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{birthCertificateId}", Name = "GetBirthCertificateByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBirthCertificateById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBirthCertificateById.Response>> GetById([FromRoute]GetBirthCertificateById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.BirthCertificate == null)
            {
                return new NotFoundObjectResult(request.BirthCertificateId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetBirthCertificatesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBirthCertificates.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBirthCertificates.Response>> Get()
            => await _mediator.Send(new GetBirthCertificates.Request());
        
        [HttpPost(Name = "CreateBirthCertificateRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBirthCertificate.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBirthCertificate.Response>> Create([FromBody]CreateBirthCertificate.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetBirthCertificatesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBirthCertificatesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBirthCertificatesPage.Response>> Page([FromRoute]GetBirthCertificatesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateBirthCertificateRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBirthCertificate.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBirthCertificate.Response>> Update([FromBody]UpdateBirthCertificate.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{birthCertificateId}", Name = "RemoveBirthCertificateRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveBirthCertificate.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveBirthCertificate.Response>> Remove([FromRoute]RemoveBirthCertificate.Request request)
            => await _mediator.Send(request);
        
    }
}
