using TaskFlow.Domain;

namespace TaskFlow.Services;

public class TaskManager
{
    private readonly Dictionary<Guid, TaskItem> _tasks = new();

    public IReadOnlyCollection<TaskItem> Tasks => _tasks.Values;

    public TaskItem AddTask(string title)
    {
        var task = new TaskItem(title);
        _tasks.Add(task.Id, task);
        return task;
    }

    public TaskItem GetById(Guid id)
    {
        return _tasks[id]; // lanca KeyNotFoundException se nao existir
    }

    public bool CompleteTask(Guid id)
    {
        GetById(id).Complete();
        return true;
    }
}
