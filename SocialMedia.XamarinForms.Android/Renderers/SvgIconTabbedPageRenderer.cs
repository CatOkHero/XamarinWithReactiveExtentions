using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using FFImageLoading.Work;
using SocialMedia.XamarinForms.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(SvgIconTabbedPageRenderer))]
namespace SocialMedia.XamarinForms.Droid.Renderers
{
	public class SvgIconTabbedPageRenderer : TabbedPageRenderer
	{
		public SvgIconTabbedPageRenderer(Context context) 
			: base(context)
		{
		}

		protected override async void SetTabIconImageSource(TabLayout.Tab tab, Drawable icon)
		{
			tab.SetIcon(icon);
			base.SetTabIconImageSource(tab, icon);
		}
	}
}