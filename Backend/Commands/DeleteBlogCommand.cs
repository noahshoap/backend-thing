
public class DeleteBlogCommand : ICommand
{
  private BlogDbContext _db;
  private uint _id;

  public DeleteBlogCommand(BlogDbContext db, uint id)
  {
    _db = db;
    _id = id;
  }

  public async Task<IResult> Execute()
  {
    try
    {
      var post = _db.Posts.Where(p => p.Id.Equals(_id)).FirstOrDefault();

      if (post is null)
        throw new InvalidOperationException($"Could not find post with ID {_id}.");

      _db.Remove(post);
      await _db.SaveChangesAsync();

      return Results.Ok();
    }
    catch (Exception)
    {
      return Results.StatusCode(500);
    }
  }
}
