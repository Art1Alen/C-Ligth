namespace CSLight
{
    class Class1
    {
        static void Main()
        {
            string name;
            string zodiacSign;
            string placeOfWork;

            int age;

            Console.WriteLine("Как вас завуд.");
            name = Console.ReadLine();                
            Console.WriteLine("Сколько вам лет.");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Какой ваш знак зодиака");
            zodiacSign = Console.ReadLine();
            Console.WriteLine("Где вы работаете?.");
            placeOfWork = Console.ReadLine();
            Console.Clear();      
            Console.WriteLine($"Вас зовуд {name} вам {age} год.  Ваш знак Зодиака {zodiacSign} и работаете в {placeOfWork}");
        }
    }
}
