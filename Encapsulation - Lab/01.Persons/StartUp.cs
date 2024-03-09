namespace PeopleInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < peopleCount; i++)
            {
                string[] peopleArguments = Console.ReadLine().Split();
                Person person = new Person(peopleArguments[0], peopleArguments[1], int.Parse(peopleArguments[2]));
                people.Add(person);
            }

            people.OrderBy(p => p.FirstName)
                   .ThenBy(p => p.Age)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}