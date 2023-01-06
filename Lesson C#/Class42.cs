using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class42
    {
        public static void Main()
        {
            const string BuyItem = "1";
            const string ShowSellerDesk = "2";
            const string ShowCustomerRucksackAndMoney = "3";
            const string MenuExit = "exit";

            Seller seller = new Seller();
            Customer customer = new Customer(300);

            bool isWorking = true;

            while (isWorking)
            {
                if (customer.Money > 0)
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
                            customer.Buy(seller.GiveItem(customer.ChooseItem(), customer.Money, out Goods item), item);
                            break;

                        case ShowSellerDesk:
                            seller.ShowStackAndMoney();
                            break;

                        case ShowCustomerRucksackAndMoney:
                            customer.ShowRucksackAndMoney();
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
                    customer.ShowRucksackAndMoney();
                }
            }

            Console.ReadKey();
        }
    }

    class Customer
    {
        public int Money { get; private set; }
        private List<Goods> _rucksack = new List<Goods> { };

        public Customer(int money)
        {
            Money = money;
        }

        public int ToPay(Goods item)
        {
            Money -= item.Price;
            return Money;
        }

        public string ChooseItem()
        {
            Console.WriteLine("Введите наименование товара, который вы решили купить");
            string input = Console.ReadLine();
            return input;
        }

        public void Buy(bool isBuying, Goods item)
        {
            if (isBuying)
            {
                _rucksack.Add(item);
                ToPay(item);
            }
            else
            {
                return;
            }

        }

        public void ShowRucksackAndMoney()
        {
            Console.WriteLine($"Ваше количество денег - {Money}");
            Console.WriteLine("В вашем рюкзаке:");

            foreach (var item in _rucksack)
            {
                item.ShowItem();
            }

            Console.ReadKey();
        }
    }

    class Seller
    {
        private List<Goods> _stack = new List<Goods> { new Goods("хлеб", 40), new Goods("чай", 70), new Goods("вода", 30), new Goods("мясо", 200), new Goods("яйца", 100) };
        private int _money = 0;

        public bool GiveItem(string choosenItem, int money, out Goods item)
        {
            bool isGiveItem = false;
            isGiveItem = Sell(choosenItem, money, out item);
            return isGiveItem;
        }

        public bool Sell(string choosenItem, int money, out Goods item)
        {
            bool isSell = false;
            bool isCorrectChoice = TryFindItem(choosenItem);
            item = null;

            if (isCorrectChoice)
            {
                for (int i = 0; i < _stack.Count; i++)
                {
                    if (_stack[i].Item.ToLower() == choosenItem.ToLower())
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
                if (_stack[i].Item.ToLower() == choosenItem.ToLower())
                {
                    isCorrectChoice = true;
                }
            }

            return isCorrectChoice;
        }

        private bool CheckMoney(int money)
        {
            bool isPlayerHasMoney = false;

            for (int i = 0; i < _stack.Count; i++)
            {
                if (_stack[i].Price <= money)
                {
                    isPlayerHasMoney = true;
                    break;
                }
            }

            return isPlayerHasMoney;
        }

        public void ShowStackAndMoney()
        {
            Console.WriteLine($"У продавца количество денег - {_money}");
            Console.WriteLine("У продавца на прилавке:");

            foreach (var item in _stack)
            {
                item.ShowItem();
            }

            Console.ReadKey();
        }
    }

    class Goods
    {
        public string Item { get; private set; }
        public int Price { get; private set; }

        public Goods(string goods, int price)
        {
            Item = goods;
            Price = price;
        }

        public void ShowItem()
        {
            Console.WriteLine($"Предмет - {Item}, стоимость - {Price} рублей");
        }
    }
}
