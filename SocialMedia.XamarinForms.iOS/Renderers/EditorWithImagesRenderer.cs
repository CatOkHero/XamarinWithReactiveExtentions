using CoreGraphics;
using SocialMedia.XamarinForms.iOS.Renderers;
using SocialMedia.XamarinForms.Layouts;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryWithImages), typeof(EntryWithImagesRenderer))]
namespace SocialMedia.XamarinForms.iOS.Renderers
{
    public class EntryWithImagesRenderer : EntryRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var leftImageView = new UIImageView(new CGRect(0, 0, 20, 20));
            var element = (Element as EntryWithImages);
            var leftImage = UIImage.FromFile(element.LeftImage);
            leftImageView.Image = leftImage;
            this.Control.LeftView = leftImageView;
            this.Control.LeftViewMode = UITextFieldViewMode.Always;

            var rightImageView = new UIImageView(new CGRect(0, 0, 20, 20));
            var rightImage = UIImage.FromFile(element.RightImage);
            rightImageView.Image = rightImage;
            this.Control.RightView = rightImageView;
            this.Control.RightViewMode = UITextFieldViewMode.Always;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

        }
    }
}
