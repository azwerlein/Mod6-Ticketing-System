public class TicketHandler
{
    public string bugFile { get; set; }
    public string enhancementFile { get; set; }
    public string taskFile { get; set; }

    public List<Bug> Bugs { get; set; }
    public List<Enhancement> Enhancements { get; set; }
    public List<Task> Tasks { get; set; }

    public TicketHandler(string bugPath, string enhancementPath, string taskPath)
    {
        bugFile = bugPath;
        enhancementFile = enhancementPath;
        taskFile = taskPath;
        Bugs = new List<Bug>();
        Enhancements = new List<Enhancement>();
        Tasks = new List<Task>();
    }

    public void readAllTickets()
    {
        Bugs = readTickets(new Bug.Reader(), bugFile);
        Enhancements = readTickets(new Enhancement.Reader(), enhancementFile);
        Tasks = readTickets(new Task.Reader(), taskFile);
    }

    private List<T> readTickets<T>(Ticket.IReader<T> reader, string file) where T : Ticket
    {
        Console.WriteLine("Reading from: " + file);
        List<T> list = refreshTickets(reader, file);
        list.ForEach(ticket => Console.WriteLine(ticket.ToString()));
        return list;
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

    public void searchTickets()
    {
        refreshAllTickets();

        Console.WriteLine("Please select a search criterion.");
        Console.WriteLine("1) Status");
        Console.WriteLine("2) Priority");
        Console.WriteLine("3) Submitter");
        string response = Console.ReadLine().ToLower();

        Console.WriteLine("Please enter a search term");
        string term = Console.ReadLine().ToLower();

        Func<Ticket, bool> criterion;
        if (response == "1" | response == "status")
        {
            criterion = ticket => ticket.Status.ToLower() == term;
        }
        else if (response == "2" | response == "priority")
        {
            criterion = ticket => ticket.Priority.ToLower() == term;
        }
        else if (response == "3" | response == "submitter")
        {
            criterion = ticket => ticket.Submitter.ToLower() == term;
        }
        else
        {
            Console.WriteLine("Invalid search criterion! \n");
            return;
        }

        var results = Bugs.Where(criterion).Concat(Enhancements.Where(criterion)).Concat(Tasks.Where(criterion));
        Console.WriteLine($"Search results: {results.Count()}");
        foreach (var ticket in results)
        {
            Console.WriteLine(ticket);
        }
    }

    private void refreshAllTickets()
    {
        Bugs = refreshTickets(new Bug.Reader(), bugFile);
        Enhancements = refreshTickets(new Enhancement.Reader(), enhancementFile);
        Tasks = refreshTickets(new Task.Reader(), taskFile);
    }

    private List<T> refreshTickets<T>(Ticket.IReader<T> reader, string file) where T : Ticket
    {
        StreamReader sr = new StreamReader(file);
        List<T> list = reader.ReadLines(sr);
        sr.Close();
        return list;
    }
}