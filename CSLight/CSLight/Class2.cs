namespace CSLight
{
    class Class2
    {
        static void Main(string[] strings)
        {
            int numberOfPictures = 52;
            int numberOfPicturesInRow = 3;

            int numberOfRows = numberOfPictures % numberOfPicturesInRow;

            Console.WriteLine($"{numberOfRows} Осталось картинок\n картин в ряд");
        }
    }
}