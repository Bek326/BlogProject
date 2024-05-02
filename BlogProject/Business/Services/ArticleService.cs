using BlogProject.Data;
using BlogProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services;

public class ArticleService
{
    private readonly BlogContext _context;

    public ArticleService(BlogContext context)
    {
        _context = context;
    }

    public void CreateArticle(Article article)
    {
        _context.Articles.Add(article);
        _context.SaveChanges();
    }

    public IEnumerable<Article> GetAllArticles()
    {
        return _context.Articles.ToList();
    }

    public Article GetByIdArticle(int id)
    {
        return _context.Articles.Find(id);
    }

    public void UpdateArticle(Article article)
    {
        _context.Entry(article).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteArticle(int id)
    {
        var article = _context.Articles.Find(id);
        if (article != null)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }
    }
}