using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLight
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

        bool isWork = true;

        public Database()
        {
            _criminals = new List<Criminal>();
            _criminals.Add(new Criminal("Иванов", "Иван", "Иванович", false, 175, 70, "Русский"));
            _criminals.Add(new Criminal("Чистяков", "Иван", "Юрьевич", true, 150, 65, "Украиней"));
            _criminals.Add(new Criminal("Ковалев", "Марк", "Елисеевич", true, 190, 80, "Беларус"));
            _criminals.Add(new Criminal("Мельников", "Даниил", "Владиславович", false, 155, 77, "Арменин"));
            _criminals.Add(new Criminal("Трофимов", "Сергей", "Иванович", false, 179, 81, "Русский"));
        }

        public void Work()
        {
            const string CommandWork = "1";
            const string CommandExit = "2";

            while (isWork)
            {
                Console.WriteLine("Поиск человека");
                Console.WriteLine($"Для начала работы Введите кнопку {CommandWork}");
                Console.WriteLine($"Для выхода из работы Введите кнопку {CommandExit}");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandWork:
                        SearchPeople();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.Clear();
            }

        }

        private void SearchPeople()
        {
            Console.Write("Введиет рост: ");
            int growth = GetInputNumber();

            Console.Write("Введиет вес: ");
            int weight = GetInputNumber();

            Console.Write("Введиет национальность: ");
            string nationality = GetInputText().ToLower();

            if (growth == 0 || weight == 0 || nationality == null)
            {

                Console.WriteLine("Ошибка. Введены не коректные данные");
            }
            else
            {
                var filterPeople = from people in _criminals
                                   where people.Growth <= growth
                                   && people.Weight <= weight
                                   && people.Nationality.ToUpper() == nationality.ToUpper()
                                   && people.IsPrisoner == false
                                   select people;

                foreach (var people in filterPeople)
                {
                    people.ShowCriminal();
                }
            }

            Console.ReadKey();
        }

        private int GetInputNumber()
        {
            int maxLength = 3;
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumber);

            if (isNumber == true && inputNumber > maxLength)
            {
                return inputNumber;
            }
            else
            {
                Console.WriteLine("Введены некоретные данный поторите попытку.");
                return inputNumber;
            }
        }

        private string GetInputText()
        {
            string text = Console.ReadLine();

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol) == false)
                {
                    Console.WriteLine("Введены некоретные данный поторите попытку.");
                    return null;
                }
            }

            return text;
        }
    }


    class Criminal
    {
        private string _surname;
        private string _name;
        private string _patronymic;

        public Criminal(string surname, string name, string patronymic, bool isPrisoner, int growth, int wight, string nationality)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            IsPrisoner = isPrisoner;
            Growth = growth;
            Weight = wight;
            Nationality = nationality;
        }

        public bool IsPrisoner { get; private set; }
        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public void ShowCriminal()
        {
            Console.WriteLine($"ФИО: {_surname} - {_name} - {_patronymic}. \nПод стражей: {IsPrisoner}. \nРост: {Growth}. \nВес: {Weight}. \nНациональность: {Nationality}");
        }
    }
}