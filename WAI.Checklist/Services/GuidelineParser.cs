using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using WAI.Checklist.Models;

namespace WAI.Checklist.Services;

public class GuidelineParser : IGuidelineParser
{
    private readonly JsonSerializerOptions options;
    public GuidelineParser()
    {
        options = ConfigureOptions();
    }

    private JsonSerializerOptions ConfigureOptions()
    {
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        return jsonSerializerOptions;
    }

    public List<Guideline> Parse(string json)
    {

        List<Guideline>? guidelines = JsonSerializer.Deserialize<List<Guideline>>(json, options);
        ArgumentNullException.ThrowIfNull(guidelines);

        return guidelines;
    }
}
