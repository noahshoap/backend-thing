using Microsoft.AspNetCore.Mvc;

public static class BlogRoutes
{
  public static WebApplication MapBlogRoutes(this WebApplication app)
  {
    app.MapGet("/blogs", GetBlogCollection);
    return app;
  }

  private static async Task<IResult> GetBlogCollection(
    BlogDbContext blogDbContext)
  {
    var command = new GetBlogsCommand(blogDbContext);

    return await command.Execute();
  }
}