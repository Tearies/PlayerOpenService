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
            this.Write($"{ApiFactory.ServiceName}");
            this.WriteLiteral("</title>\r\n");
            this.WriteLiteral("<style>*{user-select: none; -webkit-user-select: none; -khtml-user-select: none; -moz-user-select: none; -ms-user-select: none; cursor: default;}  #vertext{text-align:right;} #verheader{font-size:20px; color:#f00; } #headertext{text-align:center;} #header{font-size:24px; } #api{font-size:16px;color: #111; cursor: pointer;} #api:hover{color: #0088ff;} #api:active{color: #0088ff;}</style>");
            this.WriteLiteral("<body>");
            this.WriteLiteral($"<div id='header'><H1 id='headertext'>{ApiFactory.ServiceName}</H1></div>");
            this.WriteLiteral($"<div id='verheader'><H4 id='vertext'>version:{ApiFactory.ApiVer}</H4></div>");
            int offset = 1;
            foreach (var api in ApiFactory.Factory.ApiIndexList)
            {
                this.WriteLiteral($"<div id='api'>{offset++}.{api}</div>");
            }
            this.WriteLiteral("</body>");
        }
    }
}