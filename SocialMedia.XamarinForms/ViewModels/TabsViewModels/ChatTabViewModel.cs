using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SocialMedia.XamarinForms.DbAccess;
using System;
using System.Collections.Generic;

namespace SocialMedia.XamarinForms.ViewModels.TabsViewModels
{
    public class ChatTabViewModel : ReactiveObject, IActivatableViewModel
    {
        public string Test => "World";

        public ChatTabViewModel()
        {
            Activator = new ViewModelActivator();
            Action<IDisposable> d = GetData;
            ViewForMixins.WhenActivated(this, d);
        }

        [Reactive]
        public IReadOnlyList<MockDataModel> MockDataModels { get; set; }

        public void GetData(IDisposable disposable)
        {
            MockDataModels = MockDataModels == null ? MockDataService.GetData() : MockDataModels;
        }

        public ViewModelActivator Activator { get; set; }
    }
}
