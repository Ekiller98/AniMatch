using AniMatch.Application.Common.Models.Battles;
using AniMatch.Application.Features.Battles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace AniMatch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BattlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BattleFeedItemDto>>> GetBattleFeed(CancellationToken cancellation)
        {
            var battleFeed = await _mediator.Send(new GetBattleFeedQuery(), cancellation);

            return Ok(battleFeed);
        }
    }
}
