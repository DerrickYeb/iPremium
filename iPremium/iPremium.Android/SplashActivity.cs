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

namespace iPremium.Droid
{
    [Activity(Label = "iPremium", Icon = "@mipmap/ic_launcher", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity:global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}