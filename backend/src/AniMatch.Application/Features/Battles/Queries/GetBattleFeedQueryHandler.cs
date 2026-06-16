

using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Application.Common.Models.Battles;
using MediatR;

namespace AniMatch.Application.Features.Battles.Queries
{
    public class GetBattleFeedQueryHandler : IRequestHandler<GetBattleFeedQuery, List<BattleFeedItemDto>>
    {
        private readonly IBattleRepository _battleRepository;
            
        public GetBattleFeedQueryHandler(IBattleRepository battleRepository)
        {
            _battleRepository = battleRepository;
        }

        public async Task<List<BattleFeedItemDto>> Handle(GetBattleFeedQuery request, CancellationToken cancellation)
        {
            var activeBattles = await _battleRepository.GetActiveBattlesAsync(cancellation);

           var battleFeed = activeBattles.Select(battle => new BattleFeedItemDto
                {
                    Id = battle.Id,
                    Prompt = battle.Prompt.Description,
                    Category = battle.Prompt.Category,
                    AnimeA = new BattleAnimeOptionDto
                    {
                        Id = battle.AnimeA.Id,
                        AniListId =battle.AnimeA.AniListId,
                        Title = battle.AnimeA.TitleEnglish ?? battle.AnimeA.TitleRomaji,
                        CoverImageUrl = battle.AnimeA.CoverImageUrl
                    },
                   AnimeB = new BattleAnimeOptionDto
                   {
                       Id = battle.AnimeB.Id,
                       AniListId = battle.AnimeB.AniListId,
                       Title = battle.AnimeB.TitleEnglish ?? battle.AnimeB.TitleRomaji,
                       CoverImageUrl = battle.AnimeB.CoverImageUrl
                   },
                   CreatedAt = battle.CreatedAt
                })
            .ToList();

            return battleFeed;
        }
    }
}
