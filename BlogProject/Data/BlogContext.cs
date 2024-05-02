using BlogProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    // DbSet для каждой бизнес-модели
    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }

}