using ReactiveUI;
using ReactiveUI.XamForms;
using SocialMedia.XamarinForms.ViewModels.TabsViewModels;
using System.Reactive.Disposables;

namespace SocialMedia.XamarinForms.Views.Tabs
{
    public partial class ChatTab : ReactiveContentPage<ChatTabViewModel>
    {
        public ChatTab()
        {
            InitializeComponent();

            this.WhenActivated(disposabel =>
            {
                this.OneWayBind(ViewModel, vm => vm.MockDataModels, v => v.collection.ItemsSource)
                    .DisposeWith(disposabel);
            });
        }
    }
}
