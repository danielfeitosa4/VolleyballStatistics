using VolleyballStatistics.Domain.Enums;

namespace VolleyballStatistics.Domain.Seedwork
{
    public abstract class Person : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Surname { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Phone { get; private set; } = null!;
    }
}
