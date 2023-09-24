namespace CSLight
{
    internal class Class22
    {
        static void Main()
        {
            int[] array = new int[30] { 3, 3, 3, 4, 5, 6, 7, 2, 2, 3, 2, 5, 7, 5, 7, 7, 8, 8, 8, 8, 8, 5, 8, 1, 2, 4, 5, 6, 8, 5 };

            int numberArray = 0;
            int repeatSubarrayNumber = 0;
            int maxLengthRepeatSubarrayNumber = 0;

            string space = " ";

            for (int i = 1; i < array.Length - 1; i++)
            {
                Console.Write(array[i] + space);
                int timeComparison = i + 1;
                if (array[i] == array[timeComparison])
                {
                    repeatSubarrayNumber++;
                    numberArray = array[i];
                }
                else
                {
                    repeatSubarrayNumber = 0;
                }

                if (repeatSubarrayNumber > maxLengthRepeatSubarrayNumber)
                {
                    maxLengthRepeatSubarrayNumber = repeatSubarrayNumber;
                    numberArray = array[i];
                }
            }

            Console.WriteLine($"\nЧисло, которое повторяется большее {numberArray}\nколичество раз {maxLengthRepeatSubarrayNumber} : ");
            Console.ReadKey();

        }
    }
}
