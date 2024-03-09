using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] animalTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalTokens[0];
                int age = int.Parse(animalTokens[1]);
                string gender = animalTokens[2];
                try
                {
                    switch (input)
                    {
                        case "Dog":
                            Dog dog = new(name, age, gender);
                            Console.WriteLine(dog);
                            break;
                        case "Cat":
                            Cat cat = new(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        case "Frog":
                            Frog frog = new(name, age, gender);
                            Console.WriteLine(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new(name, age);
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(name, age);
                            Console.WriteLine(tomcat);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                
            }
        }
    }
}
