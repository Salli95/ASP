using Microsoft.AspNetCore.Mvc;
using TaskTrackerApp.Models;
using TaskTrackerApp.Repositories;

namespace TaskTrackerApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    // Вот тут работает Dependency Injection (DI)
    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    // GET /api/tasks — получить все задачи
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repository.GetAll());
    }

    // POST /api/tasks/bug — создать баг
    [HttpPost("bug")]
    public IActionResult CreateBug([FromBody] BugReportTask bug)
    {
        _repository.Add(bug);
        return CreatedAtAction(nameof(GetAll), new { id = bug.Id }, bug);
    }

    // PUT /api/tasks/{id}/complete — завершить задачу
    [HttpPut("{id}/complete")]
    public IActionResult Complete(Guid id)
    {
        var task = _repository.GetById(id);
        if (task == null) return NotFound();

        task.CompleteTask(); // Это запустит наше событие из Блока 1!
        return Ok(new { message = $"Task {id} completed", status = task.IsCompleted });
    }
}