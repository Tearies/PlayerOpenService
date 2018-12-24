using Microsoft.Owin;

namespace WebApi
{
    public class ApiIndexPageOptions
    {
        public ApiIndexPageOptions()
        {
            Path=new PathString("/");
        }

        /// <summary>
        /// Specifies which requests paths will be responded to. Exact matches only. Leave null to handle all requests.
        /// </summary>
        public PathString Path { get; set; }
    }
}