using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int AddIndex = 0;
        private readonly List<string> collection;
        public AddRemoveCollection()
        {
            collection = new List<string>();
        }
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
                elementToRemove = collection[collection.Count - 1];

                collection.RemoveAt(collection.Count - 1);
            }

            return elementToRemove;
        }
    }
}
