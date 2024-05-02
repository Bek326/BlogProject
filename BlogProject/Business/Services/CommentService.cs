using BlogProject.Data;
using BlogProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services;

public class CommentService
{
    private readonly BlogContext _context;

    public CommentService(BlogContext context)
    {
        _context = context;
    }

    public void Create(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }
    
    public void AddComment(Comment comment)
    {
        // Установка даты создания комментария
        comment.CreateDate = DateTime.Now;

        // Сохранение комментария в базе данных
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    public IEnumerable<Comment> GetAll()
    {
        return _context.Comments.ToList();
    }

    public Comment GetById(int id)
    {
        return _context.Comments.Find(id);
    }

    public void Update(Comment comment)
    {
        _context.Entry(comment).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var comment = _context.Comments.Find(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}