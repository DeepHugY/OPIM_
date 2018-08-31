
using Mobile;
using Mobile.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    public class HttpStep
    {
        private HttpMethod _httpMethod;
        public HttpStep()
        {
            _httpMethod = new HttpMethod();
        }

        public string GetRequestString(HttpParams httpParam ,string postData,ref CookieContainer cookieContainer, X509Certificate2Collection X509)
        {
            var stream = _httpMethod.HttpBaseStep(httpParam, postData, ref cookieContainer,X509);
            var value = _httpMethod.GetResponseText(stream,httpParam.ResponseEncode);
            stream.Close();
            return value;
        }
        //public string GetVCode(HttpParams httpParam, ref CookieContainer cookieContainer, X509Certificate2Collection X509)
        //{
        //    var stream = _httpMethod.HttpBaseStep(httpParam,null ,ref cookieContainer,X509);
        //    var bitmap = _httpMethod.GetBitmap(stream);
        //    var vCodeText = AnalysisVCode.GetVCodeValue(bitmap);
        //    stream.Close();
        //    return vCodeText;
        //}
        public string UpLoadImage(HttpParams httpParam,UserParams userInfo , CookieContainer cookieContainer)
        {
            //var stream = _httpMethod.HttpBaseStep(httpParam,null, ref cookieContainer);
            // string contentType = "image/jpeg";
            //待请求参数数组
            FileStream Pic = new FileStream(userInfo.Custom.PhotoUrl, FileMode.Open);
            byte[] PicByte = new byte[Pic.Length];
            Pic.Read(PicByte, 0, PicByte.Length);
            int lengthFile = PicByte.Length;
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara.Add("remote_name", "/photo01/76");
            dicPara.Add("submitted", "hello");
            //设置HttpWebRequest基本信息
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(httpParam.HttpUrl);
            //设置请求方式：get、post
            request.Method = httpParam.Method;
            //设置cookie
            request.CookieContainer = cookieContainer;
            //设置boundaryValue
            string boundaryValue = DateTime.Now.Ticks.ToString("x");
            string boundary = "--" + boundaryValue;
            request.ContentType = "\r\nmultipart/form-data; boundary=" + boundaryValue;
            //设置KeepAlive
            request.KeepAlive = true;
            //设置请求数据，拼接成字符串
            StringBuilder sbHtml = new StringBuilder();
            foreach (KeyValuePair<string, string> key in dicPara)
            {
                sbHtml.Append(boundary + "\r\nContent-Disposition: form-data; name=\"" + key.Key + "\"\r\n\r\n" + key.Value + "\r\n");
            }
            sbHtml.Append(boundary + "\r\nContent-Disposition: form-data; name=\"upfile\"; filename=\"");
            sbHtml.Append(userInfo.Custom.PhotoUrl);
            sbHtml.Append("\"\r\nContent-Type: " + httpParam.ContentType + "\r\n\r\n");
            string postHeader = sbHtml.ToString();
            //将请求数据字符串类型根据编码格式转换成字节流
            Encoding code = Encoding.GetEncoding("GBK");
            byte[] postHeaderBytes = code.GetBytes(postHeader);
            byte[] boundayBytes = Encoding.ASCII.GetBytes("\r\n" + boundary + "--\r\n");
            //设置长度
            long length = postHeaderBytes.Length + lengthFile + boundayBytes.Length;
            request.ContentLength = length;
            //请求远程HTTP
            Stream requestStream = request.GetRequestStream();
            Stream myStream = null;
            try
            {
                //发送数据请求服务器
                requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                requestStream.Write(PicByte, 0, lengthFile);
                requestStream.Write(boundayBytes, 0, boundayBytes.Length);
                HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
                myStream = HttpWResp.GetResponseStream();
            }
            catch (WebException e)
            {
                //LogResult(e.Message);
                return "";
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                }
            }
            //读取处理结果
            StreamReader reader = new StreamReader(myStream, code);
            StringBuilder responseData = new StringBuilder();
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                responseData.Append(line);
            }
            myStream.Close();
            return responseData.ToString();

        }
        //public Bitmap GetImage(HttpParams httpParam,ref CookieContainer cookieContainer, X509Certificate2Collection X509)
        //{
        //    var stream = _httpMethod.HttpBaseStep(httpParam, null,ref cookieContainer,X509);
        //    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(httpParam.HttpUrl);
        //    string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".JPEG";
        //    using (Stream fsStream = new FileStream(fileName, FileMode.Create))
        //    {
        //        stream.CopyTo(fsStream);
        //    }
        //    Bitmap bitmap = new Bitmap(stream);
        //    stream.Close();
        //    return bitmap;
        //}
    }
}
