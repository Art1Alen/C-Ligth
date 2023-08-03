namespace CSLight
{
    internal class Class49
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                CarService carService = new CarService();
                carService.Work();
            }
        }

        class CarService
        {
            private Storage _storage;
            private Queue<Car> _cars;
            private List<Detail> _details;

            private int _money = 2000;

            public CarService()
            {
                _storage = new Storage();
                _cars = new Queue<Car>();
                СreateCars(5);
            }

            public void Work()
            {
                const string CommandStart = "1";
                const string CommandExit = "2";

                bool isWork = true;

                while (isWork)
                {
                    Console.WriteLine($"\nБаланс автомастерской - {_money} монет.");
                    Console.Write($"В мастерской {_cars.Count} машин, стоят на ремонт. " +
                        $"\nДля их обслуживания введите {CommandStart}. " +
                        $"\nДля завершения работы введите{CommandExit}" +
                        $"\nДействие: ");
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case CommandStart:
                            ServiceСar();
                            break;

                        case CommandExit:
                            isWork = false;
                            break;
                    }
                }
            }

            private void СreateCars(int numberOfCar)
            {
                for (int i = 0; i < numberOfCar; i++)
                {
                    _cars.Enqueue(new Car());
                }
            }

            private void ShowBrakdown(Car car)
            {
                Console.WriteLine($"У авто сломано - {car.BreakdownDetail}. ");
                Console.WriteLine($"\nЦена за работу будет - {_storage.GetRepairPrice(car)} монет.");
            }

            private void ServiceСar()
            {
                const string CommandRepair = "1";
                const string CommandRefuse = "2";

                Console.Clear();
                var car = _cars.Dequeue();
                ShowBrakdown(car);

                Console.Write($"Что вы будете делать." +
                    $"\n{CommandRepair} Ремонтировать " +
                    $"\n{CommandRefuse} Отказать клиенту " +
                    "\n Действие: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandRepair:
                        RepairCar(car);
                        break;

                    case CommandRefuse:
                        DenyService();
                        break;

                    default:
                        Console.WriteLine("Такой команды нету.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }

            private void RepairCar(Car car)
            {
                if (TryRepairCar(car))
                {
                    Console.WriteLine($"Вы успешно починили автомобиль!" +
                        $"\n И заработали {_storage.GetRepairPrice(car)} монет.");
                    _money += _storage.GetRepairPrice(car);
                }
                else
                {
                    Console.WriteLine("Вы установили не ту деталь. Клиент не доволен вашей работой. " +
                         $"\n Вы возместитли ущерб клиенту в размере - {_storage.GetRepairPrice(car)} монет.");
                    _money -= _storage.GetRepairPrice(car);
                }
            }

            private void DenyService()
            {
                int penalty = 500;
                Console.WriteLine($"Вы отказали клиенту. С вас шраф - {penalty} монет.");
                _money -= penalty;
            }

            private bool TryRepairCar(Car car)
            {
                _storage.ShowStorage();

                Console.Write("\nКакую деталь вы хотитель установить: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumberDetail);

                if (isNumber == false)
                {
                    Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
                    return false;
                }
                else if (inputNumberDetail > 0 && inputNumberDetail - 1 <_details.Count && car.BreakdownDetail == _details[inputNumberDetail - 1].Name)
                {
                    int indexDetail = inputNumberDetail - 1;
                    _details.RemoveAt(indexDetail);
                    return true;
                }
                else
                {
                    Console.WriteLine("Кажется это на та деталь.");
                    return false;
                }
            }
        }

        class Car
        {
            private string[] _numbersBreakdown;
            private Random _random = new Random();

            public Car()
            {
                _numbersBreakdown = new string[] { "Колесо", "Стекло", "Фары", "Бампер", "Замок" };
                СreateBreakdown();
            }

            public string BreakdownDetail { get; private set; }

            private void СreateBreakdown()
            {
                int detailId = _random.Next(0, _numbersBreakdown.Length);
                BreakdownDetail = GetBreakdown(detailId);
            }

            private string GetBreakdown(int breakdownId)
            {
                const string NumberTwo = "2";
                const string NumberThree = "3";
                const string NumberFour = "4";
                const string NumberаFive = "5";
                const string NumberSix = "6";

                switch (_numbersBreakdown[breakdownId])
                {
                    case NumberTwo:
                        return "Колесо";
                    case NumberThree:
                        return "Стекло";
                    case NumberFour:
                        return "Фары";
                    case NumberаFive:
                        return "Бампер";
                    case NumberSix:
                        return "Замок";
                }

                return null;
            }
        }

        class Storage
        {
            private List<Detail> _details = new List<Detail>();
            private Random _random = new Random();
            private string[] _detail = new string[] { "Колесо", "Стекло", "Фары", "Бампер", "Замок" };

            public Storage()
            {
                СreateDetail(1);
                ListDetail();
            }


            public void ShowStorage()
            {
                Console.WriteLine("На складе есть такие детали: ");

                for (int i = 0; i < _details.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Название - {_details[i].Name}. Стоимость - {_details[i].Cost}");
                }
            }

            public int GetRepairPrice(Car car)
            {
                int repairPrice = 0;
                int costWork = 10;

                foreach (var detail in _details)
                {
                    if (car.BreakdownDetail == detail.Name)
                    {
                        repairPrice += detail.Cost * costWork;
                        break;
                    }
                }

                return repairPrice;
            }

            private void СreateDetail(int numberOfDetails)
            {
                for (int i = 0; i < numberOfDetails; i++)
                {
                    ListDetail();
                }
            }
            private void ListDetail()
            {
                _details.Add(new Detail("Колесо", 60));
                _details.Add(new Detail("Стекло", 80));
                _details.Add(new Detail("Фары", 40));
                _details.Add(new Detail("Бампер", 30));
                _details.Add(new Detail("Замок", 50));
            }
        }

        class Detail
        {
            public Detail(string name, int cost)
            {
                Name = name;
                Cost = cost;
            }

            public string Name { get; private set; }
            public int Cost { get; private set; }
        }
    }
}