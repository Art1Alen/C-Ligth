using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Class6
    {      
            static void Main(string[] args)
            {
                Armies armies = new Armies();
                armies.Work();
            }
        
        class Armies
        {
            private List<Soldier> _firstSquad;
            private List<Soldier> _secondSquad;

            public Armies()
            {
                _firstSquad = new List<Soldier>();
                _secondSquad = new List<Soldier>();
                _firstSquad.Add(new Soldier("Собакин", "Рядовой"));
                _firstSquad.Add(new Soldier("Иванов", "Рядовой"));
                _firstSquad.Add(new Soldier("Белиев", "Сержант"));
                _firstSquad.Add(new Soldier("Белогородов", "Сержант"));
                _firstSquad.Add(new Soldier("Носков", "Старший сержант"));
                _secondSquad.Add(new Soldier("Соболев", "Рядовой"));
                _secondSquad.Add(new Soldier("Кудрявцев", "Рядовой"));
            }

            public void Work()
            {
                Console.WriteLine("Отряд 1");
                ShowSoldiersInfo(_firstSquad);

                Console.WriteLine("Отряд 2");
                ShowSoldiersInfo(_secondSquad);

                MoveSelectedSoldiers();

                Console.WriteLine("\nОтряд 1");
                ShowSoldiersInfo(_firstSquad);

                Console.WriteLine("Отряд 2");
                ShowSoldiersInfo(_secondSquad);
            }

            private void MoveSelectedSoldiers()
            {
                var soldiers = _firstSquad.Where(soldier => soldier.Name.Contains("Б"));
                _secondSquad = _secondSquad.Union(soldiers).ToList();
                _firstSquad = _firstSquad.Except(soldiers).ToList();
            }

            private void ShowSoldiersInfo(List<Soldier> soldiers)
            {
                foreach (var soldier in soldiers)
                {
                    soldier.ShowSolider();
                }
            }
        }

        class Soldier
        {
            public Soldier(string name, string title)
            {
                Name = name;
                Title = title;
            }

            public string Name { get; private set; }
            public string Title { get; private set; }

            public void ShowSolider()
            {
                Console.WriteLine($"Name: {Name}. Title {Title}.");
            }
        }
    }
}
