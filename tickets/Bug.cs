public class Bug : Ticket
{
    protected string Severity { get; set; }

    public override void ReadFromConsole()
    {
        base.ReadFromConsole();
        Console.WriteLine("Severity:");
        Severity = Console.ReadLine();
    }

    public string Serialize()
    {
        return base.Serialize() + $", {Severity}";
    }

    public override string ToString()
    {
        base.ToString() + $"Severity: {Severity}";
    }

    public static class Reader : IReader
    {
        public Bug ReadLine(string input)
        {
            Bug bug = new Bug();
            Ticket.Deserialize(bug, input);
            string[] substrings = input.Split(',');
            bug.Severity = substrings[7];
            return bug;
        }
    }
}