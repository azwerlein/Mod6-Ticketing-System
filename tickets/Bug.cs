public class Bug : Ticket
{
    public string Severity { get; set; }

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

    public override string Type()
    {
        return "Bug";
    }

    public override string ToString()
    {
        return base.ToString() + $"Severity: {Severity}";
    }

    public class Reader : IReader<Bug>
    {
        public List<Bug> ReadLines(StreamReader sr)
        {
            List<Bug> list = new List<Bug>();
            while (!sr.EndOfStream)
            {
                String input = sr.ReadLine();
                Bug bug = new Bug();
                Ticket.Deserialize(bug, input);
                string[] substrings = input.Split(',');
                bug.Severity = substrings[7];
                list.Add(bug);
            }
            return list;
        }
    }
}