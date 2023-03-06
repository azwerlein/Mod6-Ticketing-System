public class Ticket
{
    public int Number { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string[] Assigned { get; set; }
    public string[] Watching { get; set; }

    public Ticket() {}

    public Ticket(int Number, string Summary, string Status, string Priority, string Submitter, string[] Assigned, string[] Watching)
    {
        this.Number = Number;
        this.Summary = Summary;
        this.Status = Status;
        this.Submitter = Submitter;
        this.Assigned = Assigned;
        this.Watching = Watching;
    }

    public string Serialize()
    {
        string parsedAssigned = string.Join('|', Assigned);
        string parsedWatching = string.Join('|', Watching);
        return $"{Number}, {Summary}, {Status}, {Submitter}, {parsedAssigned}, {parsedWatching}";
    }
}