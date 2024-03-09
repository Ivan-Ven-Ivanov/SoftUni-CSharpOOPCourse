using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private const int AddIndex = 0;
        private const int RemoveIndex = 0;
        private readonly List<string> collection;
        public MyList() 
        {
            collection = new List<string>();
        }

        public int Used => collection.Count;

        public int Add(string item)
        {
            collection.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string elementToRemove = null;

            if (collection.Count > 0)
            {
                elementToRemove = collection[RemoveIndex];

                collection.RemoveAt(RemoveIndex);
            }

            return elementToRemove;
        }
    }
}
