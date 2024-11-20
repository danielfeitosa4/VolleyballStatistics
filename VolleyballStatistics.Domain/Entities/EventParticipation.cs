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

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public Paper Paper { get; private set; }
        public ICollection<PlayerStatistics> Statisticss { get; set; } = new HashSet<PlayerStatistics>();

        public void AddStatistic(PlayerStatistics statistic)
        {
            Statisticss.Add(statistic);
        }
    }
}
