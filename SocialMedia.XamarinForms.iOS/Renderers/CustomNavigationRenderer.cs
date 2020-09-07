using SocialMedia.XamarinForms;
using SocialMedia.XamarinForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// https://xamgirl.com/transparent-navigation-bar-in-xamarin-forms/
// https://evgenyzborovsky.com/2018/08/20/dynamically-changing-the-status-bar-appearance-in-xamarin-forms/
[assembly: ExportRenderer(typeof(CustomRoutedViewHost), typeof(CustomNavigationRenderer))]
namespace SocialMedia.XamarinForms.iOS.Renderers
{
    public class CustomNavigationRenderer : NavigationRenderer
    {
        public CustomNavigationRenderer()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = UIColor.Clear;
            UINavigationBar.Appearance.Translucent = true;
        }
    }
}
