using Core.Infrastructure;
using Core.Middlewares;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

SeedData.SeedDatabase(context);
app.Run();
