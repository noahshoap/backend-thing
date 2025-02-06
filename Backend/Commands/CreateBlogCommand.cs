
public class CreateBlogCommand : ICommand
{
  private BlogDbContext _db;
  private Post _newPost;

  public CreateBlogCommand(BlogDbContext blogDbContext, Post newPost)
  {
    _db = blogDbContext;
    _newPost = newPost;
  }

  public async Task<IResult> Execute()
  {
    try
    {
      _newPost.Created = DateTime.UtcNow;
      _newPost.Modified = DateTime.UtcNow;

      await _db.AddAsync(_newPost);
      await _db.SaveChangesAsync();

      return Results.Ok($"Created post: {_newPost.Id}");
    }
    catch (Exception)
    {
      return Results.BadRequest("Failed to create blog post.");
    }
  }
}