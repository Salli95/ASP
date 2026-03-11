using TaskTrackerApp.Models;

namespace TaskTrackerApp.Repositories;

public interface ITaskRepository
{
    IEnumerable<BaseTask> GetAll();
    void Add(BaseTask task);
    BaseTask? GetById(Guid id);
}