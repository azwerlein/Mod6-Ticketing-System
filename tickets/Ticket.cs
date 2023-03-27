public abstract class Ticket
{
    protected int Number { get; set; }
    protected string Summary { get; set; }
    protected string Status { get; set; }
    protected string Priority { get; set; }
    protected string Submitter { get; set; }
    protected string[] Assigned { get; set; }
    protected string[] Watching { get; set; }

    public Ticket() { }

    public void setAll(int Number, string Summary, string Status, string Priority, string Submitter, string[] Assigned, string[] Watching)
    {
        this.Number = Number;
        this.Summary = Summary;
        this.Status = Status;
        this.Priority = Priority;
        this.Submitter = Submitter;
        this.Assigned = Assigned;
        this.Watching = Watching;
    }

    public virtual void ReadFromConsole()
    {
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

        this.setAll(number, summary, status, priority, submitter, assigned, watching);
    }

    public virtual string Serialize()
    {
        string parsedAssigned = string.Join('|', Assigned);
        string parsedWatching = string.Join('|', Watching);
        return $"{Number}, {Summary}, {Status}, {Priority}, {Submitter}, {parsedAssigned}, {parsedWatching}";
    }

    public static void Deserialize(Ticket ticket, string input)
    {
        string[] substrings = input.Split(',');
        string[] assigned = substrings[5].Split('|');
        string[] watching = substrings[6].Split('|');

        ticket.setAll(int.Parse(substrings[0]), substrings[1], substrings[2], substrings[3], substrings[4], assigned, watching);
    }

    public override string ToString()
    {
        string parsedAssigned = string.Join(", ", Assigned);
        string parsedWatching = string.Join(", ", Watching);
        return $"ID: {Number}, Description: {Summary}, Status: {Status}, Priority: {Priority}, Submitter: {Submitter}, Assigned: {parsedAssigned}, Watching: {parsedWatching}, ";
    }

    public interface IReader
    {
        Ticket ReadLine(string input);
    }
}