namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandCreateQueue = "1";
            const string CommandServiceQueue = "2";
            const string CommandLeaveStore = "3";

            Supermarket supermarket = new Supermarket();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{CommandCreateQueue} - создать очередь клиентов." +
                    $"\n{CommandServiceQueue} - обслужить очередь клиентов" +
                    $"\n{CommandLeaveStore} - Покинуть Магазин");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandCreateQueue:
                        supermarket.CreateClientQueue();
                        Console.WriteLine("Очередь создана.");
                        break;

                    case CommandServiceQueue:
                        supermarket.ServeClients();
                        Console.WriteLine("Очередь обслужена");
                        break;

                    case CommandLeaveStore:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Supermarket
    {
        private Queue<Client> _clients = new Queue<Client>();
        private List<Product> _products = new List<Product>();

        private Random _random = new Random();

        public Supermarket()
        {
            _products.Add(new Product("Молоко", ProductPrice()));
            _products.Add(new Product("Яблоко", ProductPrice()));
            _products.Add(new Product("Сой", ProductPrice()));
            _products.Add(new Product("Хлеб", ProductPrice()));
            _products.Add(new Product("Яйцо", ProductPrice()));
            _products.Add(new Product("Булочка", ProductPrice()));
        }

        public void CreateClientQueue()
        {
            int minCountClient = 2;
            int maxCountClient = 10;

            int countClient = _random.Next(minCountClient, maxCountClient);

            for (int i = 0; i < countClient; i++)
            {
                _clients.Enqueue(GetClient());
            }
        }

        public void ServeClients()
        {
            while (_clients.Count > 0)
            {
                _clients.Dequeue().PurchaseProducts();
            }
        }

        private Client GetClient()
        {
            List<Product> products = new List<Product>();

            int minCountProduct = 2;
            int maxCountProduct = 6;
            int minCountMoney = 10;
            int maxCountMoney = 100;

            int countMoney = _random.Next(minCountMoney, maxCountMoney);
            int countProduct = _random.Next(minCountProduct, maxCountProduct);

            for (int i = 0; i < countProduct; i++)
            {
                products.Add(_products[_random.Next(0, _products.Count - 1)]);
            }

            return new Client(countMoney, products);
        }

        private int ProductPrice()
        {
            int minCostProduct = 5;
            int maxCostProduct = 25;

            int costProduct = _random.Next(minCostProduct, maxCostProduct);

            return costProduct;
        }
    }

    class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; private set; }
        public int Cost { get; private set; }
    }

    class Client
    {
        private List<Product> _productsInBasket;
        private int _money;

        public Client(int money, List<Product> productsInBasket)
        {
            _money = money;
            _productsInBasket = productsInBasket;
        }

        public void PurchaseProducts()
        {
            int purchaseAmount = GetEntireBasketCost();

            ShowProductsBasket();
            Console.WriteLine($"Сумма товаров {purchaseAmount}. У клиента {_money}");

            if (_money >= purchaseAmount)
            {
                Console.WriteLine($"Клиент оплатил товары на сумму {purchaseAmount} и покинул магазин");
            }
            else
            {
                RemoveUnnecessaryProductsClient();
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void RemoveUnnecessaryProductsClient()
        {
            while (GetEntireBasketCost() > _money)
            {
                RemoveProduct();
            }
        }

        private void RemoveProduct()
        {
            Random random = new Random();
            int index = random.Next(0, _productsInBasket.Count);

            Product productToRemove = _productsInBasket[index];
            Console.WriteLine($"Клиент отказаться от товара {productToRemove.Name} стоимостью {productToRemove.Cost}");
            _productsInBasket.Remove(productToRemove);
        }

        private int GetEntireBasketCost()
        {
            int purchaseAmount = 0;

            foreach (Product product in _productsInBasket)
            {
                purchaseAmount += product.Cost;
            }

            return purchaseAmount;
        }

        private void ShowProductsBasket()
        {
            Console.WriteLine("Корзина клиента");

            foreach (Product item in _productsInBasket)
            {
                Console.WriteLine($"{item.Name}, цена: {item.Cost}");
            }
        }

    }
}