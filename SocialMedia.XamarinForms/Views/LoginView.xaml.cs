using ReactiveUI;
using SocialMedia.XamarinForms.ViewModels;
using System.Reactive.Disposables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialMedia.XamarinForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage, IViewFor<LoginViewModel>
	{
		public LoginView()
		{
			InitializeComponent();

			this.WhenActivated(disposables =>
			{
				this.BindCommand(ViewModel, x => x.NavigateToMainPage, x => x.loginButton)
					.DisposeWith(disposables);
			});
		}

		public LoginViewModel ViewModel { get; set; }
		object IViewFor.ViewModel 
		{
			get => ViewModel; 
			set => ViewModel = (LoginViewModel)value; 
		}
	}
}