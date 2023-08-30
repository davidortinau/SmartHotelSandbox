using CarPlay;
using Foundation;
using UIKit;

namespace SmartHotelSandbox.iOS;

[Register("AppDelegate")]
public partial class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        base.FinishedLaunching(application, launchOptions);
            
        UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
        UINavigationBar.Appearance.ShadowImage = new UIImage();
        UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
        UINavigationBar.Appearance.TintColor = UIColor.White;
        UINavigationBar.Appearance.BarTintColor = UIColor.Clear;
        UINavigationBar.Appearance.Translucent = true;

        return true;
    }
}