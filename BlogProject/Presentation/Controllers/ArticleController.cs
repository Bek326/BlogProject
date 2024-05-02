using BlogProject.Models;
using BlogProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ArticleService _articleService;

    public ArticleController(ArticleService articleService)
    {
        _articleService = articleService;
    }
    
    [HttpPost]
    public IActionResult CreateArticle(Article article)
    {
        try
        {
            _articleService.CreateArticle(article);
            return Ok("Article created successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet]
    public IActionResult GetAllArticles()
    {
        var articles = _articleService.GetAllArticles();
        return Ok(articles);
    }

    [HttpGet("{id}")]
    public IActionResult GetArticleById(int id)
    {
        var article = _articleService.GetByIdArticle(id);
        if (article == null)
        {
            return NotFound();
        }
        return Ok(article);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateArticle(int id, Article updatedArticle)
    {
        _articleService.UpdateArticle(updatedArticle);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteArticle(int id)
    {
        _articleService.DeleteArticle(id);
        return Ok();
    }
    
    
}