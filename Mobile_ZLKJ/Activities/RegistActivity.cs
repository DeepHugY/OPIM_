
using Android.App;
using Android.OS;
using Mobile;

namespace Mobile
{
    [Activity(Label ="注册")]
   public class RegistActivity:Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Regist);
        }
    }
}