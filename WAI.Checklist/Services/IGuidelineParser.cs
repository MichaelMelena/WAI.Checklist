using WAI.Checklist.Models;

namespace WAI.Checklist.Services
{
    public interface IGuidelineParser
    {
        List<Guideline> Parse(string json);
    }
}