﻿namespace Mod6
{
    static class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
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
                    readTickets(file);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Overwrite existing data? (Y/N)");
                    bool overwrite = Console.ReadLine().ToUpper() == "Y";
                    writeTickets(file, overwrite);
                }

            } while (choice == "1" | choice == "2");

            Console.WriteLine("Have a nice day!");
        }

        private static void readTickets(string file)
        {
            Console.WriteLine("Reading tickets...");
            StreamReader sr = new StreamReader(file);
            List<Ticket> lines = new List<Ticket>();
            while (!sr.EndOfStream)
            {
                lines.Add(Ticket.Deserialize(sr.ReadLine()));
            }
            lines.ForEach(ticket => Console.WriteLine(ticket.ToString()));
            sr.Close();
        }

        private static void writeTickets(string file, bool overwrite)
        {
            StreamWriter sw = new StreamWriter(file, !overwrite);
            do
            {
                Console.WriteLine("Create a new ticket? (Y/N)");
                string? response = Console.ReadLine().ToUpper();

                if (response != "Y")
                {
                    break;
                }

                Ticket Ticket = new Ticket();

                int number;
                bool validEntry = false;
                do
                {
                    Console.WriteLine("Ticket Number:");
                    string id = Console.ReadLine();
                    validEntry = int.TryParse(id, out number);
                    if (!validEntry)
                    {
                        Console.WriteLine($"{id} is not a valid number!");
                    }
                } while (!validEntry);

                Console.WriteLine("Summary:");
                string summary = Console.ReadLine();

                Console.WriteLine("Status:");
                string status = Console.ReadLine();

                Console.WriteLine("Priority:");
                string priority = Console.ReadLine();

                Console.WriteLine("Submitter:");
                string submitter = Console.ReadLine();

                Console.WriteLine("Assigned:");
                string assignedInput = Console.ReadLine();
                string[] assigned = assignedInput.Split('|', ',', ';');

                Console.WriteLine("Watching:");
                string watchingInput = Console.ReadLine();
                string[] watching = watchingInput.Split('|', ',', ';');

                Ticket ticket = new Ticket(number, summary, status, priority, submitter, assigned, watching);
                sw.WriteLine(ticket.Serialize());
                Console.WriteLine("Ticket created!");
            } while (true);

            sw.Close();
        }
    }
}