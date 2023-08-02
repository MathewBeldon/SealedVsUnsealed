using MediatR;
using Microsoft.AspNetCore.Mvc;
using SealedVsUnsealed.Performance.Features.Sealed;
using SealedVsUnsealed.Performance.Features.Unsealed;
using SealedVsUnsealed.Performance.Models.Sealed;
using SealedVsUnsealed.Performance.Models.Unsealed;

namespace SealedVsUnsealed.Performance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("unsealed")]
        public async Task<IActionResult> Unsealed()
        {
            return Ok(await _mediator.Send(new UnsealedRequest(new UnsealedModel() { Value = 10 })));
        }

        [HttpGet("sealed")]
        public async Task<IActionResult> Sealed()
        {
            return Ok(await _mediator.Send(new SealedRequest(new SealedModel() { Value = 10 })));
        }
    }
}