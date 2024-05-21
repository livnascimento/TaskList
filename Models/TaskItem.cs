namespace TaskList.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
