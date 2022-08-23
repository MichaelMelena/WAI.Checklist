namespace WAI.Checklist.Models;

public class Guideline
{
    public string Id { get; set; } = "0.0.0";
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public Level Level { get; set; }
}
