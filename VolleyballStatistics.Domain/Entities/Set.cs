using VolleyballStatistics.Domain.Seedwork;

namespace VolleyballStatistics.Domain.Entities
{
    public class Set : BaseEntity
    {
        public Set(Event @event, int numberSet, int scoreTeamOne, int scoreTeamTwo)
        {
            Event = @event;
            NumberSet = numberSet;
            ScoreTeamOne = scoreTeamOne;
            ScoreTeamTwo = scoreTeamTwo;
        }

        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public int NumberSet { get; private set; }
        public int ScoreTeamOne { get; private set; }
        public int ScoreTeamTwo { get; private set; }

        // Determina o vencedor do set
        public int WinnerSet => ScoreTeamOne > ScoreTeamTwo ? 1 : 2; // 1 ou 2 para indicar a equipe vencedora
    }
}
