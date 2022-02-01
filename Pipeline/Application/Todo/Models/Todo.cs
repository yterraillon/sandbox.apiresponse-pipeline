namespace Application.Todo.Models;

public class Todo
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }

    public static Todo Create(string title, bool isCompleted) =>
        new()
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            IsCompleted = isCompleted
        };
}
