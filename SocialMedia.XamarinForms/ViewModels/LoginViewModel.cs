using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Reactive.Linq;

namespace SocialMedia.XamarinForms.ViewModels
{
	public class LoginViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment => "login";

		public IScreen HostScreen { get; private set; }

		public LoginViewModel(IScreen screen)
		{
			HostScreen = screen;

			var canNavigate = this.WhenAnyValue(
				prop => prop.UserName,
				prop => prop.Password,
				(username, password) =>
					!string.IsNullOrEmpty(username) &&
					!string.IsNullOrEmpty(password) &&
					username.Length > 3 &&
					password.Length > 8)
				.DistinctUntilChanged();
				
			NavigateToMainPage = ReactiveCommand.CreateFromObservable(() =>
			{
				return HostScreen.Router.Navigate.Execute(new MyTabbedViewModel(HostScreen));
			}, canNavigate);
		}

		public ReactiveCommand<Unit, IRoutableViewModel> NavigateToMainPage { get; set; }

		[Reactive]
		public string UserName { get; set; }

		[Reactive]
		public string Password { get; set; }
	}
}
