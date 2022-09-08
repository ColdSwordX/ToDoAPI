namespace ToDo_Client.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; } = false;
        public Priority Priority { get; set; } = 0;
        public DateTime CreatedTimeStamp { get; set; } = DateTime.Now;
    }
    public enum Priority
    {
        Low,
        Normal,
        High
    }
}
