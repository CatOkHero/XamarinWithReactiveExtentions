using Android.App;
using Android.Content;
using Android.OS;
using Android.Animation;

namespace SocialMedia.XamarinForms.Droid.Activities
{
	/// <summary>
	/// Example: https://www.project-respite.com/lottie-xamarin-forms/
	/// </summary>
	[Activity(Label = "SplashActivity",
		Theme = "@style/MainTheme.Splash",
		MainLauncher = true,
		NoHistory = true,
		AllowEmbedded = true)]
	public class SplashActivity : Activity, Animator.IAnimatorListener
	{
		public void OnAnimationCancel(Animator animation)
		{
		}

		public void OnAnimationEnd(Animator animation)
		{
			using (var intent = new Intent(Application.Context, typeof(MainActivity)))
			{
				StartActivity(intent);
			}
		}

		public void OnAnimationRepeat(Animator animation)
		{
		}

		public void OnAnimationStart(Animator animation)
		{
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.SplashScreenLottieAnimationView);

			var animationView = FindViewById<Com.Airbnb.Lottie.LottieAnimationView>(Resource.Id.splashScreeLottieAnimatioView);
			animationView.AddAnimatorListener(this);
		}
	}
}