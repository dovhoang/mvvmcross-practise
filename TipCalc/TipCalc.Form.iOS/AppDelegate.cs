using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using TipCalc.Form.UI;
using UIKit;

namespace TipCalc.Form.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.App, FormsApp>, Core.App, FormsApp>
    {
        // class-level declarations

        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            // Window = new UIWindow(UIScreen.MainScreen.Bounds);
            // Window.RootViewController = new UIViewController();

            // make the window visible
            // Window.MakeKeyAndVisible();
            //
            // return true;
            
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(65, 105, 225);
            UINavigationBar.Appearance.TintColor = UIColor.FromRGB(255, 255, 255);

            return base.FinishedLaunching(application, launchOptions);
        }
    }
}