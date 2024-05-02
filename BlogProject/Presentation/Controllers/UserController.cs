using BlogProject.Data;
using BlogProject.Models;
using BlogProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly BlogContext _context;
    private readonly UserService _userService;

    public UserController(BlogContext context, UserService userService)
    {
        _context = context;
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _userService.CreateUser(user);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        // Обновляем данные пользователя, только если они были предоставлены
        if (!string.IsNullOrEmpty(updatedUser.Username))
        {
            user.Username = updatedUser.Username;
        }
        if (!string.IsNullOrEmpty(updatedUser.Email))
        {
            user.Email = updatedUser.Email;
        }
        if (updatedUser.DateOfBirth != DateTime.MinValue)
        {
            user.DateOfBirth = updatedUser.DateOfBirth;
        }
        if (!string.IsNullOrEmpty(updatedUser.AvatarUrl))
        {
            user.AvatarUrl = updatedUser.AvatarUrl;
        }
        if (!string.IsNullOrEmpty(updatedUser.Role))
        {
            user.Role = updatedUser.Role;
        }

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return Ok();
    }
}