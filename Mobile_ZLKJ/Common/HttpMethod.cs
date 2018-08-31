using Android.Graphics;
using Mobile.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    public class HttpMethod
    {
        public HttpWebRequest GetRequest(HttpParams httpParam,string postData ,CookieContainer cookieContainer, X509Certificate2Collection X509)
        {

            //处理HttpWebRequest访问https有安全证书的问题（ 请求被中止: 未能创建 SSL/TLS 安全通道。）

            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(httpParam.HttpUrl);
            setHttpRequestHeader(request, httpParam,X509);
            request.CookieContainer = cookieContainer;
            if (httpParam.Method.ToLower() == "post"&&postData!=null)
            {
                var Data = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = Data.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(Data, 0, Data.Length);
                    stream.Close();
                }
            }
            return request;
        }
        public HttpWebResponse GetResponse(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public Stream GetResponseStream(HttpWebResponse response)
        {
            var stream = response.GetResponseStream();
            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }
            if (response.ContentEncoding.ToLower().Contains("deflate"))
            {
                stream = new DeflateStream(stream, CompressionMode.Decompress);
            }
            return stream;
        }
        public string GetResponseText(Stream stream,string encode)
        {
            StreamReader readStream = new StreamReader(stream, Encoding.GetEncoding(encode));
            var retext = readStream.ReadToEnd().ToString();
            readStream.Close();
            return retext;
        }
        //public Bitmap GetBitmap(Stream stream)
        //{
        //    Image image = Image.FromStream(stream);
        //    Bitmap bitmap = new Bitmap(image, 765, 229);
        //    return bitmap;
        //}
        public Cookie GetCookie(HttpWebResponse response)
        {
            var cookies = response.Headers.Get("Set-Cookie");
            if (cookies == null)
                return null;
            var cookiesStr = cookies.Split(';');
            Cookie cookie = new Cookie();
            var hash = cookiesStr[0].Split('=');
            cookie.Name = hash[0];
            cookie.Value = hash[1];
            cookie.Path = "/";
            if (cookiesStr.Length > 2)
            {
                if (cookiesStr[2] == "true")
                    cookie.HttpOnly = true;
                else
                    cookie.HttpOnly = false;
            }
            return cookie;
        }
        public CookieContainer GetCookieContainer(CookieContainer cookieContainer, Cookie cookie, string cookieUrl)
        {
            if (cookie == null)
                return cookieContainer;
            cookieContainer.Add(new Uri(cookieUrl), cookie);
            return cookieContainer;
        }
        public static X509Certificate2Collection GetX509Collection(string x509Name)
        {
            X509Certificate2Collection result = new X509Certificate2Collection();
            X509Store store1 = new X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser);
            X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.OpenExistingOnly);
            store1.Open(OpenFlags.OpenExistingOnly);
            X509Certificate2Collection certificates = store.Certificates;
            X509Certificate2Collection certificates1 = store1.Certificates;
            if (certificates1.Count > 0)
            {
                X509Certificate2Enumerator enumerator = certificates1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Subject.Contains(x509Name))
                        result.Add(enumerator.Current);
                }
            }
            if (certificates.Count > 0)
            {
                X509Certificate2Enumerator enumerator = certificates.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Subject.Contains(x509Name))
                        result.Add(enumerator.Current);
                }
            }
            return result;
        }
        public Stream HttpBaseStep(HttpParams httpParam,string postData ,ref CookieContainer cookieContainer, X509Certificate2Collection X509)
        {
            var request = GetRequest(httpParam, postData, cookieContainer,X509);
            var response = GetResponse(request);
            var cookie = GetCookie(response);
            cookieContainer = GetCookieContainer(cookieContainer, cookie, "http://localhost:59803/");
            return GetResponseStream(response);
        }
        public void setHttpRequestHeader(HttpWebRequest httpWebRequest, HttpParams httpParams, X509Certificate2Collection X509)
        {
            httpWebRequest.Method = httpParams.Method;
            httpWebRequest.Referer = httpParams.Referer;
            httpWebRequest.Host = httpParams.Host;
            httpWebRequest.KeepAlive = httpParams.KeepAlive;

            httpWebRequest.ServicePoint.Expect100Continue = false;
            if (httpParams.Accept != null && !httpParams.Accept.Equals(""))
            {
                httpWebRequest.Accept = httpParams.Accept;
            }
            if (httpParams.ContentType != null && !httpParams.ContentType.Equals(""))
            {
                httpWebRequest.ContentType = httpParams.ContentType;
            }
            if (httpParams.UserAgent != null && !httpParams.UserAgent.Equals(""))
            {
                httpWebRequest.UserAgent = httpParams.UserAgent;
            }
            if (httpParams.AcceptEncoding != null && !httpParams.AcceptEncoding.Equals(""))
            {
                httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, httpParams.AcceptEncoding);
            }
            if (httpParams.AcceptLanguage != null && !httpParams.AcceptLanguage.Equals(""))
            {
                httpWebRequest.Headers.Add(HttpRequestHeader.AcceptLanguage, httpParams.AcceptLanguage);
            }
            if (httpParams.CacheControl != null && !httpParams.CacheControl.Equals(""))
            {
                httpWebRequest.Headers.Add(HttpRequestHeader.CacheControl, httpParams.CacheControl);
            }
            if (httpParams.XRequestedWith != null && !httpParams.XRequestedWith.Equals(""))
            {
                httpWebRequest.Headers.Add("X-Requested-With", httpParams.XRequestedWith);
            }
            if (httpParams.XRequestedWith != null && !httpParams.XRequestedWith.Equals(""))
            {
                httpWebRequest.Headers.Add("X-Prototype-Version", httpParams.XPrototypeVersion);
            }
            //httpWebRequest.ClientCertificates = X509;
        }
    }
}
