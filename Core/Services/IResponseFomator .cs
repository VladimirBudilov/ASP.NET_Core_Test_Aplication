namespace Core.Services
{
    public interface IResponseFomatter
    {
        public Task FormatResponse(HttpContext context);
    }
}
