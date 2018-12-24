using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Owin;

namespace WebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ApiAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Attribute" /> class.</summary>
        public ApiAttribute(ApiVersions version, string apiName, HttpMethods httpMethod = HttpMethods.GET,string description="", params string[] rootApiName)
        {
            Version = version;
            ApiName = apiName;
            RootApiName = rootApiName;
            HttpMethod = httpMethod;
            Description = description;
        }

        public ApiAttribute(string apiName, HttpMethods httpMethod = HttpMethods.GET, string description = "") : this(ApiVersions.V1, apiName, httpMethod, description)
        {

        }
        public ApiAttribute(string apiName, HttpMethods httpMethod = HttpMethods.GET, string description = "", params string[] rootApiName) : this(ApiVersions.V1, apiName, httpMethod, description, rootApiName)
        {

        }
        public ApiVersions Version { get; private set; }
        public HttpMethods HttpMethod { get; private set; }
        public string ApiName { get; private set; }
        public string Description { get; private set; }
        public string[] RootApiName { get; private set; }



        public PathString ApiUrl
        {
            get
            {
                var pathstr = new PathString($"{ApiFactory.Preix}");
                pathstr = pathstr.Add(new PathString($"/{Version}"));
                if (RootApiName != null && RootApiName.Length > 0)
                {
                    foreach (var rootApi in RootApiName)
                    {
                        pathstr = pathstr.Add(new PathString(rootApi));
                    }
                }
                pathstr = pathstr.Add(new PathString(ApiName));
                return pathstr;
            }
        }

        public string[] GetApi()
        {
            var api = new List<string>();
            api.AddRange(RootApiName);
            api.Add(ApiName);
            return api.ToArray();
        }
    }
}