using ReactiveUI;
using System.Reactive;

namespace SocialMedia.XamarinForms.ViewModels
{
	public class LoginViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment => "login";

		public IScreen HostScreen { get; private set; }

		public LoginViewModel(IScreen screen)
		{
			HostScreen = screen;

			NavigateToMainPage = ReactiveCommand.CreateFromObservable(() =>
			{
				return HostScreen.Router.Navigate.Execute(new MyTabbedViewModel(HostScreen));
			});
		}

		public ReactiveCommand<Unit, IRoutableViewModel> NavigateToMainPage { get; set; }
	}
}
