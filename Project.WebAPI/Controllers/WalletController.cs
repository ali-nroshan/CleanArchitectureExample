using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.DTOs.Wallet;
using Project.Application.Features.Wallet.Requests.Commands;
using Project.Application.Features.Wallet.Requests.Queries;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetWalletsAsync()
        {
            var response = await _mediator.Send(new GetWalletsQuery());
            return response.Match(Ok, HandleProblems);
        }

        [HttpGet("{walletId}")]
        public async Task<IActionResult> GetWalletAsync(Guid walletId)
        {
            var response = await _mediator.Send(new GetWalletByIdQuery(walletId));
            return response.Match(Ok, HandleProblems);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalletAsync([FromBody] WalletDto walletDto)
        {
            var response = await _mediator.Send(new CreateWalletCommand(walletDto));
            return response.Match(result => Ok(), HandleProblems);
        }

        private IActionResult HandleProblems(List<Error> errors)
        {
            var first = errors[0];

            var statusCode = first.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: first.Description);
        }
    }
}