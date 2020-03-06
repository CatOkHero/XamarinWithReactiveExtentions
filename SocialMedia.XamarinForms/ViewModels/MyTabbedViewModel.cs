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
        }

        public string UrlPathSegment => "Tabbed Page";

        public IScreen HostScreen { get; set; }

        public MenuTabViewModel Child1 => new MenuTabViewModel();

        public ChatTabViewModel Child2 => new ChatTabViewModel();
    }
}
