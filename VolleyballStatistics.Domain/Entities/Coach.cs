using VolleyballStatistics.Domain.Enums;
using VolleyballStatistics.Domain.Seedwork;

namespace VolleyballStatistics.Domain.Entities
{
    public sealed class Coach : Person
    {
        public Coach() { } // Para frameworks de persistência

        public Coach(string name, string surname, string email, Gender gender, DateTime dateOfBirth, string phone) : base(name, surname, email, gender, dateOfBirth, phone)
        {

        }

        public string Level { get; private set; }

        public void Lineup()
        {

        }
    }
}
