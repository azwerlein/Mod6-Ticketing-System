namespace Mod6
{
    static class Program
    {
        public static string bugFile = "Tickets.csv";
        public static string enhancementFile = "Enhancements.csv";
        public static string taskFile = "Tasks.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            string? choice;
            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    readTickets(new Bug.Reader(), bugFile);
                    readTickets(new Enhancement.Reader(), enhancementFile);
                    readTickets(new Task.Reader(), taskFile);
                }
                else if (choice == "2")
                {
                    writeTickets();
                }

            } while (choice == "1" | choice == "2");

            Console.WriteLine("Have a nice day!");
        }

        private static void readTickets(Ticket.IReader reader, string file)
        {
            Console.WriteLine("Reading from: " + file);
            StreamReader sr = new StreamReader(file);
            List<Ticket> lines = new List<Ticket>();
            while (!sr.EndOfStream)
            {
                lines.Add(reader.ReadLine(sr.ReadLine()));
            }
            lines.ForEach(ticket => Console.WriteLine(ticket.ToString()));
            sr.Close();
        }

        private static void writeTickets()
        {
            do
            {
                Console.WriteLine("Create a new ticket? (Y/N)");
                string? response = Console.ReadLine().ToUpper();

                if (response != "Y")
                {
                    break;
                }

                Console.WriteLine("What type of ticket?");
                Console.WriteLine("1) Bug/Defect");
                Console.WriteLine("2) Enhancement");
                Console.WriteLine("3) Task");
                response = Console.ReadLine();

                Ticket? ticket;
                StreamWriter? sw;

                switch (response)
                {
                    case null:
                        ticket = null;
                        break;
                    case "1":
                        ticket = new Bug();
                        sw = new StreamWriter(bugFile, true);
                        break;
                    case "2":
                        ticket = new Enhancement();
                        sw = new StreamWriter(enhancementFile, true);
                        break;
                    case "3":
                        ticket = new Task();
                        sw = new StreamWriter(taskFile, true);
                        break;
                }

                if (ticket == null || sw == null)
                {
                    Console.WriteLine("Invalid response!");
                    continue;
                }
                ticket.ReadFromConsole();
                sw.WriteLine(ticket.Serialize());
                Console.WriteLine("Ticket created!");
                sw.Close();
            } while (true);

        }
    }
}