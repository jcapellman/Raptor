using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Util;

using Gcm.Client;

using Raptor.GameEngine;

namespace Raptor.Android {
    [Activity(Label = "Raptor"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , ScreenOrientation = ScreenOrientation.SensorLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity {
        private void RegisterWithGCM() {
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);
            
            Log.Info("MainActivity", "Registering...");
            GcmClient.Register(this, Library.Common.Constants.SenderID);
        }

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            RegisterWithGCM();

            var g = new MainGame();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();
        }
    }
}