using System;
using System.Globalization;

namespace WebApi
{
    internal class ApiIndexPageView : BaseMiddlewareView
    {
        public override void Execute()
        {
            this.Response.ContentType = "text/html";
            this.WriteLiteral("\r\n<!DOCTYPE html>\r\n<html");
            this.WriteAttribute<object>("lang", Tuple.Create<string, int>(" lang=\"", 85), Tuple.Create<string, int>("\"", 167), Tuple.Create<Tuple<string, int>, Tuple<object, int>, bool>(Tuple.Create<string, int>("", 92), Tuple.Create<object, int>((object)CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, 92), false));
            this.WriteLiteral(">\r\n<head>\r\n    <meta");
            this.WriteLiteral(" charset=\"utf-8\"");
            this.WriteLiteral(" />\r\n    <title>");
            this.Write("VBI OpenService");
            this.WriteLiteral("</title>\r\n");
            this.WriteLiteral("<body>");
            foreach (var api in ApiFactory.Factory.ApiIndexList)
            {
                this.WriteLiteral($"<i>{api}</i>");
            }
            this.WriteLiteral("</body>");
        }
    }
}