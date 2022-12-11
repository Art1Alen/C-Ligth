namespace CSLight
{
    internal class Class39
    {
        static void Main(string[] args)
        {
            int countVariety = 4; 
            int countMeaning = 4; 
            const string TakeCard = "1";
            const string Finish = "2";

            bool isPlay = true;

            List<Card> cards = new List<Card>();

            Deck deck = new Deck(cards);
            Player player = new Player();

            for (int i = 0; i < countVariety; i++)
            {
                for (int j = 0; j < countMeaning; j++)
                {
                    cards.Add(new Card((Variety)i,(Meaning)j));
                }
            }

            while (isPlay)
            {
                Console.Clear();
                Console.WriteLine($"{TakeCard} - взять карту,\n{Finish} - закончить");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case TakeCard:
                        player.ReceiveCard(deck.GetCard());
                        break;

                    case Finish:
                        player.ShowScore();
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
        private Deck _cards;

        public Player()
        {
            _cards = new Deck(new List<Card>());
        }

        public void ReceiveCard(Card card)
        {
            _cards.TakeCard(card);
        }

        public void ShowScore()
        {
            _cards.ShowInfo();
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _cards;

        int minNumber = 0;

        public Deck(List<Card> cards)
        {
            _cards = cards;
        }

        public Card GetCard()
        {
            if (_cards.Count > 0)
            {
                int cardNumber = _random.Next(minNumber, _cards.Count);

                Card card = _cards[cardNumber];
                _cards.RemoveAt(cardNumber);
                return card;
            }
            Console.WriteLine("карты в колоде закончились");
            Console.ReadKey();
            return null;
        }

        public void TakeCard(Card card)
        {
            _cards.Add(card);
        }
        public void ShowInfo()
        {
            Console.WriteLine("У вас на руках:");

            foreach (var card in _cards)
                Console.WriteLine(" {0}  {1} ", card.Mapping, card.Suit);
        }
    }

    class Card
    {
        public Variety Suit { get; private set; }
        public Meaning Mapping { get; private set; }

        public Card(Variety suit, Meaning mapping)
        {
            Suit = suit;
            Mapping = mapping;
        }
    }

    enum Variety
    {
        пики,
        крести,
        черви,
        буби
    }

    enum Meaning
    {
        шест,
        сем,
        восем,
        девят,
        десят,
        валет,
        дама,
        король,
        туз
    }
}

