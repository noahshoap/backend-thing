using Microsoft.AspNetCore.Mvc;

public static class BlogRoutes
{
  public static WebApplication MapBlogRoutes(this WebApplication app)
  {
    app.MapGet("/blogs", GetBlogCollection);
    app.MapGet("/blog/{id}", GetBlog);
    app.MapPost("/blog", CreateBlog);
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

  private static async Task<IResult> GetBlog(
    BlogDbContext blogDbContext,
    [FromRoute] uint id)
  {
    var command = new GetBlogCommand(blogDbContext, id);

    return await command.Execute();
  }

  private static async Task<IResult> CreateBlog(
    BlogDbContext blogDbContext,
    [FromBody] Post newPost)
  {
    var command = new CreateBlogCommand(blogDbContext, newPost);

    return await command.Execute();
  }
}