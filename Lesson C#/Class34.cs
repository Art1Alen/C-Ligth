using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class34
    {
        const string CommandAddDossier = "1";
        const string CommandShowDossier = "2";
        const string CommandDeleteDossier = "3";
        const string CommandExit = "4";
        static void Main()
        {
            Dictionary<string, string> dossier = new Dictionary<string, string>();

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Меню программы:\n{CommandAddDossier} - Добавить новое досье\n{CommandShowDossier} - Показать все досье\n{CommandDeleteDossier} - Удалить досье\n{CommandExit} - Выход из программы");
                Console.Write("\nВведите Номер пукта: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(dossier);
                        break;
                    case CommandShowDossier:
                        ShowDossiers(dossier);
                        break;
                    case CommandDeleteDossier:
                        FunctionDeleteDossier(dossier, userInput);
                        break;
                    case CommandExit:
                        Console.WriteLine("Для выхода нажмите Enter");

                        isWork = false;
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, string> dossier)
        {
            Console.WriteLine("Введите ФИО");
            string name = Console.ReadLine();

            Console.WriteLine("Введите дольжность");
            string jobTitle = Console.ReadLine();

            dossier.Add(name, jobTitle);
        }

        static void ShowDossiers(Dictionary<string, string> dossier)
        {
            foreach (var item in dossier)
            {
                Console.WriteLine($"ФИО - {item.Key}:  Должность - {item.Value}");
            }

            Console.ReadKey();
        }

        static void FunctionDeleteDossier(Dictionary<string, string> dossier, string name)
        {
            Console.WriteLine("Введите данные ФИО чтобы удалить");
            name = Console.ReadLine();

            dossier.Remove(name);

            Console.WriteLine(" Данные Удалены");
            Console.ReadKey();
        }
    }
}
