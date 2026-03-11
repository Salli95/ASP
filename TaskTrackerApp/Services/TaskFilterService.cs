using TaskTrackerApp.Models;

namespace TaskTrackerApp.Services;

public static class TaskFilterService
{
    // 1. Список незавершенных багов с высоким приоритетом (сортировка по дате)
    public static IEnumerable<BugReportTask> GetHighSeverityBugs(IEnumerable<BaseTask> tasks)
    {
        return tasks.OfType<BugReportTask>()
            .Where(t => !t.IsCompleted && t.SeverityLevel == "High")
            .OrderByDescending(t => t.CreatedAt);
    }

    // 2. Сумма часов для незавершенных фич
    public static double GetTotalEstimatedHours(IEnumerable<BaseTask> tasks)
    {
        return tasks.OfType<FeatureRequestTask>()
            .Where(t => !t.IsCompleted)
            .Sum(t => t.EstimatedHours);
    }
}