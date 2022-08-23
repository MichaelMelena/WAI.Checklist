﻿using WAI.Checklist.Models;

namespace WAI.Checklist.Services
{
    public interface IGuidlineService
    {
        Task<List<ChecklistItem>> FilterAsync(Level level, bool includePreviousLevels = true);
    }
}