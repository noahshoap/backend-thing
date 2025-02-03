using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class GetBlogsCommand : ICommand
{
  private BlogDbContext _db;
  private string? _authorFilter;
  private string? _titleFilter;

  public GetBlogsCommand(BlogDbContext blogDbContext, string? authorFilter = null, string? titleFilter = null)
  {
    _db = blogDbContext ?? throw new ArgumentNullException();
    _authorFilter = authorFilter;
    _titleFilter = titleFilter;
  }

  public async Task<IResult> Execute()
  {
    try
    {
      IEnumerable<Post> posts = _db.Posts;
 
      if (_authorFilter is not null)
      {
        posts = posts.Where(p => p.Author.Equals(_authorFilter));
      }

      if (_titleFilter is not null)
      {
        posts = posts.Where(p => p.Title.Contains(_titleFilter));
      }
      
      return Results.Ok(posts); 
    }
    catch (Exception)
    {
      return Results.StatusCode(500);
    }
  }
}