namespace TaskTrackerApp.Models;

public class BugReportTask : BaseTask
{
    public string SeverityLevel { get; set; } = "Low"; // Low, Medium, High
}