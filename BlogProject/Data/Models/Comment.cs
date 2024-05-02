using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models;

public class Comment
{
    public int Id { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }

    // Идентификаторы для связей с автором, родительской статьей и родительским комментарием
    public int? AuthorId { get; set; }
    public int? ParentArticleId { get; set; }
    public int? ParentCommentId { get; set; }

    // Навигационные свойства для доступа к связанным объектам
    public virtual User? Author { get; set; }
    public virtual Article? ParentArticle { get; set; }
    public virtual Comment? ParentComment { get; set; }
}