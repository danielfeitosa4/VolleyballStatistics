using VolleyballStatistics.Domain.Enums;
using VolleyballStatistics.Domain.Seedwork;

namespace VolleyballStatistics.Domain.Entities
{
    public sealed class PlayerStatistics : BaseEntity
    {
        public PlayerStatistics() { } // Para frameworks de persistência

        public PlayerStatistics(EventParticipation eventParticipation, ActionType actionType, int right, int wrong)
        {
            EventParticipation = eventParticipation;
            ActionType = actionType;
            Right = right;
            Wrong = wrong;
        }

        public int EventParticipationId { get; set; }
        public EventParticipation EventParticipation { get; set; }
        public ActionType ActionType { get; private set; }
        public int Right { get; private set; }
        public int Wrong { get; private set; }

        public static Dictionary<ActionType, (int Right, int Wrong)> CalculateTotals(IEnumerable<PlayerStatistics> statistics)
        {
            return statistics
                    .GroupBy(e => e.ActionType)
                    .ToDictionary(
                        g => g.Key,
                        g => (
                            Acertivas: g.Sum(e => e.Right),
                            Erradas: g.Sum(e => e.Wrong)
                        )
                    );
        }
    }
}
