using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Mobile.Model;
using Mobile.Common;
using System.Security.Cryptography.X509Certificates;

namespace Mobile.Service
{
    public class HttpService
    {
        public HttpStep _httpStep;
        public HttpService()
        {
            _httpStep = new HttpStep();
        }
        public void Login(string[] stringParams, CookieContainer cookieContainer, X509Certificate2Collection X509)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.AppendFormat("'{0}':'{1}',", "account", stringParams[0]);
           
           
            sb.Append("}");
            HttpParams httpParams = new HttpParams();
            //HttpParams httpParams1 = GetPostParamsFromXML.getParams("LoginAndRegist.xml", "Login", null);
            var htmlStr1 = _httpStep.GetRequestString(httpParams, sb.ToString(), ref cookieContainer, X509);

        }
      
    }
}