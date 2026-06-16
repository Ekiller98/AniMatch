using AniMatch.Application.Common.Models.Battles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace AniMatch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BattleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        
        public Task<ActionResult<List<BattleFeedItemDto>>> GetBattleFeed(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
