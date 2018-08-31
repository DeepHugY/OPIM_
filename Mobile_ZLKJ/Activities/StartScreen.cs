using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;

namespace Mobile.Activities
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class StartScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
            Finish();
        }
    }

}