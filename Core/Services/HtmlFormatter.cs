
namespace Core.Services
{
    public class HtmlFormatter : IResponseFomatter
    {
        private int _counter = 0;
        public async Task FormatResponse(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync($"<h2>{++_counter}</h2>");
        }
    }
}
