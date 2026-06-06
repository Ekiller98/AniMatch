using AniMatch.Application.Common.Models;
using MediatR;

namespace AniMatch.Application.Features.Anime.Queries.GetAnimeById
{
    public record GetAnimeByIdQuery(int Id) : IRequest<AnimeDetailsDto?>
    {
    }
}
