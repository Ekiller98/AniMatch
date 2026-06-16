using AniMatch.Application.Common.Models.Battles;
using MediatR;

namespace AniMatch.Application.Features.Battles.Queries
{
    public record GetBattleFeedQuery : IRequest<List<BattleFeedItemDto>>
    {
    }
}
