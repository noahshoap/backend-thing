public class Post
{
  public uint Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Author { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public DateTime Created { get; set; }
  public DateTime Modified { get; set; }
}