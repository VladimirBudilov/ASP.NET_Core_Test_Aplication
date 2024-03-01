namespace Core.Services
{
    public class TextFormatter
    {
        private int _counter = 0;
        public async Task FormatResponse(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync($"{++_counter}");
        }
    }
}
