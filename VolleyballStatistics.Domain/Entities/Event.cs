using VolleyballStatistics.Domain.Enums;
using VolleyballStatistics.Domain.Seedwork;

namespace VolleyballStatistics.Domain.Entities
{
    public class Event : BaseEntity
    {
        public Event(string title, DateTime date, string nameTeamOne, string nameTeamTwo, int numberOfSets, ICollection<Set> sets, EventType eventType, string location)
        {
            Title = title;
            Date = date;
            NameTeamOne = nameTeamOne;
            NameTeamTwo = nameTeamTwo;
            NumberOfSets = numberOfSets;
            Sets = sets;
            EventType = eventType;
            Location = location;
        }

        public string Title { get; private set; }
        public DateTime Date { get; private set; }

        // Nomes das equipes
        public string NameTeamOne { get; private set; }
        public string NameTeamTwo { get; private set; }

        // Pontuação e resultado final
        public int? WinningTeam { get; private set; } // 1 ou 2 para indicar o vencedor (ou null se não finalizado)
        public int NumberOfSets { get; private set; } // Define se o jogo será de 3 ou 5 sets
        public ICollection<Set> Sets { get; private set; } = new List<Set>();

        public EventType EventType { get; private set; }
        public string Location { get; private set; }
        public ICollection<EventParticipation> Participations { get; set; } = new List<EventParticipation>();

        public void AddParticipation(EventParticipation participation)
        {
            Participations.Add(participation);
        }

        public void SetWinner()
        {
            // Contabilizar os sets vencidos por cada equipe
            var setsWonTeamOne = Sets.Count(s => s.WinnerSet == 1);
            var setsWonTeamTwo = Sets.Count(s => s.WinnerSet == 2);

            // Condição para determinar vencedor com base no número de sets possíveis
            if (setsWonTeamOne >= (NumberOfSets / 2 + 1) || setsWonTeamTwo >= (NumberOfSets / 2 + 1))
            {
                WinningTeam = setsWonTeamOne > setsWonTeamTwo ? 1 : 2;
            }
        }

    }
}
