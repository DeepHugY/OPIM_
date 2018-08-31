
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.IO;
using Java.Net;
using Mobile.Model;
using Mobile.Service;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Mobile.Activities
{
    [Activity(Label = "Login")]
    public class LoginActivity : Activity
    {
        public HttpService _httpService;
        X509Certificate2Collection X509 = null;

        string url = "http://10.0.2.2:53218/api/values";
        public LoginActivity()
        {
            this._httpService = new HttpService();
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.login);
            //this.X509 = GetX509Collection("CHINA");
            TextView goRegist = FindViewById<TextView>(Resource.Id.goRegest);
            Button loginButton = FindViewById<Button>(Resource.Id.login_btn);
            goRegist.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(RegistActivity));
                StartActivity(intent);
            };
            loginButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);

                //HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //request.Method = "GET";
                //var result = request.GetResponse();
                //HttpParams httpParams = new HttpParams();

                //_httpService.Login(new string[] { "sunyan"}, new CookieContainer(), this.X509);

                //string result = GetApiResult(url);

                //string a = result;
            };
        }

        //public string GetURLRespones(string urlStr)
        //{
        //    string resultStr = "";

        //    //HttpURLConnection conn = null; //连接对象

        //    Stream stream = null;

        //    try
        //    {
        //        //URL url = new URL(urlStr);
        //        //conn = (HttpURLConnection)url.OpenConnection();
        //        //conn.DoInput = true;
        //        //conn.DoOutput = true;
        //        //conn.UseCaches = false;
        //        //conn.RequestMethod = "GET";
        //        //stream = conn.InputStream;



        //        //InputStreamReader reader = new InputStreamReader(stream);
        //        //BufferedReader bfReader = new BufferedReader(reader);

        //        //string inputLine = "";
        //        //while ((inputLine = bfReader.ReadLine()) != null)
        //        //{
        //        //    resultStr += "\n";
        //        //}






        //    }
        //    catch (System.Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally {
        //        //if (stream!=null)
        //        //{
        //        //    try
        //        //    {
        //        //        stream.Close();
        //        //    }
        //        //    catch (System.IO.IOException e)
        //        //    {
        //        //        throw e;
        //        //    }
        //        //}

        //        //if (conn!=null)
        //        //{
        //        //    conn.Disconnect();
        //        //}
        //    }

        //    return resultStr;
        //}

        public static string GetApiResult(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/json;chartset=UTF-8";
            //request.UserAgent = "";
            request.Method = "Get";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            string retString = streamReader.ReadToEnd();
            return retString;
        }


        //public X509Certificate2Collection GetX509Collection(string x509Name)
        //{
        //    X509Certificate2Collection result = new X509Certificate2Collection();
        //    X509Store store1 = new X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser);
        //    X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
        //    store.Open(OpenFlags.OpenExistingOnly);
        //    store1.Open(OpenFlags.OpenExistingOnly);
        //    X509Certificate2Collection certificates = store.Certificates;
        //    X509Certificate2Collection certificates1 = store1.Certificates;
        //    if (certificates1.Count > 0)
        //    {
        //        X509Certificate2Enumerator enumerator = certificates1.GetEnumerator();
        //        while (enumerator.MoveNext())
        //        {
        //            if (enumerator.Current.Subject.Contains(x509Name))
        //                result.Add(enumerator.Current);
        //        }
        //    }
        //    if (certificates.Count > 0)
        //    {
        //        X509Certificate2Enumerator enumerator = certificates.GetEnumerator();
        //        while (enumerator.MoveNext())
        //        {
        //            if (enumerator.Current.Subject.Contains(x509Name))
        //                result.Add(enumerator.Current);
        //        }
        //    }
        //    return result;
        //}
    }
}