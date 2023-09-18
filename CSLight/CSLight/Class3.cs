using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Class3
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Database database = new Database();
                database.Work();
            }
        }

        class Database
        {
            private List<Player> _players;
            private int _maxTopPlayers;

            public Database()
            {
                _players = new List<Player>();
                _maxTopPlayers = 3;
                _players.Add(new Player("ArtAlen", 55, 452));
                _players.Add(new Player("Обема", 13, 208));
                _players.Add(new Player("Ylus", 70, 534));
                _players.Add(new Player("DergiDver", 94, 806));
                _players.Add(new Player("Cheeze", 8, 38));
                _players.Add(new Player("ЧБG", 27, 169));
                _players.Add(new Player("Mixa", 15, 50));
                _players.Add(new Player("Strey228", 5, 7));
                _players.Add(new Player("NoName", 71, 524));
                _players.Add(new Player("Solo", 74, 564));
            }

            public void Work()
            {
                Console.WriteLine("\nТоп 3 игроков по уровню.");
                ShowTopPlayersByLevel();
                Console.WriteLine("\nТоп 3 игроков по силе.");
                ShowTopPlayersByPower();
            }

            private void ShowTopPlayersByLevel()
            {
                _players = _players.OrderByDescending(player => player.Level).Take(_maxTopPlayers).ToList();
                ShowPlayersInfo(_players);
            }

            private void ShowTopPlayersByPower()
            {
                _players = _players.OrderByDescending(player => player.Power).Take(_maxTopPlayers).ToList();
                ShowPlayersInfo(_players);
            }

            private void ShowPlayersInfo(List<Player> players)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    players[i].ShowPlayer();
                }
            }
        }

        class Player
        {
            private string _name;

            public Player(string name, int level, int power)
            {
                _name = name;
                Level = level;
                Power = power;
            }

            public int Level { get; private set; }
            public int Power { get; private set; }

            public void ShowPlayer()
            {
                Console.WriteLine($"Name: {_name}. Level: {Level}. Power: {Power}.");
            }
        }
    }
}
