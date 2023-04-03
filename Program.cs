namespace Mod6
{
    static class Program
    {
        public static TicketHandler ticketReader = new TicketHandler("Tickets.csv", "Enhancements.csv", "Tasks.csv");

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            string? choice;
            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("3) Search for a ticket.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    ticketReader.readAllTickets();
                }
                else if (choice == "2")
                {
                    ticketReader.writeTickets();
                }
                else if (choice == "3")
                {
                    ticketReader.searchTickets();
                }
                Console.WriteLine("\n");

            } while (choice == "1" | choice == "2" | choice == "3");

            Console.WriteLine("Have a nice day!");
        }
    }
}
