using MGStandard;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;

using Microsoft.Xna.Framework;
using static Android.Views.View;


namespace MGXPlatfrm.Android
{
    [Activity(
        Label = "MGShaderTest",
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@style/Theme.Splash",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.SensorLandscape,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
    )]



 
    public class Activity1 : AndroidGameActivity, IOnSystemUiVisibilityChangeListener
    {

        private View _view;
        private CoreGame _game;


         static Activity1()//set these before any dependencies get called
        {
         
            CoreGame.IsDirectX = false;//
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

  
            _game = new CoreGame();

            _view = _game.Services.GetService(typeof(View)) as View;

            this.Window.DecorView.SetOnSystemUiVisibilityChangeListener(this);
            HideSystemUI();

            SetContentView(_view);


            _game.Run();

        }

        private void HideSystemUI()
        {
            SystemUiFlags flags = SystemUiFlags.HideNavigation | SystemUiFlags.Fullscreen | SystemUiFlags.ImmersiveSticky;
            this.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)flags;
        }

        public void OnSystemUiVisibilityChange([GeneratedEnum] StatusBarVisibility visibility)
        {
            HideSystemUI();
        }


    }
}
