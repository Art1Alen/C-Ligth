namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.StartExcursion();
            Console.ReadLine();
        }
    }

    class Zoo
    {
        private const string CommandStart = "1";
        private const string CommandExit = "2";
        private List<Aviary> _aviaries = new List<Aviary>();

        public void StartExcursion()
        {
            CreateAviary(5);
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Добро пожаловать в зоопар.\nДля налало нажмите {CommandStart}\nВыход из зоопарка {CommandExit}");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandStart:
                        ShowAviary();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Не верный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateAviary(int numberOfAviary)
        {
            for (int i = 0; i < numberOfAviary; i++)
            {
                _aviaries.Add(new Aviary());
            }
        }

        private void ShowAviary()
        {
            bool isNumber;

            foreach (Aviary aviary in _aviaries)
            {
                Console.WriteLine($"{_aviaries.Count}");
            }

            Console.Write("На какой вольер вы хотите посмотреть?: Введите номер от 1 до 4\n");
            if (isNumber = int.TryParse(Console.ReadLine(), out int inputNumberAviary))
            {
                Console.WriteLine("Ошибка! Вы ввели не коректные данные.");
            }
            else if (inputNumberAviary > 0 && inputNumberAviary < _aviaries.Count)
            {
                _aviaries[inputNumberAviary - 1].ShowAnimals();
            }
            else
            {
                Console.WriteLine("Вальера с таким номером в зоопарке нету.");
            }
        }
    }

    class Aviary : Zoo
    {
        private Random _random = new Random();

        private Dictionary<int, Animal> _animals = new Dictionary<int, Animal>();
        private string[] _listAnimals = new string[] { "Тигр", "Собака", "Попугай", "Кот", "Крокодил" };

        public Aviary()
        {
            CreateAnimal(5);
        }

        public void ShowAnimals()
        {
            Console.WriteLine($"\nКоличиство животных в вольере - {_animals.Count}");

            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.Value.Name}. Пол - {animal.Value.Gender}. Голос - {animal.Value.Voice}");
            }
        }

        private void CreateAnimal(int numberOfAnimals)
        {
            int animalId = _random.Next(0, _listAnimals.Length);

            for (int i = 0; i < numberOfAnimals; i++)
            {
                _animals.Add(i, GetAnimal(animalId));
            }
        }

        private Animal GetAnimal(int animalId)
        {
            switch (_listAnimals[animalId])
            {
                case "Тигр":
                    return new Animal("Тигр", "Р-р-р");

                case "Собака":
                    return new Animal("Собаки", "Гаф");

                case "Попугай":
                    return new Animal("Попугай", "Кто - там");

                case "Кот":
                    return new Animal("Кот", "Мяу Мяу");

                case "Крокодил":
                    return new Animal("Крокодил", "Клоц-клоц");
            }

            return null;
        }
    }

    class Animal
    {
        private Random _random = new Random();

        public Animal(string name, string voice)
        {
            Name = name;
            Gender = GetGenderAnimal();
            Voice = voice;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Voice { get; private set; }

        private string GetGenderAnimal()
        {
            int minimumNumberGender = 0;
            int maximumNumberGender = 2;

            int gender = _random.Next(minimumNumberGender, maximumNumberGender);

            if (gender == 1)
            {
                return "Самец";
            }
            else
            {
                return "Самка";
            }
        }
    }
}