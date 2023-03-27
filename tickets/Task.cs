public class Task : Ticket
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

    public string Serialize()
    {
        return base.Serialize() + $", {Software}, {Cost}, {Reason}, {Estimate}";
    }

    public override string ToString()
    {
        base.ToString() + $"Software: {Software}, Cost: {Cost}, Reason: {Reason}, Estimate: {Estimate}";
    }

    public static class Reader : IReader
    {
        public Task ReadLine(string input)
        {
            Task task = new Task();
            Ticket.Deserialize(task, input);
            string[] substrings = input.Split(',');
            task.Software = substrings[7];
            task.Software = substrings[8];
            task.Software = substrings[9];
            task.Software = substrings[10];
            return task;
        }
    }
}