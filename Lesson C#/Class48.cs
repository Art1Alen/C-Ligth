namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Work();
            Console.ReadLine();
        }
    }

    class Zoo
    {
        private const string CommandStart = "1";
        private const string CommandExit = "2";

        private static Random _random = new Random();

        private List<Aviary> _aviaries = new List<Aviary>();
        private List<Animal> _animals = new List<Animal>();

        public Zoo()
        {
            FillAnimas();
            CreateAviary();
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Добро пожаловать в зоопар.\nДля начало нажмите {CommandStart}\nВыход из зоопарка {CommandExit}");
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

        private void FillAnimas()
        {
            _animals.Add(new Animal("Тигры", "Р-р-р"));
            _animals.Add(new Animal("Собаки", "Гаф"));
            _animals.Add(new Animal("Попугай", "Кто - там"));
            _animals.Add(new Animal("Кот", "Мяу Мяу"));
            _animals.Add(new Animal("Крокодил", "Клоц-клоц"));

        }

        private void CreateAviary()
        {
            int min = 2;
            int max = 7;

            for (int i = 0; i < _animals.Count; i++)
            {
                int count = _random.Next(min, max);

                List<Animal> animals = new List<Animal>();

                for (int j = 0; j < count; j++)
                {
                    Animal animal = new Animal(_animals[i].Name, _animals[i].Voice);
                    animals.Add(animal);
                }

                _aviaries.Add(new Aviary(animals));
            }
        }

        private void ShowAviary()
        {
            int maxNumber = _aviaries.Count;

            Console.WriteLine("Вольеры:");

            for (int i = 0; i < _aviaries.Count; i++)
            {
                int number = i + 1;

                Console.WriteLine($"{number}. {_aviaries[i].Name}");
            }

            Console.Write($"На какой вольер вы хотите посмотреть?: Введите номер от 1 до {maxNumber}\n");

            if (int.TryParse(Console.ReadLine(), out int inputNumberAviary))
            {
                if (inputNumberAviary > 0 && inputNumberAviary < _aviaries.Count)
                {
                    _aviaries[inputNumberAviary - 1].ShowAnimals();
                }
                else
                {
                    Console.WriteLine("Вальера с таким номером в зоопарке нету.");
                }
            }
        }
    }

    class Aviary
    {
        const string Tigger = "Тигр";
        const string Dog = "Собака";
        const string Parrot = "Попугай";
        const string Cat = "Кот";
        const string Crocodile = "Кродил";

        private Random _random = new Random();

        private List<Animal> _animals = new List<Animal>();
        public string[] _listAnimals = new string[0];

        public Aviary()
        {
            _listAnimals = new string[] { $"{Tigger}, {Dog} , {Parrot}, {Cat}, {Crocodile}" };
        }

        public Aviary(List<Animal> animals)
        {
            _animals = animals;
        }

        public string Name => _animals[0].Name;

        public void ShowAnimals()
        {
            Console.WriteLine($"\nКоличиство животных в вольере - {_animals.Count}");

            foreach (Animal animal in _animals)
            {
                Console.WriteLine($"{animal.Name}. Пол - {animal.Gender}. Голос - {animal.Voice}");
            }
        }
    }

    class UserUtils
    {
        private static Random _random = new Random();

        public static int GetRandom(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static int GetRandom(int max)
        {
            return _random.Next(max);
        }

    }

    class Animal
    {
        private static Random _random = new Random();

        public Animal(string name, string voice)
        {
            Name = name;
            Choose();
            Voice = voice;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Voice { get; private set; }

        public void Choose()
        {
            const string Female = "Самка";
            const string Male = "Самец";

            string[] arrayGender = { Female, Male };

            int gender = UserUtils.GetRandom(2);
            Gender = arrayGender[gender];
        }
    }
}