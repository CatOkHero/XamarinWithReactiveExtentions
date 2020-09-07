using Xamarin.Forms;

namespace SocialMedia.XamarinForms.Layouts
{
    public class EntryWithImages : Entry
    {
        public static readonly BindableProperty LeftImageProperty =
            BindableProperty.Create(nameof(LeftImage), typeof(string), typeof(EntryWithImages), string.Empty);

        public string LeftImage
        {
            get { return (string)GetValue(LeftImageProperty); }
            set { SetValue(LeftImageProperty, value); }
        }

        public static readonly BindableProperty RightImageProperty =
            BindableProperty.Create(nameof(RightImage), typeof(string), typeof(EntryWithImages), string.Empty);

        public string RightImage
        {
            get { return (string)GetValue(RightImageProperty); }
            set { SetValue(RightImageProperty, value); }
        }
    }
}
