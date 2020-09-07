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

        public string UrlPathSegment => "";

        public IScreen HostScreen { get; set; }

        public MessagesTabViewModel MessagesTab => new MessagesTabViewModel();

        public HomeTabViewModel HomeTab => new HomeTabViewModel();

        public NotificationsTabViewModel NotificationsTab => new NotificationsTabViewModel();

        public ProfileTabViewModel ProfileTab => new ProfileTabViewModel();
    }
}
