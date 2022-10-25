namespace CSLight
{
    internal class Class14
    {
        static void Main()
        {
            int minNumber = 1;
            int maxNumber = 28;
            int cardboardNumber = 999;
            int count = 0;
            int multiplicityOfNumbers = 99;

            Random random = new Random();
            int numberRandom = random.Next(minNumber, maxNumber);

            for (int i = 0; i <= cardboardNumber; i += numberRandom)
            {
                if (i > multiplicityOfNumbers)
                    count++;
            }

            Console.WriteLine(count);
        }
    }
}
