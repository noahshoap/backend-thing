public class Blogs : IBlogs
{
  private IList<string> _blogs = new List<string> { "hi" };
  public IEnumerable<string> GetBlogs()
  {
    return _blogs;
  }
}