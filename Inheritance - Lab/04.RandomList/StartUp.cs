namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Ivan");
            list.Add("Maria");
            list.Add("Pesho");
            list.Add("Gosho");

            Console.WriteLine(list.RandomString()); 
        }
    }
}