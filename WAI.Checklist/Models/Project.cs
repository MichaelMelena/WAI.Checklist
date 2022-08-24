namespace WAI.Checklist.Models
{
    public record class Project
    {
        public string Name { get; set; }
        public Level Level { get; set; }
        public List<ChecklistItem> Items { get; set; }
    }
}
