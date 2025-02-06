
public class UpdateBlogCommand : ICommand
{
  private BlogDbContext _db;
  private uint _id;
  private Post _post;

  public UpdateBlogCommand(BlogDbContext db, uint id, Post post)
  {
    _db = db;
    _id = id;
    _post = post;
  }

  public async Task<IResult> Execute()
  {
    try
    {
      var post = _db.Posts.Where(p => p.Id.Equals(_id)).FirstOrDefault();

      if (post is null)
        throw new InvalidOperationException($"Could not find post with ID {_id}.");
      
      _post.Id = _id;

      _db.Remove(post);
      await _db.AddAsync(_post);
      await _db.SaveChangesAsync();

      return Results.Ok();
    }
    catch (Exception)
    {
      return Results.StatusCode(500);
    }
  }
}
