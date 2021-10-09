using System.Net;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComplexAngularForms.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FatherController
    {
        private readonly IMediator _mediator;

        public FatherController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{parentId}", Name = "GetFatherByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetFatherById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetFatherById.Response>> GetById([FromRoute]GetFatherById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Father == null)
            {
                return new NotFoundObjectResult(request.ParentId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetFathersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetFathers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetFathers.Response>> Get()
            => await _mediator.Send(new GetFathers.Request());
        
        [HttpPost(Name = "CreateFatherRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateFather.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateFather.Response>> Create([FromBody]CreateFather.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetFathersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetFathersPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetFathersPage.Response>> Page([FromRoute]GetFathersPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateFatherRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateFather.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateFather.Response>> Update([FromBody]UpdateFather.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{parentId}", Name = "RemoveFatherRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveFather.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveFather.Response>> Remove([FromRoute]RemoveFather.Request request)
            => await _mediator.Send(request);
        
    }
}
