public class Ticket
{
    protected int Number { get; set; }
    protected string Summary { get; set; }
    protected string Status { get; set; }
    protected string Priority { get; set; }
    protected string Submitter { get; set; }
    protected string[] Assigned { get; set; }
    protected string[] Watching { get; set; }

    public Ticket() {}

    public Ticket(int Number, string Summary, string Status, string Priority, string Submitter, string[] Assigned, string[] Watching)
    {
        this.Number = Number;
        this.Summary = Summary;
        this.Status = Status;
        this.Priority = Priority;
        this.Submitter = Submitter;
        this.Assigned = Assigned;
        this.Watching = Watching;
    }

    public string Serialize()
    {
        string parsedAssigned = string.Join('|', Assigned);
        string parsedWatching = string.Join('|', Watching);
        return $"{Number}, {Summary}, {Status}, {Priority}, {Submitter}, {parsedAssigned}, {parsedWatching}";
    }

    public static Ticket Deserialize(string input)
    {
        string[] substrings = input.Split(',');
        string[] assigned = substrings[5].Split('|');
        string[] watching = substrings[6].Split('|');

        return new Ticket(int.Parse(substrings[0]), substrings[1], substrings[2], substrings[3], substrings[4], assigned, watching);
    }

    public override string ToString()
    {
        string parsedAssigned = string.Join(", ", Assigned);
        string parsedWatching = string.Join(", ", Watching);
        return $"ID: {Number}, Description: {Summary}, Status: {Status}, Priority: {Priority}, Submitter: {Submitter}, Assigned: {parsedAssigned}, Watching: {parsedWatching}";
    }
}