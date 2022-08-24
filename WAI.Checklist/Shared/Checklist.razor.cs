using Microsoft.AspNetCore.Components;
using WAI.Checklist.Models;
using WAI.Checklist.Services;

namespace WAI.Checklist.Shared;

public partial class Checklist
{
    private IGuidlineProvider? _guidlineService = null;
    private static string[] Sections = new string[] { "Perceivable", "Operable", "Understandable", "Robust" };

    [Inject]
    private IGuidlineProvider GuidlineService
    {
        get => _guidlineService!;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _guidlineService = value;
        }
    }

    private List<IGrouping<string, ChecklistItem>>? Items { get; set; }

    [Parameter]
    public Level SelectedLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        List<ChecklistItem> items = await GuidlineService.FilterAsync(SelectedLevel, true);
        Items = items.GroupBy(x => x.Id.Substring(0, 1)).OrderBy(x => x.Key).ToList();
    }

    private async Task HandleConformanceButtonClickAsync()
    {
        await LoadAsync();
    }
}
