using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using SocialMedia.XamarinForms.DbAccess.DbModels;
using SocialMedia.XamarinForms.DbAccess.Repository;
using SocialMedia.XamarinForms.Validators;
using Splat;
using System;
using System.Reactive;

namespace SocialMedia.XamarinForms.ViewModels
{
	public class LoginViewModel : ReactiveValidationObject<LoginViewModel>, IRoutableViewModel
	{
		public string UrlPathSegment => "Login Page";
		public IScreen HostScreen { get; private set; }

        private readonly IRepository repository;

        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToMainPage { get; set; }
		public ValidationHelper NameRule { get; }
		public ValidationHelper PasswordRule { get; }
		public ValidationHelper ComplexRule { get; }

		public LoginViewModel(IScreen screen)
		{
			HostScreen = screen;
			repository = Locator.Current.GetService<IRepository>();

			NameRule = this.ValidationRule(
				viewModel => viewModel.UserName,
				name => name.Length > 2,
				"You must specify a valid name longer then 2 sybols.");

			PasswordRule = this.ValidationRule(
				viewModel => viewModel.Password,
				password => PasswordValidator.Validate(password),
				"You must specify a valid password longer then 8 sybols with at least 1 digit, upper case, lower case and special characters.");

			var nameAndPasswordRules = this
				.WhenAnyValue(
					x => x.UserName,
					x => x.Password,
					(name, password) => NameRule.IsValid && PasswordRule.IsValid);

			ComplexRule = this.ValidationRule(
				_ => nameAndPasswordRules,
				(vm, state) => !state ? "Username and Password should be both valid!" : string.Empty);

			var canNavigate = this.IsValid();

			NavigateToMainPage = ReactiveCommand.CreateFromObservable(() =>
			{
				repository.Save(new UserDbModel
				{
                    Id = Guid.NewGuid().ToString(),
                    Password = Password,
                    UserName = UserName,
				});

				return HostScreen.Router.NavigateAndReset.Execute(new MyTabbedViewModel(HostScreen));
			}, canNavigate);
		}

		[Reactive]
		public string UserName { get; set; } = String.Empty;

		[Reactive]
		public string Password { get; set; } = String.Empty;
	}
}
