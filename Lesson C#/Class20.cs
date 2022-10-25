namespace CSLight
{
    internal class Class20
    {



        static void Main()
        {
            Random random = new Random();

            int minNumber = 1;
            int maxNumber = 10;
            int localMaxNumber = 0;

            string space = " ";

            int[] array = new int[30];

            for (int i = 1; i < array.Length - 1; i++)
            {
                array[i] = random.Next(minNumber, maxNumber);
                Console.Write(array[i] + space);
            }

            Console.WriteLine();
            Console.WriteLine("Локальный максимум");

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i - 1] < array[i] && array[i] > array[i + 1])
                {
                    Console.Write(array[i] + space);
                }
            }
        }
    }
}

