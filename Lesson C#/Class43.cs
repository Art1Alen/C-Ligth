using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class43
    {
        static void Main(string[] args)
        {
            Logistician logistician = new Logistician();

            bool isWork = true;

            while (isWork)
            {
                logistician.OpenMenu();
            }
        }
    }

    class Train
    {
        private Wagons _wagons = new Wagons();
        public void CreateTrain()
        {
            _wagons.CreateNumberOfWagons();
            _wagons.CreateCapacity();
        }
        public void ShowTrain()
        {
            Console.WriteLine($"Поезд создан, количество вагонов - {_wagons.NumberOfWagons}, вместимость вагонов - {_wagons.CapacityOfWagon}.");
        }

        public bool TryBuildTrain(int passengerCount)
        {
            if (_wagons.CapacityOfWagon * _wagons.NumberOfWagons > passengerCount)
            {
                Console.WriteLine("Поезд успешно создан и укомплексован");
                return true;
            }
            else
            {
                passengerCount -= _wagons.CapacityOfWagon * _wagons.NumberOfWagons;
                Console.WriteLine($"Ошибка!!! Поезду не хватило мест - {passengerCount} мест.");
                return false;
            }
        }
    }

    class Wagons
    {
        public int CapacityOfWagon { get; private set; }
        public int NumberOfWagons { get; private set; }

        public void CreateCapacity()
        {
            int maxCapacityOfwagons = 100;
            int minCapacityOfwagons = 5;         
     
            Console.Write("Введите вместимость вагонов вагонов:");
            string userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int capacityOfWagon);

            if (isNumber)
            {
                CapacityOfWagon = capacityOfWagon;
                Console.WriteLine($"Вместимость вагонов создано - {CapacityOfWagon}.");
            }
            else if (capacityOfWagon < minCapacityOfwagons || capacityOfWagon > maxCapacityOfwagons)
            {
                Console.WriteLine("Ошибка!!! Столько человек не может вместить один вагон!");
            }
            else
            {
                Console.WriteLine("Не верный ввод!!!");
            }
        }

        public void CreateNumberOfWagons()
        {
            int maxCountWagon = 10;
            int minCountWagon = 1;          

            Console.Write("Введите количество вагонов:");
            string userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int numberOfWagons);

            if (isNumber)
            {
                NumberOfWagons = numberOfWagons;
                Console.WriteLine($"Количество вагонов создано - {NumberOfWagons}.");
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

    class Logistician
    {
        private Queue<Direction> _directions = new Queue<Direction>();
        private Train _train = new Train();
        public void OpenMenu()
        {
            bool isWork = true;

            while (isWork == true)
            {
                FillInPath();
                Console.Clear();

                int passengerCount = SellBeletov();

                _train.CreateTrain();

                if (_train.TryBuildTrain(passengerCount))
                {
                    _train.ShowTrain();

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

        private int SellBeletov()
        {
            int maxNumber = 500;
            int minNumber = 0;

            Random _random = new Random();
            int numberOfBelets = _random.Next(minNumber, maxNumber);

            Console.WriteLine("Продажа белетов:");
            Console.Write($"Белетов купило {numberOfBelets} человек, на рейс ");

            DeclatePath();

            return numberOfBelets;
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
        public string BeginningOfPath { get; private set; }
        public string EndOfRoad { get; private set; }

        public Direction(string beginningOfPath, string endOfRoad)
        {
            BeginningOfPath = beginningOfPath;
            EndOfRoad = endOfRoad;
        }
    }
}


