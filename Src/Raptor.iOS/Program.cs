﻿using Foundation;
using Raptor.GameEngine.PCL;
using UIKit;

namespace Raptor.iOS {
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate {
        private static MainGame game;

        internal static void RunGame() {
            game = new MainGame();
            game.Run();
        }

        static void Main(string[] args) {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override void FinishedLaunching(UIApplication app) {
            RunGame();
        }
    }
}