using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.API;
public class Task
{
    public Task(string title)
    {
        Id = Guid.NewGuid();
        Created = DateTime.Now;
        Title = title;
    }

    public Task(Guid? userId, string title, string? description, DateTime? deadline)
    {
        Id = Guid.NewGuid();
        Created = DateTime.Now;
        UserId = userId;
        Title = title;
        Description = description;
        Deadline = deadline;
    }    

    [Key]
    public Guid Id { get; private set; }

    public DateTime Created { get; private set; }

    public DateTime? CompletedDate { get; private set; }

    public bool IsCompleted { get; private set; }

    [ForeignKey(nameof(UserId))]
    public Guid? UserId { get; private set; }

    [Required]
    public string Title { get; private set; }
    
    public string? Description { get; private set; }

    public DateTime? Deadline { get; private set; }

    public void Complete()
    {
        CompletedDate = DateTime.Now;
        IsCompleted = true;
    }

    public void Update(Guid? userId, string title, string? description, DateTime? deadline)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));

        if (deadline.HasValue && deadline.Value < DateTime.Now)
            throw new ArgumentException("Deadline cannot be in the past", nameof(deadline));

        Title = title;
        Description = description;
        Deadline = deadline;
        UserId = userId;
    }

    public void AssignTo(Guid userId)
    {
        UserId = userId;
    }

    public void Unassign()
    {
        UserId = null;
    }
}
