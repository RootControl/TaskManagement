using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API;
public class User
{
    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    [Key]
    public Guid Id { get; private set; }

    [Required]
    public string Name { get; private set; }

    [Required]
    public string Email { get; private set; }

    public void Update(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty", nameof(email));

        Name = name;
        Email = email;
    }
}
