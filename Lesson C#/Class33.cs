namespace CSLight
{
    internal class Class33
    {
        const string CommandSum = "sum";
        const string CommandExit = "exit";
       
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(); 

            bool isWorking = true;

            while (isWorking == true)
            {
                Console.WriteLine($"Введите число");
                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case CommandSum:
                        Sum(numbers);
                        break;

                        case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        AddNumber(userInput, numbers);
                        break;
                }
            }
        }
     
        static void Sum(List<int> numbers)
        {
            int sum = 0;
            foreach (int numberInList in numbers)
            {
                sum += numberInList;
            }

            Console.WriteLine($"\nСумма введёных чисел: {sum}\n");
        }

        static void AddNumber(string userInput, List<int> numbers)
        {
            bool isNumber = int.TryParse(userInput, out int number);

            if (isNumber == true)
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("\nНекорректный ввод\n");
            }
        }
    }
}
