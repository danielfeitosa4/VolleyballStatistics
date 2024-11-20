using VolleyballStatistics.Domain.Seedwork;

namespace VolleyballStatistics.Domain.Entities
{
    public sealed class Report : BaseEntity
    {
        public Report() { } // Para frameworks de persistência

        public Report(Event @event, Person athlete, int totallyRight, int totallyWrong)
        {
            Event = @event;
            Athlete = athlete;
            TotallyRight = totallyRight;
            TotallyWrong = totallyWrong;
        }

        public int EventId { get; set; }
        public Event Event { get; set; }
        public int AthleteId { get; set; }
        public Person Athlete { get; set; }
        public int TotallyRight { get; private set; }
        public int TotallyWrong { get; private set; }
    }
}
