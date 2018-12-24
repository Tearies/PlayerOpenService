using System;
using Microsoft.Owin;
using Owin;

namespace WebApi
{
    public static class ApiIndexPageExtensions
    {
        /// <summary>
        /// Adds the WelcomePageMiddleware to the pipeline with the given options.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IAppBuilder UseApiIndexPage(
            this IAppBuilder builder,
            ApiIndexPageOptions options)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            return builder.Use((object)typeof(ApiIndexPageMiddleware), (object)options);
        }

        /// <summary>
        /// Adds the WelcomePageMiddleware to the pipeline with the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IAppBuilder UseApiIndexPage(this IAppBuilder builder, PathString path)
        {
            return builder.UseApiIndexPage(new ApiIndexPageOptions()
            {
                Path = path
            });
        }

        /// <summary>
        /// Adds the WelcomePageMiddleware to the pipeline with the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IAppBuilder UseApiIndexPage(this IAppBuilder builder, string path)
        {
            return builder.UseApiIndexPage(new ApiIndexPageOptions()
            {
                Path = new PathString(path)
            });
        }

        /// <summary>Adds the WelcomePageMiddleware to the pipeline.</summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IAppBuilder UseApiIndexPage(this IAppBuilder builder)
        {
            return builder.UseApiIndexPage(new ApiIndexPageOptions());
        }
    }
}