class Program
{
    static void Main(string[] args)
    {
        Supermarket supermarket = new Supermarket();

        supermarket.Work();
    }
}

class Supermarket
{
    private int _money = 0;

    private Random _random = new Random();
    private Queue<Client> clients = new Queue<Client>();
    private List<Product> _products = new List<Product>();

    public Supermarket()
    {
        _products = new List<Product>
        {
                    new Product("молоко", 5),
                    new Product("хлеб", 10),
                    new Product("пиво", 30),
                    new Product("водка", 130),
                    new Product("вода", 20),
                    new Product("мед", 50),
                    new Product("макароны", 35),
                    new Product("яблоки", 40),
        };
    }

    public void Work()
    {
        const string CommandOpenRegister = "1";
        const string CommandNextClient = "2";
        const string CommandCloseShop = "3";

        bool isOpen = true;

        while (isOpen)
        {
            Console.WriteLine($"Магазин работает\nВ кассе {_money} $\n");
            Console.WriteLine("Выберите, что хотите сделать:");
            Console.WriteLine($"{CommandOpenRegister}. Открыть кассу;");
            Console.WriteLine($"{CommandNextClient}. Обслужить покупателя в очереди;");
            Console.WriteLine($"{CommandCloseShop}. Закрыть магазин;");
            Console.Write("\nВведите команду: ");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandOpenRegister:
                    AddClientsToQueue();
                    break;

                case CommandNextClient:
                    ServeClient();
                    break;

                case CommandCloseShop:
                    isOpen = false;
                    break;

                default:
                    Console.WriteLine("\nЕще раз попробуйте");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    private void AddClientsToQueue()
    {
        int minCountClients = 5;
        int maxCountClients = 21;
        int countClients = _random.Next(minCountClients, maxCountClients);

        for (int i = 0; i < countClients; i++)
        {
            clients.Enqueue(new Client(_random));
        }

        AddProductsToClients();
    }

    private void AddProductsToClients()
    {
        int minCountProducts = 1;
        int maxCountProducts = 3;
        int countProducts;

        if (clients.Count > 0)
        {
            foreach (Client client in clients)
            {
                countProducts = _random.Next(minCountProducts, maxCountProducts);

                for (int i = 0; i < countProducts; i++)
                {
                    client.TakeProduct(GiveProductToClient(_products));
                }
            }
        }
        else
        {
            Console.WriteLine("\nНикого нету");
        }
    }

    private Product GiveProductToClient(List<Product> products)
    {
        int minCountProducts = 0;
        int maxCountProducts = products.Count;

        return products[_random.Next(minCountProducts, maxCountProducts)];
    }

    private void ServeClient()
    {
        Console.WriteLine("");

        if (clients.Count > 0)
        {
            clients.Peek().ShowInfo();

            if (TrySellProducts(clients.Peek()) == true)
            {
                clients.Peek().GiveMoney();
                TakeMoney(clients.Peek().GetCostAllProductsInBasket());

                Console.WriteLine($"\nКлиент Обслужен у него осталось денег {clients.Peek().Money} $");

                clients.Dequeue();
            }
        }
        else
        {
            Console.WriteLine("Никого нету");
        }
    }

    private bool TrySellProducts(Client сlient)
    {
        while (сlient.TryBuyProducts() != true)
        {
            сlient.TakeOutProduct(_random);
        }

        return true;
    }

    private void TakeMoney(int money)
    {
        _money += money;
    }
}

class Client
{
    private List<Product> _products = new List<Product>();

    public Client(Random random)
    {
        Wallet(random);
    }

    public int Money { get; private set; }

    public void TakeOutProduct(Random random)
    {
        int indexProduct;

        if (_products.Count > 0)
        {
            indexProduct = random.Next(0, _products.Count);

            Console.WriteLine($"\nПокупатель убрал c корзины{_products[indexProduct].Name}");

            _products.RemoveAt(indexProduct);
        }
        else
        {
            Console.WriteLine("Корзина пуста");
        }

        ShowInfo();
    }

    public void TakeProduct(Product product)
    {
        _products.Add(product.Clone());
    }


    private string GetListProducts()
    {
        string listProducts = "";

        if (_products.Count > 0)
        {
            foreach (Product product in _products)
            {
                listProducts += product.ShowInfo() + "/";
            }

            return listProducts;
        }
        else
        {
            return "пусто";
        }
    }

    public int GetCostAllProductsInBasket()
    {
        int costAllProductsInBasket = 0;

        foreach (Product product in _products)
        {
            costAllProductsInBasket += product.Price;
        }

        return costAllProductsInBasket;
    }

    public bool TryBuyProducts()
    {
        return true;
    }

    public void GiveMoney()
    {
        if (TryBuyProducts() == true)
        {
            Money -= GetCostAllProductsInBasket();
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Деньги у клиента : {Money} ; В корзине: {GetListProducts()} Итого: {GetCostAllProductsInBasket()}");
    }

    private void Wallet(Random random)
    {
        int minValue = 20;
        int maxValue = 150;

        Money = random.Next(minValue, maxValue);
    }
}

class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public int Price { get; private set; }

    public string ShowInfo()
    {
        return $"{Name} (цена: {Price} $)";
    }

    public Product Clone()
    {
        return new Product(Name, Price);
    }
}