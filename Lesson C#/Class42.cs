namespace CSLight
{
    internal class Class42
    {
        public static void Main()
        {
            Market market = new Market();
            market.Work();
        }

        class Market
        {
            private Seller _seller;
            private Player _player;

            public Market()
            {
                _seller = new Seller(0, GetListProducts());
                _player = new Player(300, new List<Products>());
            }

            public void Work()
            {
                const string BuyItem = "1";
                const string ShowSellerDesk = "2";
                const string ShowCustomerRucksackAndMoney = "3";
                const string MenuExit = "4";

                bool isWorking = true;

                while (isWorking)
                {
                    if (_player.Money > 0)
                    {
                        Console.WriteLine($"{BuyItem} - купить товар. " +
                        $"\n{ShowSellerDesk} - показать товары продавца" +
                        $"\n{ShowCustomerRucksackAndMoney} - показать ваш рюкзак и деньги," +
                        $"\n{MenuExit} - выход.");
                        Console.WriteLine("Выберите пункт меню ");

                        string input = Console.ReadLine();

                        switch (input)
                        {
                            case BuyItem:
                                Trade();
                                break;

                            case ShowSellerDesk:
                                _seller.OnCounter();
                                break;

                            case ShowCustomerRucksackAndMoney:
                                _player.OnPlayer();
                                break;

                            case MenuExit:
                                isWorking = false;
                                break;

                            default:
                                Console.WriteLine("Неправильно выбран пункт меню! ");
                                Console.ReadKey();
                                break;
                        }

                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("У вас нет денег");
                        isWorking = false;
                        _player.OnPlayer();
                    }
                }

                Console.ReadKey();
            }

            private void Trade()
            {
                _player.Buy(_seller.GiveItem(_player.ShowAllProduct(), _player.Money, out Products item), item);
            }

            private List<Products> GetListProducts()
            {
                List<Products> products = new List<Products>();

                products.Add(new Products("Сыр", 40));
                products.Add(new Products("чай", 70));
                products.Add(new Products("вода", 30));
                products.Add(new Products("мясо", 200));
                products.Add(new Products("яйца", 100));

                return products;
            }
        }
    }

    class People
    {
        public int Money { get; set; }

        public List<Products> _products = new List<Products>();

        public People(int money, List<Products> products)
        {
            Money = money;
            _products = products;
        }
    }

    class Player : People
    {
        public Player(int money, List<Products> products) : base(money, products)
        {
            Money = money;
        }

        public int ToPay(Products item)
        {
            Money -= item.Price;
            return Money;
        }

        public string ShowAllProduct()
        {
            Console.WriteLine("Введите наименование товара, который вы решили купить");
            string input = Console.ReadLine();

            return Console.ReadLine();
        }

        public void Buy(bool isBuying, Products item)
        {
            if (isBuying)
            {
                _products.Add(item);
                ToPay(item);
            }
        }

        public void OnPlayer()
        {
            Console.WriteLine($"Ваше количество денег - {Money}");
            Console.WriteLine("В вашем рюкзаке:");

            foreach (var item in _products)
            {
                item.ShowProduct();
            }

            Console.ReadKey();
        }
    }

    class Seller : People
    {
        public Seller(int money, List<Products> products) : base(money, products)
        {
            Money = money;
            _products = products;
        }

        public bool GiveItem(string choosenItem, int money, out Products item)
        {
            bool isGiveItem = false;

            isGiveItem = Sell(choosenItem, money, out item);

            return isGiveItem;
        }

        public void OnCounter()
        {
            Console.WriteLine($"У продавца количество денег - {Money}");
            Console.WriteLine("У продавца на прилавке:");

            foreach (Products products in _products)
            {
                products.ShowProduct();
            }

            Console.ReadKey();
        }

        public bool Sell(string choosenItem, int money, out Products item)
        {
            bool isSell = false;
            bool isCorrectChoice = TryFindItem(choosenItem);
            item = null;

            if (isCorrectChoice)
            {
                for (int i = 0; i < _products.Count; i++)
                {
                    if (_products[i].Product.ToLower() == choosenItem.ToLower())
                    {
                        if (money >= _products[i].Price)
                        {
                            item = _products[i];
                            Money += _products[i].Price;
                            money -= _products[i].Price;
                            _products.RemoveAt(i);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("У игрока не достаточно денег");
                            Console.ReadKey();
                        }
                    }
                }
            }
            else if (isCorrectChoice != true)
            {
                Console.WriteLine("У продавца в наличии нет данного товара!");
                Console.ReadKey();
            }

            return false;
        }

        private bool TryFindItem(string choosenItem)
        {
            bool isCorrectChoice = false;

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Product.ToLower() == choosenItem.ToLower())
                {
                    isCorrectChoice = true;
                }
            }

            return isCorrectChoice;
        }
    }

    class Products
    {
        public string Product { get; private set; }
        public int Price { get; private set; }

        public Products(string product, int price)
        {
            Product = product;
            Price = price;
        }

        public void ShowProduct()
        {
            Console.WriteLine($"Предмет - {Product}, стоимость - {Price} рублей");
        }
    }
}
