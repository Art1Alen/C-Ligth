namespace CSLight
{
    internal class Class42
    {
        public static void Main()
        {
            const string BuyItem = "1";
            const string ShowSellerDesk = "2";
            const string ShowCustomerRucksackAndMoney = "3";
            const string MenuExit = "4";

            Seller seller = new Seller();
            Player player = new Player(300);

            bool isWorking = true;

            while (isWorking)
            {
                if (player.Money > 0)
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
                            player.Buy(seller.GiveItem(player.ShowAllProduct(), player.Money, out Products item), item);
                            break;

                        case ShowSellerDesk:
                            seller.OnCounter();
                            break;

                        case ShowCustomerRucksackAndMoney:
                            player.OnPlayer();
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
                    player.OnPlayer();
                }
            }

            Console.ReadKey();
        }
    }

    class Player
    {
        public int Money { get; private set; }

        private List<Products> _rucksack = new List<Products>();

        public Player(int money)
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
                _rucksack.Add(item);
                ToPay(item);
            }
        }

        public void OnPlayer()
        {
            Console.WriteLine($"Ваше количество денег - {Money}");
            Console.WriteLine("В вашем рюкзаке:");

            foreach (var item in _rucksack)
            {
                item.ShowProduct();
            }

            Console.ReadKey();
        }
    }

    class Seller
    {
        private List<Products> _stack = new List<Products>();

        private int _money = 0;

        public Seller()
        {
            ListProduct();
        }

        public bool GiveItem(string choosenItem, int money, out Products item)
        {
            bool isGiveItem = false;

            isGiveItem = Sell(choosenItem, money, out item);

            return isGiveItem;
        }

        public void OnCounter()
        {
            Console.WriteLine($"У продавца количество денег - {_money}");
            Console.WriteLine("У продавца на прилавке:");

            foreach (Products products in _stack)
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
                for (int i = 0; i < _stack.Count; i++)
                {
                    if (_stack[i].Product.ToLower() == choosenItem.ToLower())
                    {
                        if (money >= _stack[i].Price)
                        {
                            item = _stack[i];
                            _money += _stack[i].Price;
                            money -= _stack[i].Price;
                            _stack.RemoveAt(i);
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

            for (int i = 0; i < _stack.Count; i++)
            {
                if (_stack[i].Product.ToLower() == choosenItem.ToLower())
                {
                    isCorrectChoice = true;
                }
            }

            return isCorrectChoice;
        }

        private void ListProduct()
        {
            _stack.Add(new Products("Сыр", 40));
            _stack.Add(new Products("чай", 70));
            _stack.Add(new Products("вода", 30));
            _stack.Add(new Products("мясо", 200));
            _stack.Add(new Products("яйца", 100));
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
