namespace CSLight
{
    internal class Class47
    {
        static void Main(string[] args)
        {
            const string CommandAddFish = "1";
            const string CommandRemoveFish = "2";
            const string CommandExit = "3";

            Aquarium aquarium = new Aquarium();

            bool isWork = true;

            while (isWork)
            {
                aquarium.ShowAquarium();
                Console.WriteLine($"\nАквариум \n{CommandAddFish}. Добавить Рыбу  \n{CommandRemoveFish}. Убрать рыбу из аквариума\n{CommandExit}. Выход. ");
                Console.WriteLine("Выберите Комманду");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddFish:
                        aquarium.AddFish();
                        break;

                    case CommandRemoveFish:
                        aquarium.RemoveFish();
                        break;

                    case CommandExit:
                        Console.WriteLine("Выход");
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }

                aquarium.TimeAgeFish();
                aquarium.RemoveDeadFish();
                Console.Clear();
            }
        }
    }

    class Aquarium
    {
        private int _countOfFish = 5;
        private List<Fish> _fishes = new List<Fish>();

        public Aquarium()
        {
            _fishes.Add(new Fish(2, "Толстая Камбола"));
        }

        public void AddFish()
        {
            string name;
            int age;

            if (_countOfFish <= _fishes.Count)
            {
                Console.Clear();
                Console.WriteLine("В аквариуме нету места");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Введите имя рыбки: ");
                name = GetInputName();

                Console.Write("Введите возраст рыбы: ");
                age = GetInputAge();

                if (name == null || age == 0)
                {
                    Console.WriteLine("Ошибка. Введены не коректные данные");
                }
                else
                {
                    _fishes.Add(new Fish(age, name));
                }
            }
        }

        public void RemoveFish()
        {
            if (TryGetFish(out Fish fish))
            {
                _fishes.Remove(fish);
            }
        }

        public void ShowAquarium()
        {
            int numberFish = 1;
            Console.WriteLine($"\nКоличество Рыб в Аквариуме - {_fishes.Count}");

            foreach (Fish fish in _fishes)
            {
                Console.WriteLine($"{numberFish++}. {fish.Name}, возраст {fish.Age - 1}");
            }
        }

        public void RemoveDeadFish()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].IsALive == false)
                {
                    _fishes.Remove(_fishes[i]);
                }
            }
        }

        public void TimeAgeFish()
        {
            foreach (Fish fish in _fishes)
            {
                fish.Live();
            }
        }

        private bool TryGetFish(out Fish fish)
        {
            Console.Write("Введите номер рыбы: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumberFish);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
                fish = null;
                return false;
            }
            else if (inputNumberFish > 0 && inputNumberFish - 1 < _fishes.Count)
            {
                fish = _fishes[inputNumberFish - 1];
                Console.WriteLine("Достали рыбу");
                return true;
            }
            else
            {
                Console.WriteLine("Нет такой рыбы");
                fish = null;
                return false;
            }
        }

        private int GetInputAge()
        {
            int maximumLength = 1;
            int maximumAge = 9;
            bool isNumber = int.TryParse(Console.ReadLine(), out int age);

            if (isNumber == true && age >= maximumLength && age <= maximumAge)
            {
                Console.WriteLine("Дейстие выполнено.");
                return age;
            }
            else
            {
                Console.WriteLine("Введены некоретные данный поторите попытку.");
                age = 0;
                return age;
            }
        }

        private string GetInputName()
        {
            string name = Console.ReadLine();

            foreach (char symbol in name)
            {
                if (char.IsLetter(symbol) == false)
                {
                    Console.WriteLine("Введены некоретные данный поторите попытку.");
                    return null;
                }
            }

            return name;
        }

    }

    class Fish
    {
        public Fish(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; private set; }
        public string Name { get; private set; }

        private int _lethalAge = 10;

        public bool IsALive
        {
            get
            {
                return Age < _lethalAge;
            }
            private set { }
        }

        public void Live()
        {
            Age++;
        }
    }
}

