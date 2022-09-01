namespace CSLight
{
    class Class2
    {
        static void Main(string[] strings)
        {
            int numberOfPictures = 52;
            int numberOfPicturesInRow = 3;
            int numberOfRows = numberOfPictures / numberOfPicturesInRow;
            int restOfThePaintings = numberOfPictures % numberOfPicturesInRow;

            Console.WriteLine($"{RestOfThePaintings} Осталось картинок\n{numberOfRows} картин в ряд");
        }
    }
}