public class Enhancement : Ticket
{
    public string Software { get; set; }
    public string Cost { get; set; }
    public string Reason { get; set; }
    public string Estimate { get; set; }

    public override void ReadFromConsole()
    {
        base.ReadFromConsole();
        Console.WriteLine("Software:");
        Software = Console.ReadLine();

        Console.WriteLine("Cost:");
        Cost = Console.ReadLine();

        Console.WriteLine("Reason:");
        Reason = Console.ReadLine();

        Console.WriteLine("Estimate:");
        Estimate = Console.ReadLine();
    }

    public override string Serialize()
    {
        return base.Serialize() + $", {Software}, {Cost}, {Reason}, {Estimate}";
    }

    public override string Type()
    {
        return "Enhancement";
    }

    public override string ToString()
    {
        return base.ToString() + $"Software: {Software}, Cost: {Cost}, Reason: {Reason}, Estimate: {Estimate}";
    }

    public class Reader : IReader<Enhancement>
    {
        public List<Enhancement> ReadLines(StreamReader sr)
        {
            List<Enhancement> list = new List<Enhancement>();
            while (!sr.EndOfStream)
            {
                string input = sr.ReadLine();
                Enhancement enhancement = new Enhancement();
                Ticket.Deserialize(enhancement, input);
                string[] substrings = input.Split(',');
                enhancement.Software = substrings[7];
                enhancement.Cost = substrings[8];
                enhancement.Reason = substrings[9];
                enhancement.Estimate = substrings[10];
                list.Add(enhancement);
            }
            return list;
        }
    }
}