using System.Reflection;
using System.Text;
using WAI.Checklist.Models;

namespace WAI.Checklist.Services
{
    public class GuidlineProvider : IGuidlineProvider
    {
        private const string ResourceName = "WAI.Checklist.Data.Items.json";
        private readonly IGuidelineParser guidelineParser;

        private bool IsReady { get; set; } = false;
        private List<Guideline> Items { get; set; } = new List<Guideline>();

        public GuidlineProvider(IGuidelineParser guidelineParser)
        {
            this.guidelineParser = guidelineParser;
        }

        public async Task<List<ChecklistItem>> FilterAsync(Level level, bool includePreviousLevels = true)
        {
            await LoadAsync();

            IEnumerable<Guideline> query;
            if (includePreviousLevels)
            {
                query = Items.Where(guideline => guideline.Level <= level);
            }
            else
            {
                query = Items.Where(guideline => guideline.Level == level);
            }

            return query.Select(guideline => new ChecklistItem(
                    guideline.Id,
                    guideline.Name,
                    guideline.Url,
                    guideline.Level))
                 .ToList();
        }

        public async Task LoadAsync()
        {
            // don't load on subsequent calls
            if (IsReady)
            {
                return;
            }

            using Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName);
            ArgumentNullException.ThrowIfNull(stream);

            using StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            string json = await streamReader.ReadToEndAsync();

            Items = guidelineParser.Parse(json);

            IsReady = true;
        }

    }
}
