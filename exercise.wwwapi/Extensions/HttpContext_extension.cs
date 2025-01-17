namespace exercise.wwwapi.Extensions
{
    public static class HttpContext_extension
    {
        public static string Get_endpointUrl<T>(this HttpContext context, T indexVal)
        {
            string schemeType = context.Request.Scheme;
            string local = context.Request.Host.ToUriComponent();
            string path = context.Request.Path;
            return string.Format($"{schemeType}://{local}{path}/{{0}}", indexVal);
        }
    }
}
