using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace AniMatch.Application.Features.Anime.Queries.GetAnimeById
{
    public record GetAnimeByIdQuery(int Id) : IRequest<AnimeDetailsDto?>
    {
    }
}
