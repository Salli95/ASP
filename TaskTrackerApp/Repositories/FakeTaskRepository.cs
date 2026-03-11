using TaskTrackerApp.Models;

namespace TaskTrackerApp.Repositories;

public class FakeTaskRepository : ITaskRepository
{
    private readonly List<BaseTask> _tasks = new();

    public IEnumerable<BaseTask> GetAll() => _tasks;

    public void Add(BaseTask task) => _tasks.Add(task);

    public BaseTask? GetById(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);
}