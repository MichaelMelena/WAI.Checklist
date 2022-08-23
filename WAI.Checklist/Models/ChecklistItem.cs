namespace WAI.Checklist.Models
{
    public record class ChecklistItem
    {
        public ChecklistItem(string id, string name, string url, Level level)
        {
            Id = id;
            Name = name;
            Uri = new Uri(url, UriKind.Absolute);
            Level = level;
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public Uri Uri { get; set; }

        public Level Level { get; set; }

        public bool IsChecked { get; set; }

        private string? Comment { get; set; }

        public void Toggle()
        {
            IsChecked = !IsChecked;
        }

    }
}
