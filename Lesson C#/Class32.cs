namespace CSLight
{
    internal class Class32
    {
        static void Main(string[] args)
        {
            Queue<int> clients = new Queue<int>();

            clients.Enqueue(10);
            clients.Enqueue(50);
            clients.Enqueue(100);
            clients.Enqueue(150);

            int cashAmoun = 0;

            Console.WriteLine("В очереди находятся следующие клиенты:");

            ShowQueue(clients);

            while (clients.Count > 0)
            {
                ServeClient(clients, ref cashAmoun);
                ShowQueue(clients);
            }
        }

        static void ShowQueue(Queue<int> clients)
        {
            foreach (var person in clients)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadKey();
        }

        static void ServeClient(Queue<int> clients, ref int cashAmoun)
        {
            Console.Clear();
            cashAmoun += clients.Dequeue();
            Console.WriteLine("Клиент обслужен!");
            Console.WriteLine($"Баланс Кассы: {cashAmoun}");
        }
    }
}
