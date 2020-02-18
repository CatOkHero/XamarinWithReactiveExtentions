using ReactiveUI;
using SocialMedia.XamarinForms.ViewModels.TabsViewModels;
using Splat;

namespace SocialMedia.XamarinForms.ViewModels
{
    public class MyTabbedViewModel : ReactiveObject, IRoutableViewModel
    {
        public MyTabbedViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            //NavigateToFirstTab = ReactiveCommand.CreateFromObservable(
            //    () => HostScreen.Router.Navigate.Execute(new MyTabbedViewModel())
            //    .Select(_ => Unit.Default));
        }

        //public ReactiveCommand<Unit, Unit> NavigateToFirstTab { get; }

        public string UrlPathSegment => "Tabbed Page";

        public IScreen HostScreen { get; set; }

        public FirstTabViewModel Child1 => new FirstTabViewModel();

        public SecondTabViewModel Child2 => new SecondTabViewModel();
    }
}
