using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using SocialMedia.XamarinForms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace SocialMedia.XamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : ReactiveTabbedPage<MyTabbedViewModel>, IViewFor<MyTabbedViewModel>
    {
        public MyTabbedPage()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            InitializeComponent();
            this.WhenActivated(
                disposables =>
                {
                    this
                        .OneWayBind(this.ViewModel, x => x.HomeTab, x => x.firstTab.ViewModel)
                        .DisposeWith(disposables);
                    this
                        .OneWayBind(this.ViewModel, x => x.MessagesTab, x => x.secondTab.ViewModel)
                        .DisposeWith(disposables);
                    this
                        .OneWayBind(this.ViewModel, x => x.NotificationsTab, x => x.thirdTab.ViewModel)
                        .DisposeWith(disposables);
                    this
                        .OneWayBind(this.ViewModel, x => x.ProfileTab, x => x.fourthTab.ViewModel)
                        .DisposeWith(disposables);
                });
        }
    }
}
