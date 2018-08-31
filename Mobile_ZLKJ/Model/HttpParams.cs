using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Mobile.Model
{
    public class HttpParams
    {
        public string HttpUrl { set; get; }
        public string Method { set; get; }
        public string Referer { set; get; }
        public string Host { set; get; }
        //public X509Certificate2Collection X509 { set; get; }
        public string Accept { set; get; }
        public string UserAgent { set; get; }
        public string AcceptEncoding { set; get; }
        public string AcceptLanguage { set; get; }
        public string XRequestedWith { set; get; }
        public string XPrototypeVersion { set; get; }
        public string ContentType { set; get; }
        public string CacheControl { set; get; }
        public bool KeepAlive { set; get; }
        public string ResponseEncode { set; get; }
        public StringBuilder httpParams { set; get; }

        public HttpParams()
        {
            this.Accept = "text/html, application/xhtml+xml, image/jxr, */*";
            this.ContentType = "application/x-www-form-urlencoded";
            this.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729)";
            this.KeepAlive = true;
            this.AcceptEncoding = "gzip, deflate";
            this.AcceptLanguage = "zh-Hans-CN,zh-Hans;q=0.8,en-GB;q=0.5,en;q=0.3";
            this.CacheControl = "no-cache";
            this.Host = "localhost:59803";
            this.ResponseEncode = "GBK";

            this.HttpUrl = "http://localhost:59803/api/LoginAndRegist/Login";
            this.Method = "Get";
            
            //this.X509 = HttpMethod.GetX509Collection("CHINA");
        }
    }
}