using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.IO.Interfaces;
using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            Dictionary<string, List<int>> addedIndexes = new()
            {
                {"AddCollection", new List<int>() },
                {"AddRemoveCollection", new List<int>() },
                {"MyList", new List<int>() }
            };

            Dictionary<string, List<string>> removedItems = new()
            {
                {"AddCollection", new List<string>() },
                {"AddRemoveCollection", new List<string>() },
                {"MyList", new List<string>() }
            };

            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] itemsToAdd = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in itemsToAdd)
            {
                addedIndexes["AddCollection"].Add(addCollection.Add(item));
                addedIndexes["AddRemoveCollection"].Add(addRemoveCollection.Add(item));
                addedIndexes["MyList"].Add(myList.Add(item));
            }

            int removeCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < removeCount; i++)
            {
                removedItems["AddRemoveCollection"].Add(addRemoveCollection.Remove());
                removedItems["MyList"].Add(myList.Remove());
            }

            writer.WriteLine(string.Join(" ", addedIndexes["AddCollection"]));
            writer.WriteLine(string.Join(" ", addedIndexes["AddRemoveCollection"]));
            writer.WriteLine(string.Join(" ", addedIndexes["MyList"]));

            writer.WriteLine(string.Join(" ", removedItems["AddRemoveCollection"]));
            writer.WriteLine(string.Join(" ", removedItems["MyList"]));
        }
    }
}
