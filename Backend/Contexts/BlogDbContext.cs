using Microsoft.EntityFrameworkCore;

public class BlogDbContext : DbContext
{
  private string _dbPath;
  public DbSet<Post> Posts { get; set; }

  public BlogDbContext()
  {
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      _dbPath = System.IO.Path.Join(path, "blogging.db");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={_dbPath}");

}