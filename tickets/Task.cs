public class Task : Ticket
{
    public string ProjectName { get; set; }
    public string DueDate { get; set; }

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

    public override string Type()
    {
        return "Task";
    }

    public override string ToString()
    {
        return base.ToString() + $"Project Name: {ProjectName}, Due Date: {DueDate}";
    }

    public class Reader : IReader<Task>
    {
        public List<Task> ReadLines(StreamReader sr)
        {
            List<Task> list = new List<Task>();
            while (!sr.EndOfStream)
            {
                string input = sr.ReadLine();
                Task task = new Task();
                Ticket.Deserialize(task, input);
                string[] substrings = input.Split(',');
                task.ProjectName = substrings[7];
                task.DueDate = substrings[8];
                list.Add(task);
            }
            return list;
        }
    }
}