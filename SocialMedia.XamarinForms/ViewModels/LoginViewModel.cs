﻿using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using SocialMedia.XamarinForms.DbAccess.Repository;
using SocialMedia.XamarinForms.Services;
using SocialMedia.XamarinForms.Validators;
using Splat;

namespace SocialMedia.XamarinForms.ViewModels
{
    public class LoginViewModel : ReactiveValidationObject<LoginViewModel>, IRoutableViewModel
	{
		public string UrlPathSegment => string.Empty;
		public IScreen HostScreen { get; private set; }

		private readonly IRepository repository;

		public ReactiveCommand<Unit, bool> NavigateToMainPage { get; set; }
		public ValidationHelper NameRule { get; }
		public ValidationHelper PasswordRule { get; }
		public ValidationHelper ComplexRule { get; }

		public LoginViewModel(IScreen screen)
		{
			HostScreen = screen;
			repository = Locator.Current.GetService<IRepository>();

			var name = this
				.WhenAnyValue(x => x.UserName)
				.SkipWhile(x => string.IsNullOrEmpty(x) || x.Length < 3)
				.Select(x => x == null || x?.Length > 2);

			var password = this
				.WhenAnyValue(x => x.Password)
				.SkipWhile(x => string.IsNullOrEmpty(x) || x.Length < 5)
				.Select(x => x == null || PasswordValidator.Validate(x));

			var nameAndPasswordRules = this
				.WhenAnyValue(
					x => x.UserName,
					x => x.Password)
				.DefaultIfEmpty()
				.DistinctUntilChanged()
				.SkipWhile(item => !string.IsNullOrWhiteSpace(item.Item1) && !string.IsNullOrWhiteSpace(item.Item2))
				.Select(prop1 =>
							!string.IsNullOrEmpty(prop1.Item1)
							&& this.NameRule.IsValid
							&& !string.IsNullOrEmpty(prop1.Item2)
							&& this.PasswordRule.IsValid);

			NameRule = this.ValidationRule(
				_ => name,
				(vm, state) => !state ? "You must specify a valid name longer then 2 sybols." : string.Empty);

			PasswordRule = this.ValidationRule(
				_ => password,
				(vm, state) => !state ? "You must specify a valid password longer then 8 sybols with at least 1 digit, upper case, lower case and special characters." : string.Empty);

			ComplexRule = this.ValidationRule(
				_ => nameAndPasswordRules,
				(vm, state) => !state ? "Username and Password should be both valid!" : string.Empty);

			NavigateToMainPage = ReactiveCommand
				.CreateFromTask(() =>
				{
					IsProcessing = true;
					return MockRefitHttpService.IsUserValid(UserName, Password);
				}, ComplexRule.WhenAnyValue(v => v.IsValid));

			NavigateToMainPage
				.Where(res => res)
				.SelectMany(res => HostScreen.Router.NavigateAndReset.Execute(new MyTabbedViewModel(HostScreen)))
				.Subscribe(
					ok =>
					{
						IsProcessing = false;
					},
					error =>
					{
						IsProcessing = false;
						IsFailed = true;
					});

			NavigateToMainPage
				.Where(res => !res)
				.Subscribe(error =>
				{
					IsProcessing = false;
					IsFailed = true;
				});
		}

		[Reactive]
		public bool IsProcessing { get; set; } = false;

		[Reactive]
		public bool IsFailed { get; set; } = false;

		[Reactive]
		public string UserName { get; set; } = null;

		[Reactive]
		public string Password { get; set; } = null;
	}
}
