using MediatR;
using Microsoft.AspNetCore.Mvc;
using AniMatch.Application.Features.Anime.Queries.GetAnimeById;
using AniMatch.Application.Features.Anime.Queries.SearchAnime;



namespace AniMatch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimeController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimeDetailsDto>> GetById(int id, CancellationToken cancellation) 
        {
            var anime = await _mediator.Send(new GetAnimeByIdQuery(id), cancellation);

            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<AnimeSearchResultDto>>>Search([FromQuery]string query, CancellationToken cancellation)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query is required");

            }

            var animeList = await _mediator.Send(new SearchAnimeQuery(query), cancellation);

            return Ok(animeList);
        }
    }
}
