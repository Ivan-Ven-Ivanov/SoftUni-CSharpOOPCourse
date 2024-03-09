using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            MethodInfo[] methods = classType.GetMethods((BindingFlags)60);

            foreach (MethodInfo method in methods)
            {
                AuthorAttribute[] attributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();

                if (attributes.Length > 0)
                {
                    foreach (AuthorAttribute authorAttribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                    }
                }
            }


        }
    }
}
