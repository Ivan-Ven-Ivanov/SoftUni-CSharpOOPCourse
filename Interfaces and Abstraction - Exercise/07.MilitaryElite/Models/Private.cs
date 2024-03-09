using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public decimal Salary { get; private set; }
        public override string ToString()
            => base.ToString() + $" Salary: {Salary:F2}";
    }
}
