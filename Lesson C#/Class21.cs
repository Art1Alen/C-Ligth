namespace CSLight
{
    internal class Class21
    {
        static void Main()
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            bool isWorking = true;

            int arraySum = 0;

            int[] array = new int[1];

            while (isWorking)
            {
                Console.WriteLine($"Введите число,{CommandExit} или {CommandSum}");

                string message = Console.ReadLine();

                if (message == CommandExit)
                {
                    isWorking = false;
                }
                else if (message == CommandSum)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        arraySum += array[i];
                    }

                    Console.WriteLine($"Сумма массива: {arraySum} ");
                    arraySum = 0;
                }
                else
                {
                    int userInput = Convert.ToInt32(message);

                    int[] arrayCopy = new int[array.Length + 1];

                    arrayCopy[arrayCopy.Length - 1] = userInput;

                    for (int i = 0; i < array.Length; i++)
                    {
                        arrayCopy[i] = array[i];
                    }

                    array = arrayCopy;
                }
            }
        }
    }
}