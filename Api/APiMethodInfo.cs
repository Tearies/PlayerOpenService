using System.Reflection;

namespace WebApi
{
    public class APiMethodInfo
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public APiMethodInfo(MethodInfo method, HttpMethods httpMethod)
        {
            Method = method;
            HttpMethod = httpMethod;
        }

        public MethodInfo Method { get; private set; }

        public HttpMethods HttpMethod { get; private set; }
    }
}