using VolleyballStatistics.Domain.Enums;

namespace VolleyballStatistics.Domain.Seedwork
{
    public abstract class Person : BaseEntity
    {
        protected Person(string name, string surname, string email, Gender gender, DateTime dateOfBirth, string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Phone { get; private set; }
    }
}
