var builder = WebApplication.CreateBuilder(args);

// fake blog db thing for now, will be replaced by EF + real DB if
// i actually do this
builder.Services.AddSingleton<IBlogs, Blogs>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapBlogRoutes();

app.Run();
