﻿using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using SocialMedia.XamarinForms.ViewModels;
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
				this.Bind(ViewModel,
                        vm => vm.UserName,
                        v => v.username.Text,
					    username.Events().TextChanged)
					.DisposeWith(disposables);

                this.BindValidation(ViewModel, vm => vm.NameRule, v => v.usernameErrors.Text)
                    .DisposeWith(disposables);

                this.Bind(ViewModel,
                        vm => vm.Password,
                        v => v.password.Text,
						password.Events().TextChanged)
					.DisposeWith(disposables);

				this.BindValidation(ViewModel, vm => vm.PasswordRule, v => v.passwordErrors.Text)
                    .DisposeWith(disposables);

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

        void PasswordErrors_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
			var label = (Label)sender;
            if(e.PropertyName == "Text" && !string.IsNullOrEmpty(label.Text))
            {
				VisualStateManager.GoToState(password, "InValid");
            }

			if (e.PropertyName == "Text" && string.IsNullOrEmpty(label.Text))
			{
				VisualStateManager.GoToState(password, "Valid");
			}
		}

		void UserNameErrors_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var label = (Label)sender;
			if (e.PropertyName == "Text" && !string.IsNullOrEmpty(label.Text))
			{
				VisualStateManager.GoToState(username, "InValid");
			}

			if (e.PropertyName == "Text" && string.IsNullOrEmpty(label.Text))
			{
				VisualStateManager.GoToState(username, "Valid");
			}
		}
	}
}