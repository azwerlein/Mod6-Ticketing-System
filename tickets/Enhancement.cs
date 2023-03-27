public class Task : Ticket
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

    public override string Serialize()
    {
        return base.Serialize() + $", {ProjectName}, {DueDate}";
    }

    public override string ToString()
    {
        return base.ToString() + $"Project Name: {ProjectName}, Due Date: {DueDate}";
    }

    public class Reader : IReader
    {
        public Ticket ReadLine(string input)
        {
            Task task = new Task();
            Ticket.Deserialize(task, input);
            string[] substrings = input.Split(',');
            task.ProjectName = substrings[7];
            task.DueDate = substrings[8];
            return task;
        }
    }
}