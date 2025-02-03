using Microsoft.AspNetCore.Mvc;

public static class BlogRoutes
{
  public static WebApplication MapBlogRoutes(this WebApplication app)
  {
    app.MapGet("/blogs", GetBlogCollection);
    return app;
  }

  private static async Task<IResult> GetBlogCollection(
    BlogDbContext blogDbContext,
    [FromQuery(Name = "authorFilter")] string? authorFilter,
    [FromQuery(Name = "titleFilter")] string? titleFilter)
  {
    var command = new GetBlogsCommand(blogDbContext, authorFilter, titleFilter);

    return await command.Execute();
  }
}