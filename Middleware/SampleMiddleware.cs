using System.Threading.Tasks;
using Microsoft.Owin;

namespace WebApi
{
    internal class SampleMiddleware : OwinMiddleware
    {
        /// <summary>
        /// Instantiates the middleware with an optional pointer to the next component.
        /// </summary>
        /// <param name="next"></param>
        public SampleMiddleware(OwinMiddleware next) : base(next)
        {
       
        }

        #region Overrides of OwinMiddleware

        /// <summary>Process an individual request.</summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task Invoke(IOwinContext context)
        {
            return ApiFactory.Factory.Invoke(context);
        }

        #endregion
    }
}