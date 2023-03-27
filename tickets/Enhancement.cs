public class Enhancement : Ticket
{
    protected string ProjectName { get; set; }
    protected string DueDate { get; set; }
    
    public override void ReadFromConsole()
    {
        base.ReadFromConsole();
        Console.WriteLine("Project Name:");
        ProjectName = Console.ReadLine();

        Console.WriteLine("Due Date:");
        DueDate = Console.ReadLine();
    }

    public string Serialize()
    {
        return base.Serialize() + $", {ProjectName}, {DueDate}";
    }

    public override string ToString()
    {
        base.ToString() + $"Project Name: {ProjectName}, Due Date: {DueDate}";
    }

    public static class Reader : IReader
    {
        public Enhancement ReadLine(string input)
        {
            Enhancement enhancement = new Enhancement();
            Ticket.Deserialize(enhancement, input);
            string[] substrings = input.Split(',');
            enhancement.ProjectName = substrings[7];
            enhancement.DueDate = substrings[8];
            return enhancement;
        }
    }
}