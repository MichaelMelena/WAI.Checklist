using Microsoft.AspNetCore.Components;
using WAI.Checklist.Models;
using WAI.Checklist.Services;

namespace WAI.Checklist.Shared;

public partial class Checklist
{
    private IGuidlineService? _guidlineService = null;
    private static string[] Sections = new string[] { "Perceivable", "Operable", "Understandable", "Robust" };

    [Inject]
    private IGuidlineService GuidlineService
    {
        get => _guidlineService!;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _guidlineService = value;
        }
    }

    private List<IGrouping<string, ChecklistItem>>? Items { get; set; }



    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        List<ChecklistItem> items = await GuidlineService.FilterAsync(Level.A, true);
        Items = items.GroupBy(x => x.Id.Substring(0, 1)).OrderBy(x => x.Key).ToList();
    }

}
