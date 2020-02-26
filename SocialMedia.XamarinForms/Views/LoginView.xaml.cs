﻿using ReactiveUI;
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
			animationView.PlayProgressSegment(0.65f, (Device.RuntimePlatform != Device.Tizen) ? 0.0f : 1.0f);
			animationView.PlayFrameSegment(50, (Device.RuntimePlatform != Device.Tizen) ? 1 : 100);
			this.WhenActivated(disposables =>
			{
				this.Bind(ViewModel, vm => vm.UserName, v => v.username.Text);
				this.Bind(ViewModel, vm => vm.Password, v => v.password.Text);
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

		private void animationView_OnClick(object sender, System.EventArgs e)
		{

		}

		private void animationView_OnFinish(object sender, System.EventArgs e)
		{

		}
	}
}