public class Enhancement : Ticket
{
    protected string Software { get; set; }
    protected string Cost { get; set; }
    protected string Reason { get; set; }
    protected string Estimate { get; set; }

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

    public override string ToString()
    {
        return base.ToString() + $"Software: {Software}, Cost: {Cost}, Reason: {Reason}, Estimate: {Estimate}";
    }

    public class Reader : IReader
    {
        public Ticket ReadLine(string input)
        {
            Enhancement enhancement = new Enhancement();
            Ticket.Deserialize(enhancement, input);
            string[] substrings = input.Split(',');
            enhancement.Software = substrings[7];
            enhancement.Cost = substrings[8];
            enhancement.Reason = substrings[9];
            enhancement.Estimate = substrings[10];
            return enhancement;
        }
    }
}