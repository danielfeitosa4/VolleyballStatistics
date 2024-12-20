﻿using VolleyballStatistics.Domain.Enums;
using VolleyballStatistics.Domain.Seedwork;

namespace VolleyballStatistics.Domain.Entities
{
    public sealed class Athlete : Person
    {
        public Athlete() { } // Para frameworks de persistência

        public Athlete(string name, string surname, string email, Gender gender, DateTime dateOfBirth, string phone) : base(name, surname, email, gender, dateOfBirth, phone)
        {

        }

        public string PositionOnCourt { get; private set; }
    }
}
