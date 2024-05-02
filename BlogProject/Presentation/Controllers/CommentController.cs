using BlogProject.Models;
using BlogProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public IActionResult Create(Comment comment)
    {
        _commentService.Create(comment);
        return Ok();
    }
    
    [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
        try
        {
            // Вызываем сервис для добавления комментария
            _commentService.AddComment(comment);
                
            // Возвращаем успешный результат
            return Ok("Comment added successfully");
        }
        catch (Exception ex)
        {
            // Возвращаем ошибку в случае возникновения исключения
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet]
    public IActionResult GetAllComments()
    {
        var comments = _commentService.GetAll();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public IActionResult GetCommentById(int id)
    {
        var comment = _commentService.GetById(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateComment(int id, Comment updatedComment)
    {
        _commentService.Update(updatedComment);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteComment(int id)
    {
        _commentService.Delete(id);
        return Ok();
    }
}