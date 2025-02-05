
public class GetBlogCommand : ICommand
{
  private BlogDbContext _db;
  private uint _id;

  public GetBlogCommand(BlogDbContext blogDbContext, uint id)
  {
    _db = blogDbContext;
    _id = id;
  }

  public async Task<IResult> Execute()
  {
    try
    {
      var post = _db.Posts.Where(p => p.Id.Equals(_id)).FirstOrDefault();

      if (post is null)
      {
        return Results.BadRequest($"No post exists with id: {_id}.");
      }

      return Results.Ok(post);
    } 
    catch (Exception)
    {
      return Results.StatusCode(500);
    }
  }
}