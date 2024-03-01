using Core.Middlewares;
using Core.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IResponseFomatter, HtmlFormatter>(); 
//builder.Services.AddTransient<IResponseFomatter, TextFormatter>();
//builder.Services.Add<IResponseFomatter, HtmlFormatter>();

var app = builder.Build();

app.MapGet("/format", async (HttpContext context, IResponseFomatter formatter) =>
    {
       await formatter.FormatResponse(context);
    });
app.UseStaticFiles();
app.Run();
