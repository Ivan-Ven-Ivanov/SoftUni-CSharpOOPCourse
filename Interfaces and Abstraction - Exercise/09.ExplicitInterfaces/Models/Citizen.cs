﻿using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        private const string NamePrefixes = "Mr/Ms/Mrs ";
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; private set; }
        public string Country { get; private set; }

        public int Age { get; private set; }

        string IPerson.GetName()
            => Name;

        string IResident.GetName()
            => $"{NamePrefixes}{Name}";
    }
}
