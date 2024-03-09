namespace AuthorProblem
{
    [Author("Ivan")]
    public class StartUp
    {
        [Author("Ivan1")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}