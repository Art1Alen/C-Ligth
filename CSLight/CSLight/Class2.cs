namespace CSLight
{
    class Class2
    {
        static void Main(string[] strings)
        {
            int numberOfPictures = 52;
            int numberOfPicturesInRow = 3;
            int numberOfRows;
            int extraPictures;

            numberOfRows = numberOfPictures % numberOfPicturesInRow;
            extraPictures = numberOfPictures / numberOfPicturesInRow;

            Console.WriteLine($"{numberOfRows} Осталось картинок\n{extraPictures} картин в ряд");
        }
    }
}