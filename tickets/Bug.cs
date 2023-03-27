public class Bug : Ticket
{
    protected string Severity { get; set; }

    public override void ReadFromConsole()
    {
        base.ReadFromConsole();
        Console.WriteLine("Severity:");
        Severity = Console.ReadLine();
    }

    public override string Serialize()
    {
        return base.Serialize() + $", {Severity}";
    }

    public override string ToString()
    {
        return base.ToString() + $"Severity: {Severity}";
    }

    public class Reader : IReader
    {
        public Ticket ReadLine(string input)
        {
            Bug bug = new Bug();
            Ticket.Deserialize(bug, input);
            string[] substrings = input.Split(',');
            bug.Severity = substrings[7];
            return bug;
        }
    }
}