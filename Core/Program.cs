using Core.Middlewares;
using Core.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/cookie", async (context) =>
    {
        if(!int.TryParse(context.Request.Cookies["counter"], out int counter))
        {
            counter = 1;
        }
        counter++;
        context.Response.Cookies.Append(
            "counter",
            (counter).ToString(),
            new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(10)
            });
        await context.Response.WriteAsync($"Counter: {counter}");
    });

app.MapGet("/clear", context =>
{
    context.Response.Cookies.Delete("counter");
    context.Response.Redirect("/");
    return Task.CompletedTask;
});

app.MapGet("/", async (context) =>
{
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
