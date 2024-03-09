namespace PersonsInfo
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
                Person person = new Person(peopleArguments[0], peopleArguments[1],
                    int.Parse(peopleArguments[2]), decimal.Parse(peopleArguments[3]));

                people.Add(person);
            }

            Team team = new Team("SoftUni");

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team.ToString());
        }
    }
}