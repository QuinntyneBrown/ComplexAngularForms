using System.Net;
using System.Threading.Tasks;
using ComplexAngularForms.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComplexAngularForms.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotherController
    {
        private readonly IMediator _mediator;

        public MotherController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{motherId}", Name = "GetMotherByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMotherById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMotherById.Response>> GetById([FromRoute]GetMotherById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Mother == null)
            {
                return new NotFoundObjectResult(request.MotherId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetMothersRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMothers.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMothers.Response>> Get()
            => await _mediator.Send(new GetMothers.Request());
        
        [HttpPost(Name = "CreateMotherRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateMother.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateMother.Response>> Create([FromBody]CreateMother.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetMothersPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMothersPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMothersPage.Response>> Page([FromRoute]GetMothersPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateMotherRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateMother.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateMother.Response>> Update([FromBody]UpdateMother.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{motherId}", Name = "RemoveMotherRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveMother.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveMother.Response>> Remove([FromRoute]RemoveMother.Request request)
            => await _mediator.Send(request);
        
    }
}
