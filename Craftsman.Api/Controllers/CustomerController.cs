using System.Threading.Tasks;
using Craftsman.Domain.Interfaces.ICustomer;
using Craftsman.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Craftsman.Api.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerConstroller : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices]ICreateCustomerService _useCase,NewCustomerCommand body)
        => (await _useCase.Execute(body).ConfigureAwait(false))
            .Match<IActionResult>
            (
                notifications => BadRequest(notifications),
                Success => Ok(Success),
                Exception => StatusCode(StatusCodes.Status500InternalServerError, Exception.Message)
            );
    }
}