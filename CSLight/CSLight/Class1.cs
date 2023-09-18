using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Class1
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
            private List<Criminal> _criminals;

            public Database()
            {
                _criminals = new List<Criminal>();
                _criminals.Add(new Criminal("Иванов", "Иван", "Иванович", "Антиправительственное"));
                _criminals.Add(new Criminal("Чистяков", "Иван", "Юрьевич", "Антиправительственное"));
                _criminals.Add(new Criminal("Ковалев", "Марк", "Елисеевич", "Вор"));
                _criminals.Add(new Criminal("Мельников", "Даниил", "Владиславович", "Шпион"));
                _criminals.Add(new Criminal("Трофимов", "Сергей", "Иванович", "Дилер"));
            }

            public void Work()
            {
                Console.WriteLine("Список до аминстии.\n");
                ShowPeople();
                Console.WriteLine("\nСписок после амнистии.\n");
                AmnestyPrisoners();
                ShowPeople();
            }

            public void ShowPeople()
            {
                foreach (var criminal in _criminals)
                {
                    criminal.ShowCriminal();
                }
            }

            public void AmnestyPrisoners()
            {
                _criminals = _criminals.Where(people => people.Crime != "Антиправительственное").ToList();
            }
        }

        class Criminal
        {
            private string _surname;
            private string _name;
            private string _patronymic;

            public Criminal(string surname, string name, string patronymic, string crime)
            {
                _surname = surname;
                _name = name;
                _patronymic = patronymic;
                Crime = crime;
            }

            public string Crime { get; private set; }

            public void ShowCriminal()
            {
                Console.WriteLine($"ФИО: {_surname} - {_name} - {_patronymic}. Преступление: {Crime}.");
            }
        }
    }
}
