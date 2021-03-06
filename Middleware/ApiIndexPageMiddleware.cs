﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;


namespace WebApi
{
    public class ApiIndexPageMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _next;
        private readonly ApiIndexPageOptions _options;
        /// <summary>Creates a default web page for new applications.</summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        public ApiIndexPageMiddleware(
            Func<IDictionary<string, object>, Task> next,
            ApiIndexPageOptions options)
        {
            if (next == null)
                throw new ArgumentNullException(nameof(next));
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            this._next = next;
            this._options = options;
        }
         
        /// <summary>Process an individual request.</summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);
            IOwinRequest request = context.Request;
            if (!_options.Path.HasValue || _options.Path == request.Path)
            {
                var welcomePage = new ApiIndexPageView();
                welcomePage.Execute(context);
                return Task.FromResult(0);
            }

            return _next(environment);
        }
    }
}