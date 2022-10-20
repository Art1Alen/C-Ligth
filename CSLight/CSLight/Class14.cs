namespace CSLight
{
    internal class Class14
    {
        static void Main()
        {
            int minNumber = 1;
            int maxNumber = 27;
            int cardboardNumber = 999;

            Random random = new Random();
            int numberN = random.Next(minNumber, maxNumber + 1);

            for (int i = 100; i < cardboardNumber; i += numberN)
            {
                if (i != numberN)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
