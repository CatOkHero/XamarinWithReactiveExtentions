using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using SocialMedia.XamarinForms.ViewModels.TabsViewModels;
using Splat;

namespace SocialMedia.XamarinForms.ViewModels
{
    public class MyTabbedViewModel : ReactiveObject
    {
        public MyTabbedViewModel()
        {
            //HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

            //NavigateToFirstTab = ReactiveCommand.CreateFromObservable(
            //    () => HostScreen.Router.Navigate.Execute(new MyTabbedViewModel())
            //    .Select(_ => Unit.Default));
        }

        //public ReactiveCommand<Unit, Unit> NavigateToFirstTab { get; }

        //public string UrlPathSegment => "Tabbed Page";

        //public IScreen HostScreen { get; set; }

        public FirstTabViewModel Child1 => new FirstTabViewModel();

        public SecondTabViewModel Child2 => new SecondTabViewModel();
    }
}
