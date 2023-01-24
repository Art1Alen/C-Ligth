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
                _player = new Player(300, new List<Product>());
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
                _seller.ShowProducts();

                Console.WriteLine("Введите наименование товара, который вы решили купить");
                string input = Console.ReadLine();

                Product product = _seller.RequestProduct(input);
                int price = 0;

                if (product != null)
                {
                    price = product.Price;
                }

                if (_player.Money >= price)
                {
                    _player.Buy(product);
                    _seller.Sell(product);
                }
                else
                {
                    Console.WriteLine("Не хватает денег для покупки");
                }

                Console.ReadKey();
            }

            private List<Product> GetListProducts()
            {
                List<Product> products = new List<Product>();

                products.Add(new Product("Сыр", 40));
                products.Add(new Product("чай", 70));
                products.Add(new Product("вода", 30));
                products.Add(new Product("мясо", 200));
                products.Add(new Product("яйца", 100));

                return products;
            }
        }
    }
    class Human
    {
        public int Money { get; protected set; }

        protected List<Product> _products = new List<Product>();

        public Human(int money, List<Product> products)
        {
            Money = money;
            _products = products;
        }

        public void ShowProducts()
        {
            foreach (Product product in _products)
            {
                product.ShowInfo();
            }
        }
    }

    class Player : Human
    {
        public Player(int money, List<Product> products) : base(money, products)
        {
            Money = money;
        }

        public int ToPay(Product item)
        {
            Money -= item.Price;
            return Money;
        }       

        public void Buy(Product item)
        {
            _products.Add(item);
            ToPay(item);
        }

        public void OnPlayer()
        {
            Console.WriteLine($"Ваше количество денег - {Money}");
            Console.WriteLine("В вашем рюкзаке:");

            foreach (var item in _products)
            {
                item.ShowInfo();
            }

            Console.ReadKey();
        }
    }

    class Seller : Human
    {
        public Seller(int money, List<Product> products) : base(money, products)
        {
            Money = money;
            _products = products;
        }

        public Product RequestProduct(string choosenItem)
        {
            Product product = null;

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Name == choosenItem)
                {
                    product = _products[i];

                    return product;
                }
            }

            Console.WriteLine("Ошибка ввода продукта");

            return product;
        }

        public void OnCounter()
        {
            Console.WriteLine($"У продавца количество денег - {Money}");
            Console.WriteLine("У продавца на прилавке:");

            foreach (Product products in _products)
            {
                products.ShowInfo();
            }

            Console.ReadKey();
        }

        public bool Sell(string choosenItem, int money, out Product item)
        {
            bool isSell = false;
            bool isCorrectChoice = TryFindItem(choosenItem);
            item = null;

            if (isCorrectChoice)
            {
                for (int i = 0; i < _products.Count; i++)
                {
                    if (_products[i].Name.ToLower() == choosenItem.ToLower())
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

        public void Sell(Product product)
        {
            Money += product.Price;
            _products.Remove(product);
        }

        private bool TryFindItem(string choosenItem)
        {
            bool isCorrectChoice = false;

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Name.ToLower() == choosenItem.ToLower())
                {
                    isCorrectChoice = true;
                }
            }

            return isCorrectChoice;
        }
    }

    class Product
    {
        public Product(string product, int price)
        {
            Name = product;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Предмет - {Name}, стоимость - {Price} рублей");
        }
    }
}
