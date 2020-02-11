using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using SocialMedia.XamarinForms.ViewModels;
using Xamarin.Forms.Xaml;

namespace SocialMedia.XamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : ReactiveTabbedPage<MyTabbedViewModel>
    {
        public MyTabbedPage()
        {
            InitializeComponent();
            ViewModel = new MyTabbedViewModel();
            this.WhenActivated(
                disposables =>
                {
                    this
                        .OneWayBind(this.ViewModel, x => x.Child1, x => x.firstTab.ViewModel)
                        .DisposeWith(disposables);
                    this
                        .OneWayBind(this.ViewModel, x => x.Child2, x => x.secondTab.ViewModel)
                        .DisposeWith(disposables);
                });
        }
    }
}
