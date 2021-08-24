using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace mantisproperty.Droid
{
    [Activity(Label = "mantisproperty", MainLauncher = true, Theme = "@style/Splash", NoHistory = true)]
    public class SplashScreen : Activity
    {
        WebView webView;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Display Splash Screen for 4 Sec  
            // Thread.Sleep(4000);
            //Start Activity1 Activity  
            //StartActivity(typeof(MainActivity));

            SetContentView(Resource.Layout.SplashLayout);
            System.Threading.ThreadPool.QueueUserWorkItem(o => LoadActivity());

            // WebView imageView = FindViewById<WebView>(Resource.Id.webLoadingIcon);
            webView = FindViewById<WebView>(Resource.Id.webLoadingIcon);
            webView.LoadUrl(string.Format("file:///android_asset/loader.gif"));
            // this makes it transparent so you can load it over a background
            webView.SetBackgroundColor(new Color(0, 0, 0, 0));
            webView.SetLayerType(LayerType.Software, null);


        }

        private void LoadActivity()
        {
            System.Threading.Thread.Sleep(4000); // Simulate a long pause    
            RunOnUiThread(() => StartActivity(typeof(MainActivity)));
        }
    }
}