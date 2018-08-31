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
using Mobile.Model;
using System.IO;
using System.Xml;
using HtmlAgilityPack;

namespace Mobile.Common
{
    public class GetPostParamsFromXML
    {
        public static HttpParams getParams(string xmlPath, string url, string[] list)
        {
            HttpParams httpParams = new HttpParams();

            //string basePath = Directory.GetCurrentDirectory() + @"\XML\";
            string basePath = @"\XML\";

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(@basePath + xmlPath);
            HtmlNodeCollection rootNodeList = doc.DocumentNode.SelectNodes("/params/content[@id='" + url + "'][1]");

            int listIndex = 0;
            foreach (HtmlNode param in rootNodeList)
            {
                string httpurl = param.Attributes["url"].Value.Replace("&amp;", "&");
                httpurl = ReplaceSpecialChar(ref httpurl, ref listIndex, list);
                string referer = param.Attributes["referer"].Value.Replace("&amp;", "&");
                referer = ReplaceSpecialChar(ref referer, ref listIndex, list);
                httpParams.HttpUrl = httpurl;
                httpParams.Method = param.Attributes["method"].Value;
                httpParams.Referer = referer;
                httpParams.Host = param.Attributes["host"].Value;

                if (param.Attributes["accept"] != null)
                {
                    httpParams.Accept = param.Attributes["accept"].Value;
                }
                if (param.Attributes["userAgent"] != null)
                {
                    httpParams.UserAgent = param.Attributes["userAgent"].Value;
                }
                if (param.Attributes["acceptEncoding"] != null)
                {
                    httpParams.AcceptEncoding = param.Attributes["acceptEncoding"].Value;
                }
                if (param.Attributes["acceptLanguage"] != null)
                {
                    httpParams.AcceptLanguage = param.Attributes["acceptLanguage"].Value;
                }
                if (param.Attributes["xRequestedWith"] != null)
                {
                    httpParams.XRequestedWith = param.Attributes["xRequestedWith"].Value;
                }
                if (param.Attributes["xPrototypeVersion"] != null)
                {
                    httpParams.XPrototypeVersion = param.Attributes["xPrototypeVersion"].Value;
                }
                if (param.Attributes["contentType"] != null)
                {
                    httpParams.ContentType = param.Attributes["contentType"].Value;
                }
                if (param.Attributes["cacheControl"] != null)
                {
                    httpParams.CacheControl = param.Attributes["cacheControl"].Value;
                }
                if (param.Attributes["keepAlive"] != null)
                {
                    if (param.Attributes["keepAlive"].Value == "true")
                    {
                        httpParams.KeepAlive = true;
                    }
                    else if (param.Attributes["keepAlive"].Value == "false")
                    {
                        httpParams.KeepAlive = false;
                    }
                }
                if (param.Attributes["responseEncode"] != null)
                {
                    httpParams.ResponseEncode = param.Attributes["responseEncode"].Value;
                }
            }
            HtmlNodeCollection paramsList = doc.DocumentNode.SelectNodes("/params/content[@id='" + url + "']/propery");
            if (paramsList != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                int count = paramsList.Count();
                int i = 0;
                foreach (HtmlNode param in paramsList)
                {
                    i++;
                    string key = param.Attributes["name"].Value;
                    var encode = param.Attributes["encode"];
                    string value = param.InnerText;
                    if (value == "@")
                    {
                        value = list[listIndex];
                        listIndex++;
                    }
                    else if (value.Contains("@"))
                    {
                        value = ReplaceSpecialChar(ref value, ref listIndex, list);
                        //listIndex++;
                    }
                }
                httpParams.httpParams = stringBuilder;
            }
            return httpParams;
        }
        private static string ReplaceSpecialChar(ref string specialString, ref int listIndex, string[] list)
        {
            string result = "";
            if (specialString.Contains("@"))
            {
                string[] temp = specialString.Split('@');
                int i = 0;
                for (; i < temp.Length - 1; i++)
                {
                    result += temp[i] + list[listIndex];
                    listIndex++;
                }
                result += temp[temp.Length - 1];
            }
            else
            {
                result = specialString;
            }
            return result;
        }
    }
}