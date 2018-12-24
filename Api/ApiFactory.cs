using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApi
{
    public class ApiFactory
    {
        public static ApiFactory Factory = new Lazy<ApiFactory>(() => new ApiFactory()).Value;
        private Dictionary<PathString, List<APiMethodInfo>> ApiCaches;
        List<string> result = new List<string>();
        private string allApis = string.Empty;
        private ApiFactory()
        {
            ApiCaches = new Dictionary<PathString, List<APiMethodInfo>>();
            var assembly = typeof(ApiFactory).Assembly;
            var types = assembly.GetTypes();
            if (types.Any())
            {
                foreach (var type in types)
                {
                    var basetype = type;
                    var baseApiAtrribue = basetype.GetCustomAttribute<ApiAttribute>();
                    if (baseApiAtrribue != null)
                    {
                        var methodInfos = basetype.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                        if (methodInfos.Any())
                        {
                            foreach (var methodInfo in methodInfos)
                            {
                                var methodApi = methodInfo.GetCustomAttribute<ApiAttribute>();
                                if (methodApi != null)
                                {
                                    var key = new ApiAttribute(methodApi.Version, methodApi.ApiName, methodApi.HttpMethod,methodApi.Description,
                                        baseApiAtrribue.GetApi()).ApiUrl;
                                    if (!ApiCaches.ContainsKey(key))
                                    {
                                        ApiCaches[key] = new List<APiMethodInfo>();
                                    }
                                    ApiCaches[key].Add(new APiMethodInfo(methodInfo, methodApi.HttpMethod));

                                    var pars = string.Empty;
                                    var paras = methodInfo.GetParameters();
                                    if (paras.Length >= 1)
                                    {
                                        pars = string.Join(",", paras.Select(o => o.ParameterType.Name + " " + o.Name).ToList());

                                    }
          
                                    result.Add($"{key} /*Parameters:({pars}) HttpMethod:{methodApi.HttpMethod} Description:{methodApi.Description}*/");
                                }
                            }
                        }
                    }
                }
            }
          
            allApis= JsonConvert.SerializeObject(result);
            result.Clear();
        }

        public const string Preix = "/api";
        


        public Task Invoke(IOwinContext context)
        {
            object result = null;
            if (ApiCaches.ContainsKey(context.Request.Path))
            {
                var request = context.Request.Body;
                var requeststream = new StreamReader(request);
                var requestArgs = requeststream.ReadToEnd();
                requeststream.Dispose();
                Console.WriteLine(context.Request.RemoteIpAddress+ " "+context.Request.Path + " " + requestArgs);
                var requestobject = JsonConvert.DeserializeObject<JObject>(requestArgs);
                MethodInfo doMethod = null;
                object[] para = new object[0];
                List<APiMethodInfo> methods = ApiCaches[context.Request.Path];
                object host = null;
                Type hostType = null;
                foreach (var temmpMethod in methods)
                {
                    var method = temmpMethod.Method;
                    hostType = method.DeclaringType;
                    bool parisError = false;
                    if (temmpMethod.HttpMethod.ToString().ToUpper() != context.Request.Method.ToUpper())
                    {
                        parisError = true;
                        result = $"interface {context.Request.Path} HttpMethod is error, except:{temmpMethod.HttpMethod.ToString().ToUpper()} give:{context.Request.Method.ToUpper()}";
                        continue;
                    }

                    if (!parisError)
                    {
                        var parameters = method.GetParameters();
                        para = new object[parameters.Length];
                        for (var index = 0; index < parameters.Length; index++)
                        {
                            var par = parameters[index];
                            if (!requestobject.ContainsKey(par.Name))
                            {
                                parisError = true;
                                result = $"interface {context.Request.Path} param is error";
                                break;
                            }
                            para[index] = requestobject[par.Name].ToObject(par.ParameterType);
                        }

                        if (requestobject != null && parameters.Length < 1)
                        {
                            parisError = true;
                            result = $"interface {context.Request.Path} param is error";
                        }
                    }

                    if (!parisError)
                    {
                        doMethod = method;
                        break;
                    }
                }

                try
                {
                  
                    if (doMethod != null)
                    {
                        host = Activator.CreateInstance(hostType);
                        result = doMethod.Invoke(host, para);
                    }
                  

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    result = $"do interface {context.Request.Path} raised is an error";
                }
            }
            else
            {
                result = "Unkown Method Request!";

            }
            if (result == null)
                result = "";
            string content = result.ToString();
            context.Response.ContentType = "text/plain";
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(content);
            context.Response.StatusCode = 200;
            context.Response.Expires = DateTimeOffset.Now;
            context.Response.Write(content);
            return Task.FromResult(0);
        }

        public string GetInterFace()
        {
            return allApis;
        }
    }
}