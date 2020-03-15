using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.IO;
using Android.Content.Res;

namespace Flakesnow.Droid
{
    [Activity(Label = "Flakesnow", Icon = "@mipmap/icon", Theme = "@style/Theme.Splash", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(Resource.Style.MainTheme);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    RequestedOrientation = ScreenOrientation.Portrait;
                    break;
                case TargetIdiom.Tablet:
                    RequestedOrientation = ScreenOrientation.Landscape;
                    break;
            }

            base.OnCreate(savedInstanceState);
            Forms.Init(this, savedInstanceState);

            string dbName = "task_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(folderPath, dbName);

            LoadApplication(new App(fullPath));
        }
    }
}