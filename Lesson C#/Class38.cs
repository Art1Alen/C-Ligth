namespace CSLight
{
    internal class Class38
    {
        public static void Main()
        {
            const string CommandAddPlayer = "1";
            const string CommandBanPlayer = "2";
            const string CommandUnbanPlayer = "3";
            const string CommandDeletePlayer = "4";
            const string CommandShowPlayers = "5";
            const string CommandExit = "exit";

            Database dataBase = new Database();

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"{CommandAddPlayer} - добавить игрока в базуданных. " +
                $"\n{CommandBanPlayer} - забанить игрока по Id," +
                $"\n{CommandUnbanPlayer} - разбанить игрока," +
                $"\n{CommandDeletePlayer} - удалить игрока," +
                $"\n{CommandShowPlayers} - показать всех игроков," +
                $"\n{CommandExit} - выход.");

                Console.WriteLine("Выберите пункт меню ");
                string inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case CommandAddPlayer:
                        dataBase.CreatePlayer();
                        break;

                    case CommandBanPlayer:
                        dataBase.BanPlayer();
                        break;

                    case CommandUnbanPlayer:
                        dataBase.UnbanPlayer();
                        break;

                    case CommandDeletePlayer:
                        dataBase.RemovePlayer();
                        break;

                    case CommandShowPlayers:
                        dataBase.ShowPlayers();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Неправильно выбран пункт меню! ");
                        break;
                }

                Console.Clear();
            }

            Console.ReadKey();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void CreatePlayer()
        {
            int newId = _players.Count() + 1;

            Console.WriteLine("Введите Name");
            string newName = Console.ReadLine();

            Console.WriteLine("Введите Level");
            int newLevel = int.Parse(Console.ReadLine());

            bool isBanned = false;

            _players.Add(new Player(newId, newName, newLevel, isBanned));
        }

        public void RemovePlayer()
        {
            Console.WriteLine("Для Удаление Требуется Ввести id номер игрока");
            int selectedId = int.Parse(Console.ReadLine());

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == selectedId)
                {
                    _players.RemoveAt(i);
                }
            }
        }

        public void ShowPlayers()
        {
            foreach (var player in _players)
            {
                player.ShowInfo();
            }

            Console.ReadKey();
        }

        public void BanPlayer()
        {
            if (TryGetPlayer(out Player player))
            {
                player.Ban();
                Console.WriteLine("Игрок Заблокирован");
            }
        }

        public void UnbanPlayer()
        {
            if (TryGetPlayer(out Player player))
            {
                player.Unban();
                Console.WriteLine("Игрок Разблокирован");
            }
        }

        private bool TryGetPlayer(out Player player)
        {
            player = null;
            Console.WriteLine("Введите id номер Игрока");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Id == number - 1)
                    {
                        player = _players[i];
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных");
            }

            return false;
        }
    }

    class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }

        private bool _isBanned;

        public Player(int id, string name, int level, bool isBanned)
        {
            Id = id;
            Name = name;
            Level = level;
            _isBanned = isBanned;
        }

        public void Ban()
        {
            _isBanned = false;
        }

        public void Unban()
        {
            _isBanned = true;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Уникальный номер: {Id}, Имя: {Name}, Уровень персонажа: {Level}, Забанен: {_isBanned}");
        }
    }
}