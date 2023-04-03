public class TicketHandler
{
    public string bugFile { get; set; }
    public string enhancementFile { get; set; }
    public string taskFile { get; set; }

    public List<Bug> Bugs { get; set; }

    public TicketHandler(string bugPath, string enhancementPath, string taskPath)
    {
        bugFile = bugPath;
        enhancementFile = enhancementPath;
        taskFile = taskPath;
        Bugs = new List<Bug>();
    }

    public void readAllTickets()
    {
        readTickets(new Bug.Reader(), bugFile);
        readTickets(new Enhancement.Reader(), enhancementFile);
        readTickets(new Task.Reader(), taskFile);
    }

    private void readTickets(Ticket.IReader reader, string file)
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

    public void writeTickets()
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

            Ticket? ticket = null;
            StreamWriter? sw = null;

            switch (response)
            {
                case null:
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