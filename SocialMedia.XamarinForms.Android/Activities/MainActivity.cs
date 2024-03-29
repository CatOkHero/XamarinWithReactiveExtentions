﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using FFImageLoading.Forms;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Xamarin.Essentials;

namespace SocialMedia.XamarinForms.Droid
{
    [Activity(Label = "SocialMedia.XamarinForms",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            CarouselView.FormsPlugin.Android.CarouselViewRenderer.Init();
            CachedImageRenderer.Init();
            SvgCachedImage.Init();
            Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(
            int requestCode,
            string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}