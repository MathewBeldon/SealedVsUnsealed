using MediatR;
using Microsoft.AspNetCore.Mvc;
using SealedVsUnsealed.Performance.Features.Sealed;
using SealedVsUnsealed.Performance.Features.Unsealed;
using SealedVsUnsealed.Performance.Models.Sealed;
using SealedVsUnsealed.Performance.Models.Unsealed;

namespace SealedVsUnsealed.Performance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SealedModel _sealedModel = new();
        private readonly UnsealedModel _unsealedModel = new();

        public TestController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("unsealed/virtual/mediator")]
        public async Task<IActionResult> UnsealedVirtualMediator()
        {
            return Ok(await _mediator.Send(new UnsealedVirtualRequest(new UnsealedModel())));
        }

        [HttpGet("sealed/virtual/mediator")]
        public async Task<IActionResult> SealedVirtualMediator()
        {
            return Ok(await _mediator.Send(new SealedVirtualRequest(new SealedModel())));
        }

        [HttpGet("unsealed/virtual")]
        public IActionResult UnsealedVirtual()
        {
            return Ok(_unsealedModel.Virtual() + 10);
        }

        [HttpGet("sealed/virtual")]
        public IActionResult SealedVirtual()
        {
            return Ok(_sealedModel.Virtual() + 10);
        }

        [HttpGet("unsealed")]
        public IActionResult Unsealed()
        {
            return Ok(_unsealedModel.Normal() + 10);
        }

        [HttpGet("sealed")]
        public IActionResult Sealed()
        {
            return Ok(_sealedModel.Normal() + 10);
        }

        [HttpGet("unsealed/mediator")]
        public async Task<IActionResult> UnsealedMediator()
        {
            return Ok(await _mediator.Send(new UnsealedRequest(new UnsealedModel())));
        }

        [HttpGet("sealed/mediator")]
        public async Task<IActionResult> SealedMediator()
        {
            return Ok(await _mediator.Send(new SealedRequest(new SealedModel())));
        }
    }
}