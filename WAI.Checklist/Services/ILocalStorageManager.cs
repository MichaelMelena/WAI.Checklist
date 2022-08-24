using WAI.Checklist.Models;

namespace WAI.Checklist.Services;

public interface IProjecLocalStorage
{
    Task DeleteAsync(string name, CancellationToken cancellationToken = default);
    Task<Project?> OpenAsync(string name, CancellationToken cancellationToken = default);
    Task SaveAsync(string name, Project project, CancellationToken cancellationToken = default);
    Task UpdateAsync(string name, Project project, CancellationToken cancellationToken = default);
}