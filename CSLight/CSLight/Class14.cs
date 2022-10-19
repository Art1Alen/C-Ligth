namespace CSLight
{
    internal class Class14
    {
        static void Main()
        {
            int minNumberN = 25;
            int maxNumberN = 25;
            int threeDigit = 999;

            Random random = new Random();
            int numberN = random.Next(minNumberN, maxNumberN);

            for (int i = 0; i < threeDigit; i += numberN)
            {
                if (i != numberN)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
