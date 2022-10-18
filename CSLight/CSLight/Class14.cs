namespace CSLight
{
    internal class Class14
    {
        static void Main()
        {
            int minNumberN = 1;
            int maxNumberN = 27;
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
