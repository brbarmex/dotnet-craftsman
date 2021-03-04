using System;
using System.Linq;
using System.Threading.Tasks;
using Craftsman.Application.Boundaries.Customer.Commands;
using Craftsman.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Craftsman.Api.Controllers
{
    [ApiController]
    [Route("customer")]
    public sealed class CustomerConstroller : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IMediator _mediator, CreateCommand request)
        => (await _mediator.Send(request).ConfigureAwait(false)).Match<IActionResult>
        (
            Notifications => BadRequest(Notifications.Select(s => s.Message)),
            Success => Ok(Success),
            Exception => StatusCode(StatusCodes.Status500InternalServerError, Exception.Message)
        );

        [HttpPatch("address")]
        public async Task<IActionResult> AddressPatch([FromServices] IMediator _mediator, EditAddressCustomerCommand request)
        => (await _mediator.Send(request).ConfigureAwait(false)).Match<IActionResult>
        (
            Notifications => BadRequest(Notifications.Select(s => s.Message)),
            Success => Ok(Success),
            Exception => StatusCode(StatusCodes.Status500InternalServerError, Exception.Message)
        );
    }
}