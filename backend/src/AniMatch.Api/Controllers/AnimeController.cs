using MediatR;
using Microsoft.AspNetCore.Mvc;
using AniMatch.Application.Features.Anime.Queries.GetAnimeById;
using AniMatch.Application.Features.Anime.Queries.SearchAnime;
using AniMatch.Application.Features.Anime.Queries.ExternalSearchAnime;
using AniMatch.Application.Features.Anime.Commands.ExternalAnimeImport;
using AniMatch.Application.Common.Models.Anime;

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
        public async Task<ActionResult<List<AnimeSearchResultDto>>> Search([FromQuery] string query, CancellationToken cancellation)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query is required");

            }

            var animeList = await _mediator.Send(new SearchAnimeQuery(query), cancellation);

            return Ok(animeList);
        }

        //regular search now calls aniList client so this can be deleted upon MVP
        [HttpGet("external-search")]
        public async Task<ActionResult<List<AniListAnimeDto>>> ExternalSearch([FromQuery] string query, CancellationToken cancellation)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query is required");

            }

            var externalAnimeList = await _mediator.Send(new ExternalSearchAnimeQuery(query), cancellation);

            return Ok(externalAnimeList);
        }

        [HttpPost("import/{aniListId:int}")]
        public async Task<ActionResult<AnimeDetailsDto>> ImportAnimeByExternalId(int aniListId, CancellationToken cancellation)
        {
            var anime = await _mediator.Send(new ImportExternalAnimeCommand(aniListId), cancellation);

            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime);
        }
    }
}
