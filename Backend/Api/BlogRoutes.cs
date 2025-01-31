public static class BlogRoutes
{
  public static WebApplication MapBlogRoutes(this WebApplication app)
  {
    app.MapGet("/blogTitles", GetBlogTitleCollection);
    return app;
  }

  private static IResult GetBlogTitleCollection(IBlogs blogs)
  {
    var blogTitles = blogs.GetBlogs();

    return Results.Ok(blogTitles);
  }
}