var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>();

var app = builder.Build();
app.MapBlogRoutes();

app.Run();
