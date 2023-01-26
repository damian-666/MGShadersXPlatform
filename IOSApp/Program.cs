using Foundation;
using System;
using UIKit;


using MGCore;

namespace IOSApp
{
    [Register("AppDelegate")]
    internal class Program : UIApplicationDelegate
    {
     

        internal static void RunGame()
        {
            var game=new GraphicsTestRig();
            game.Run();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, typeof(Program));
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
    }
}
