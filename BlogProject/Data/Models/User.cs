namespace BlogProject.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Role { get; set; }

    // Дополнительные свойства пользователя
    public string? FullName { get; set; }
    public string? Bio { get; set; }
    public bool IsActive { get; set; }

    // Связь с созданными статьями
    public List<Article> Articles { get; set; }
}