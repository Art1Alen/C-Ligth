namespace CSLight
{
    internal class Class40
    {
        static void Main()
        {
            const string AddBookCommand = "1";
            const string CommandSearchBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandDeleteBook = "4";
            const string CommandExit = "5";

            Storage storage = new Storage();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Меню Библиотеке");
                Console.WriteLine($"{AddBookCommand} - Добавить Книгу\n" +
                    $"{CommandSearchBook} - Искать Книгу\n" +
                    $"{CommandShowAllBooks} - Покозать все Книги\n" +
                    $"{CommandDeleteBook} - Удалить Книгу \n" +
                    $"{CommandExit} - Выход\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddBookCommand:
                        storage.AddBook();
                        break;

                    case CommandSearchBook:
                        storage.SearchBooks();
                        break;

                    case CommandShowAllBooks:
                        storage.ShowAllBooks();
                        break;

                    case CommandDeleteBook:
                        storage.DeleteBook();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Book
    {
        private static int _counter = 0;

        public int Id { get; private set; }
        public int IssueYear { get; private set; }
        public string Author { get; private set; }
        public string Name { get; private set; }

        public Book(string author, string name, int issueYear)
        {
            Id = ++_counter;
            Author = author;
            Name = name;
            IssueYear = issueYear;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Id}  :Имя {Name}  :Автор {Author}  :Дата Релиза {IssueYear}");
        }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();

        public Storage()
        {
            LoadBook();
        }

        public void ShowAllBooks()
        {
            foreach (Book book in _books)
            {
                book.ShowInfo();
            }
        }

        public void AddBook()
        {
            Book newBook = GetNewBook();

            _books.Add(newBook);
        }

        public void SearchBooks()
        {
            const string CommandAuthorName = "1";
            const string CommandBookName = "2";
            const string CommandrIssueYear = "3";

            Console.WriteLine("Меню поиска");
            Console.WriteLine($"{CommandAuthorName}  - Поиск по Автору\n" +
                $"{CommandBookName}  - Поиск по Название Книги\n" +
                $"{CommandrIssueYear}  - Поиск по даты Релиза\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandAuthorName:
                    ShowBooksByAutor();
                    break;

                case CommandBookName:
                    ShowBooksByName();
                    break;

                case CommandrIssueYear:
                    ShowBooksByIssueYear();
                    break;
            }
        }

        public void ShowBooksByName()
        {
            Console.WriteLine("Введите название книги");
            string bookName = Console.ReadLine().ToLower();

            foreach (Book book in _books)
            {
                if (book.Name.ToLower().Contains(bookName))
                {
                    book.ShowInfo();
                }
            }

            Console.ReadKey();
        }

        public void ShowBooksByIssueYear()
        {
            Console.WriteLine("Введите даты Релиза");

            int.TryParse(Console.ReadLine(), out int issueYear);

            foreach (Book book in _books)
            {
                if (book.IssueYear == issueYear)
                {
                    book.ShowInfo();
                }
            }
        }

        private void ShowBooksByAutor()
        {
            Console.WriteLine("Введите название Автора");
            string authorName = Console.ReadLine().ToLower();

            foreach (Book book in _books)
            {
                if (book.Author.ToLower().Contains(authorName))
                {
                    book.ShowInfo();
                }
            }

            Console.ReadKey();
        }

        public void DeleteBook()
        {
            Console.WriteLine("Введите Индеск книги");

            if (int.TryParse(Console.ReadLine(), out int index))
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (_books[i].Id == index)
                    {
                        _books.RemoveAt(i);
                    }
                }
            }
        }

        private void LoadBook()
        {
            _books.Add(new Book("Энн Эпплбаум", "Гулаг", 1602));
            _books.Add(new Book("Елена Михайлова", "Перо буможной птицы", 1597));
            _books.Add(new Book("Виктор Пелевин", "KGBT", 475));
            _books.Add(new Book("Татьяна Устинова", "Руковой подарок", 1937));
            _books.Add(new Book("Шарлотта Брандиш", "Леди из Фроингема", 1954));
            _books.Add(new Book("Ольга Примаченко", "У себе нежно", 1954));
            _books.Add(new Book("Фредрик Бакман", "Здесь была Бритт-Мари", 1867));
            _books.Add(new Book("Ремарк", "Три товариша", 2022));
            _books.Add(new Book("СССР", "ТРИ поросенка", 2022));
            _books.Add(new Book("СССР", "ТРИ танкиста", 1945));

        }

        private Book GetNewBook()
        {
            Console.WriteLine("Имя Автора");
            string authorName = Console.ReadLine();

            Console.WriteLine("Название Книги");
            string bookName = Console.ReadLine();

            Console.WriteLine("Дата Релиза");
            int issueYear;

            if (int.TryParse(Console.ReadLine(), out issueYear) == false)
            {
                Console.WriteLine("Ошибка года издания\nПриесвоен текуший год");

                issueYear = DateTime.Now.Year;
            }

            Book newBook = new Book(authorName, bookName, issueYear);

            return newBook;
        }
    }
}

