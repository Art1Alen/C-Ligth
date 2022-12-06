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
                        dataBase.UnBanPlayer();
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
        private List<Player> players = new List<Player>();
        public void CreatePlayer()
        {
            int newId = players.Count() + 1;
            Console.WriteLine("Введите Name");

            string newName = Console.ReadLine();
            Console.WriteLine("Введите Level");

            int newLevel = int.Parse(Console.ReadLine());
            Console.WriteLine("Статус VAC бан игрока  - (true)  или нет - (false)");

            bool IsBanned = Convert.ToBoolean(Console.ReadLine());
            players.Add(new Player(newId, newName, newLevel, IsBanned));
        }

        public void RemovePlayer()
        {
            Console.WriteLine("Для Удаление Требуется Ввести id номер игрока");
            int selectedId = int.Parse(Console.ReadLine());

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == selectedId)
                {
                    players.RemoveAt(i);
                }
            }
        }

        public void ShowPlayers()
        {
            foreach (var player in players)
            {
                player.ShowInfo();
            }

            Console.ReadKey();
        }

        public void BanPlayer()
        {
            Console.WriteLine("Требуется id номер Игрока бля VAC бана");
            int playerId = int.Parse(Console.ReadLine());

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == playerId)
                {
                    players[i].IsBanTrue();
                }
            }
        }

        public void UnBanPlayer()
        {
            Console.WriteLine("Требуется id номер Игрока бля разбана VAC");
            int playerId = int.Parse(Console.ReadLine());

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == playerId)
                {
                    players[i].IsBanFalse();
                }
            }
        }
    }

    class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        private bool IsBanned { get; set; }
        public Player(int id, string name, int level, bool isBanned)
        {
            Id = id;
            Name = name;
            Level = level;
            IsBanned = isBanned;
        }

        public bool IsBanFalse()
        {
            IsBanned = false;
            return IsBanned;
        }
        public bool IsBanTrue()
        {
            IsBanned = true;
            return IsBanned;
        }


        public void ShowInfo()
        {
            Console.WriteLine($"Уникальный номер: {Id}, Имя: {Name}, Уровень персонажа: {Level}, Забанен: {IsBanned}");
        }
    }
}

