using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AniMatch.Application.Common.Interfaces.Persistence;
using MediatR;

namespace AniMatch.Application.Features.Anime.Queries.GetAnimeById
{
    public class GetAnimeByIdQueryHandler : IRequestHandler<GetAnimeByIdQuery, AnimeDetailsDto?>
    {
        private readonly IAnimeRepository _animeRepoistory;

        public GetAnimeByIdQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepoistory = animeRepository;
        }

        public async Task<AnimeDetailsDto?> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
