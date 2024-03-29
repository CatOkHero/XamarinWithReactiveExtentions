﻿using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using SocialMedia.XamarinForms.ViewModels.TabsViewModels;

namespace SocialMedia.XamarinForms.Views.Tabs
{
    public partial class MenuTab : ReactiveContentPage<MenuTabViewModel>
    {
        public MenuTab()
        {
            InitializeComponent();

            this.WhenActivated(
                disposables =>
                {
                    this
                        .OneWayBind(this.ViewModel, x => x.Test, x => x.label.Text)
                        .DisposeWith(disposables);
                });
        }
    }
}
