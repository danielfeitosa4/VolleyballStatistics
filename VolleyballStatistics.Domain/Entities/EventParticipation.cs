using VolleyballStatistics.Domain.Enums;
using VolleyballStatistics.Domain.Seedwork;

namespace VolleyballStatistics.Domain.Entities
{
    public sealed class EventParticipation : BaseEntity
    {
        public EventParticipation() { } // Para frameworks de persistência

        public EventParticipation(Person person, Event @event, Paper paper)
        {
            Person = person;
            Event = @event;
            Paper = paper;
        }

        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public Paper Paper { get; private set; }
        public ICollection<PlayerStatistics> Statisticss { get; set; } = new HashSet<PlayerStatistics>();

        public void AddStatistic(PlayerStatistics statistic)
        {
            Statisticss.Add(statistic);
        }
    }
}
