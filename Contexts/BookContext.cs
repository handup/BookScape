using Microsoft.EntityFrameworkCore;

namespace BookScape.Models;

public class BookContext : DbContext
{
    
    public string DbPath { get; }
    
    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
        
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Book.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    public DbSet<Book> BookItems { get; set; } = null!;
    public DbSet<Author> AuthorItems { get; set; } = null!;
}
