using Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

app.MapGet("api/{table}", async (HttpContext context, DataContext data) =>
{
    var table = context.Request.RouteValues["table"] as string;
    if (table == "products")
    {
        var products = await data.Products.Include(p => p.Category).ToListAsync();
        await context.Response.WriteAsJsonAsync(products);
    }
    else if (table == "categories")
    {
        var categories = await data.Categories.Include(c => c.Products).ToListAsync();
        await context.Response.WriteAsJsonAsync(categories);
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
});

//SeedData.SeedDatabase(context);
app.Run();
