namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class HttpContextAccessor : IHttpContextAccessor
    {
        private static AsyncLocal<HttpContext> _httpContextCurrent = new AsyncLocal<HttpContext>();

        public HttpContext HttpContext
        {
            get => _httpContextCurrent.Value;
            set => _httpContextCurrent.Value = value;
        }
    }
}
