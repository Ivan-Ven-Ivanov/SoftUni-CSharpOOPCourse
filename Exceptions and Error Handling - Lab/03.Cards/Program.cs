namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] cardTokens = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string card in cardTokens)
            {
                string face = card.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                string suit = card.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

                try
                {
                    cards.Add(CreateCard(face, suit));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        private static Card CreateCard(string face, string suit)
            => new Card(face, suit);
    }

    public class Card
    {
        private readonly List<string> faces;
        private readonly List<string> suits;

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            faces = new List<string>()
            {
                "2","3","4","5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };
            suits = new List<string>()
            {
                "S", "H", "D", "C"
            };

            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get
            {
                return face;
            }
            set
            {
                if (!faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }

        public string Suit
        {
            get
            {
                return suit;
            }
            set
            {
                if (!suits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                suit = value;
            }
        }
        public override string ToString()
        {
            string suit = null;
            switch (Suit)
            {
                case "S":
                    suit = "\u2660";
                    break;
                case "H":
                    suit = "\u2665";
                    break;
                case "D":
                    suit = "\u2666";
                    break;
                case "C":
                    suit = "\u2663";
                    break;
            }

            return $"[{Face}{suit}]";
        }
    }
}