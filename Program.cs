namespace Mod1
{
    static class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            StreamWriter sw = new StreamWriter("Tickets.csv");
            string? choice;
            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                if (choice == "1")
                {

                }
                else if (choice == "2")
                {
                    do
                    {
                        Console.WriteLine("Create a new ticket? (Y/N)");
                        string? response = Console.ReadLine().ToUpper();

                        if (response != "Y")
                        {
                            break;
                        }

                        Console.WriteLine("Ticket Number:");
                        string id = Console.ReadLine();

                        Console.WriteLine("Summary:");
                        string summary = Console.ReadLine();

                        Console.WriteLine("Status:");
                        string status = Console.ReadLine();

                        Console.WriteLine("Priority:");
                        string priority = Console.ReadLine();

                        Console.WriteLine("Submitter:");
                        string submitter = Console.ReadLine();

                        Console.WriteLine("Assigned:");
                        string assigned = Console.ReadLine();

                        Console.WriteLine("Watching:");
                        string watching = Console.ReadLine();

                        sw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", id, summary, status, priority, submitter, assigned);
                        Console.WriteLine("Ticket created!");
                    } while (true);
                }

            } while (choice != "1" & choice != "2");

            sw.Close();

            Console.WriteLine("Have a nice day!");
        }
    }
}