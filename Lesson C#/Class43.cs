﻿namespace CSLight
{
    internal class Class43
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();

            bool isWork = true;

            while (isWork)
            {
                dispatcher.Work();
            }
        }
    }

    class Train
    {
        private Wagon _wagon = new Wagon();

        public int WagonsCount { get; private set; }

        public void Create()
        {
            WagonExpansion();
            _wagon.CreateCapacity();
        }

        public bool Applaud(int passengerCount)
        {
            if (_wagon.CapacityOfWagon * WagonsCount > passengerCount)
            {
                Console.WriteLine("Поезд успешно создан и укомплексован");
                return true;
            }
            else
            {
                passengerCount -= _wagon.CapacityOfWagon * WagonsCount;
                Console.WriteLine($"Ошибка!!! Поезду не хватило мест - {passengerCount} мест.");
                return false;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Поезд создан, количество вагонов - {WagonsCount}, вместимость вагонов - {_wagon.CapacityOfWagon}.");
        }

        public void WagonExpansion()
        {
            int maxCountWagon = 10;
            int minCountWagon = 1;

            Console.Write("Введите количество вагонов:");
            string userInput = Console.ReadLine();

            bool isNumber;

            if (isNumber = int.TryParse(userInput, out int numberOfWagons))
            {
                WagonsCount = numberOfWagons;
                Console.WriteLine($"Количество вагонов создано - {WagonsCount}.");
            }
            else if (numberOfWagons < minCountWagon || numberOfWagons > maxCountWagon)
            {
                Console.WriteLine("Ошибка!!! Столько вагонов не может быть!");
            }
            else
            {
                Console.WriteLine("Не верный ввод!!!");
            }
        }
    }

    class Wagon
    {
        public int CapacityOfWagon { get; private set; }

        public void CreateCapacity()
        {
            int maxCapacityOfwagons = 100;
            int minCapacityOfwagons = 5;

            Console.Write("Введите вместимость вагонов вагонов:");
            string userInput = Console.ReadLine();

            bool isNumber;

            if (isNumber = int.TryParse(userInput, out int capacityOfWagon))
            {
                CapacityOfWagon = capacityOfWagon;
                Console.WriteLine($"Вместимость вагонов создано - {CapacityOfWagon}.");
            }
            else if (capacityOfWagon < minCapacityOfwagons || capacityOfWagon > maxCapacityOfwagons)
            {
                Console.WriteLine("Ошибка!!! Столько человек не может вместить один вагон!");// DO TO
            }
            else
            {
                Console.WriteLine("Не верный ввод!!!");
            }
        }
    }

    class Dispatcher
    {
        private Queue<Direction> _directions = new Queue<Direction>();
        private Train _train = new Train();

        public void Work()
        {
            bool isWork = true;

            while (isWork == true)
            {
                FillInPath();

                Console.Clear();

                int passengersCount = SaleTickets();

                _train.Create();

                if (_train.Applaud(passengersCount))
                {
                    _train.ShowInfo();

                    Console.WriteLine("Поезд отправился в путь");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    _directions.Clear();

                    isWork = false;

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void FillInPath()
        {
            Console.Write("Введите начальный пункт отправления:");
            string beginningOfPath = Console.ReadLine();

            Console.Write("Введите конечный пункт прибытия:");
            string endOfRoad = Console.ReadLine();

            _directions.Enqueue(new Direction(beginningOfPath, endOfRoad));
        }

        private int SaleTickets()
        {
            int maxNumber = 500;
            int minNumber = 300;

            Random _random = new Random();
            int ticketsCount = _random.Next(minNumber, maxNumber);

            Console.WriteLine("Продажа белетов:");
            Console.Write($"Белетов купило {ticketsCount} человек, на рейс ");

            DeclatePath();

            return ticketsCount;
        }

        private void DeclatePath()
        {
            foreach (var direction in _directions)
            {
                Console.WriteLine($"Начальный пункт - {direction.BeginningOfPath}, Конечный пункт - {direction.EndOfRoad}.");
            }
        }
    }

    class Direction
    {
        public Direction(string beginningOfPath, string endOfRoad)
        {
            BeginningOfPath = beginningOfPath;
            EndOfRoad = endOfRoad;
        }

        public string BeginningOfPath { get; private set; }
        public string EndOfRoad { get; private set; }
    }
}


