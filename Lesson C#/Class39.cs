namespace CSLight
{
    internal class Class39
    {
        static void Main(string[] args)
        {
            const string TakeCard = "1";
            const string Finish = "2";

            bool isPlay = true;

            Deck deck = new Deck();
            Player player = new Player();

            while (isPlay)
            {
                Console.Clear();
                Console.WriteLine($"{TakeCard} - взять карту,\n{Finish} - Посмотреть Карты в Руках");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case TakeCard:
                        player.TakeCard(deck.GiveCard());
                        break;

                    case Finish:
                        player.ShowCards();
                        isPlay = false;
                        break;

                    default:
                        Console.WriteLine("не понимаю, повторите");
                        break;
                }
            }
        }
    }

    class Player
    {
        private List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>();
        }

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }

        public void ShowCards()
        {
            foreach (Card card in _cards)
            {
                card.ShowInfo();
            }
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            CreateCards();
        }

        public Card GiveCard()
        {
            if (_cards.Count > 0)
            {
                int index = _random.Next(_cards.Count);

                Card card = _cards[index];
                _cards.Remove(card);

                return card;
            }
            else
            {
                Console.WriteLine("карты в колоде закончились");
                Console.ReadKey();

                Card card = null;

                return card;
            }
        }

        private void CreateCards()
        {
            string[] suits = { "пик", "крест", "черв", "буби" };
            string[] names = { "6", "7", "8", "9", "10", "валент", "дама", "король", "туз" };

            for (int i = 0; i < names.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    _cards.Add(new Card(names[i], suits[j]));
                }
            }
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Name { get; private set; }

        public Card(string suit, string name)
        {
            Suit = suit;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} {Suit} ");
        }
    }
}

