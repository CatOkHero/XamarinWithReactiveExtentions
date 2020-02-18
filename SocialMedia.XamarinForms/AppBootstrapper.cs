using ReactiveUI;
using ReactiveUI.XamForms;
using SocialMedia.XamarinForms.ViewModels;
using SocialMedia.XamarinForms.Views;
using Splat;
using System;
using Xamarin.Forms;

namespace SocialMedia.XamarinForms
{
	public class AppBootstrapper : ReactiveObject, IScreen
	{
		public RoutingState Router { get; private set; }
        
        public AppBootstrapper(IMutableDependencyResolver dependencyResolver = null, RoutingState router = null)
        {
            Router = router ?? new RoutingState();

            dependencyResolver = dependencyResolver ?? Locator.CurrentMutable;
            dependencyResolver.RegisterConstant(this, typeof(IScreen));
            dependencyResolver.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            dependencyResolver.Register(() => new MyTabbedPage(), typeof(IViewFor<MyTabbedViewModel>));

            Router.Navigate.Execute(new LoginViewModel(this));
        }

        public Page CreateMainPage()
        {
            return new RoutedViewHost();
        }
    }
}
