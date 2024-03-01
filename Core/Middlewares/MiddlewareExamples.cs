using Core.Middlewares;
using Microsoft.Extensions.Options;

namespace Core.Middlewares;


//builder.Services.Configure<ResponseTypeOptions>(options =>
//{
//    options.ContentType = "text/plain";
//});

//var app = builder.Build();

//((IApplicationBuilder)app).Map("/branch", (branch) =>
//{
//branch.Use(async (HttpContext context, Func<Task> next) =>
//    {
//        if (!context.Response.HasStarted)
//        {
//            context.Response.ContentType = "text/plain";
//        }
//        await context.Response.WriteAsync("branch\n");
//    });
//});

//app.Use(async (context, next) =>
//{
//    if (context.Request.Path == "/short")
//    {
//        await context.Response.WriteAsync("This is a short response\n");
//    }
//    else
//    {
//        await next();
//    }
//});

//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == HttpMethods.Get)
//    {
//        context.Response.ContentType = "text/plain";
//        await context.Response.WriteAsync("before custom mw\n");
//    }

//    await next();

//    if (context.Request.Method == HttpMethods.Get)
//    {
//        await context.Response.WriteAsync("after all\n");
//    }
//});


//app.UseMiddleware<CustomMiddleware>();

//app.MapGet("/hello", async (HttpContext context, IOptions<ResponseTypeOptions> options) =>
//{
//    if (!context.Response.HasStarted)
//    {
//        context.Response.ContentType = options.Value.ContentType;
//    }

//    await context.Response.WriteAsync("Hello, world!\n");
//});
