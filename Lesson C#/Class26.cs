namespace CSLight
{
    internal class Class26
    {
        static void Main()
        {
            const string CommandAddDossier = "1";
            const string CommandShowDossier = "2";
            const string CommandDeleteDossier = "3";
            const string CommandSearchDossier = "4";
            const string CommandExit = "5";

            bool isWork = true;

            string[] fullNames = new string[] { "Собакин Артемий Андреевич", "Петрова Алена Андреевна", "Сидоров Сергей Сергеевич", "Копылов Максим Юреевич", "Михайлов Владимир Николаевич", "Борисов Борис Борисович" };
            string[] jobTitle = new string[] { "Повар", "Учитель", "Босс", "Су-Шеф", "Сантехник", "Киллер" };

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Меню программы:\n{CommandAddDossier} - Добавить новое досье\n{CommandShowDossier} - Показать все досье\n{CommandDeleteDossier} - Удалить досье\n{CommandSearchDossier} - Поиск досье по фамилии\n{CommandExit} - Выход из программы");
                Console.Write("\nВведите Номер пукта: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(ref fullNames, ref jobTitle);
                        break;
                    case CommandShowDossier:
                        ShowDossiers(fullNames, jobTitle);
                        break;
                    case CommandDeleteDossier:
                        FunctionDeleteDossier(ref fullNames, ref jobTitle);
                        break;
                    case CommandSearchDossier:
                        SearchByLastName(fullNames, jobTitle);
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullNames, ref string[] jobTitle)
        {
            Console.SetCursorPosition(0, 9);

            AddData("Введите ФИО: ", ref fullNames);
            AddData("Введите должность: ", ref jobTitle);

            Console.Write("\nДанные добавлены");
            Console.ReadKey();
        }

        static string[] AddData(string text, ref string[] array)
        {
            Console.Write(text);

            string userInput = Console.ReadLine();
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = userInput;
            return array = tempArray;
        }

        static void ShowDossiers(string[] fullNames, string[] jobTitle)
        {
            Console.SetCursorPosition(0, 9);

            if (fullNames.Length == 0)
            {
                Console.WriteLine("База досье не заполнена");
                Console.Write("\nДля продолжения нажмите любую клавишу");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Список доступных досье: ");

                for (int i = 0; i < fullNames.Length; i++)
                {
                    Console.Write($"{i + 1}.{fullNames[i]} - {jobTitle[i]} ");
                }

                Console.Write("\n\nДля продолжения нажмите любую клавишу");
                Console.ReadKey();
            }
        }

        static void FunctionDeleteDossier(ref string[] fullNames, ref string[] jobTitle)
        {
            Console.SetCursorPosition(0, 9);

            if (fullNames.Length == 0)
            {
                Console.WriteLine("Удаление досье невозможно, так как база досье не заполнена");
                Console.Write("\nДля продолжения нажмите любую клавишу");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Ведите номер досье, досье которое нужно удалить: ");

                int number = Convert.ToInt32(Console.ReadLine());

                if (number > fullNames.Length || number <= 0)
                {
                    Console.WriteLine("Такого номера досье не найдено");
                    Console.Write("\nДля продолжения нажмите любую клавишу");
                    Console.ReadKey();
                }
                else
                {
                    DeleteData(number, ref fullNames);
                    DeleteData(number, ref jobTitle);

                    Console.Write("\nДанные Удалено");
                    Console.ReadKey();
                }
            }
        }

        static string[] DeleteData(int userInput, ref string[] array)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < userInput - 1; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = userInput - 1; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i + 1];
            }

            return array = tempArray;

        }

        static void SearchByLastName(string[] fullNames, string[] jobTitle)
        {
            bool isFind = false;

            Console.SetCursorPosition(0, 9);
            Console.Write("Введите фамилию: ");

            string userInputLastName = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] lastName = fullNames[i].Split(' ');

                if (userInputLastName.ToLower() == lastName[0].ToLower())
                {
                    Console.WriteLine($"Данные: {i + 1}.{fullNames[i]} - {jobTitle[i]}");
                    isFind = true;
                }
            }

            if (isFind == false)
            {
                Console.Write("Данные Добавлены");
            }

            Console.Write("\nДля продолжения нажмите любую клавишу");
            Console.ReadKey();

        }
    }
}
