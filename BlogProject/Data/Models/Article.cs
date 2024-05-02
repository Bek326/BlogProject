namespace BlogProject.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }

    // Добавлено новое свойство для списка тегов
    public List<string> Tags { get; set; }

    // Добавлены новые свойства для категории и изображения
    public string Category { get; set; }
    public string ThumbnailUrl { get; set; }

    // Связь с автором и комментариями
    public User Author { get; set; }
    public List<Comment> Comments { get; set; }
}