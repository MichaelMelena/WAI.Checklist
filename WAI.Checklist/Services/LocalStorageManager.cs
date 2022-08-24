using Blazored.LocalStorage;
using WAI.Checklist.Models;

namespace WAI.Checklist.Services;

public class ProjecLocalStorage : IProjecLocalStorage
{
    private readonly ILocalStorageService localStorageService;

    public ProjecLocalStorage(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public async Task SaveAsync(string name, Project project, CancellationToken cancellationToken = default)
    {
        await localStorageService.SetItemAsync(name, project, cancellationToken);
    }

    public async Task<Project?> OpenAsync(string name, CancellationToken cancellationToken = default)
    {
        if (await localStorageService.ContainKeyAsync(name, cancellationToken))
        {
            return await localStorageService.GetItemAsync<Project>(name, cancellationToken);
        }

        return null;
    }

    public async Task UpdateAsync(string name, Project project, CancellationToken cancellationToken = default)
    {
        await DeleteAsync(name, cancellationToken);
        await SaveAsync(name, project, cancellationToken);
    }

    public async Task DeleteAsync(string name, CancellationToken cancellationToken = default)
    {
        await localStorageService.RemoveItemAsync(name, cancellationToken);
    }
}
