using System;
using Foundation;
using UIKit;
using Xamarin.Bindings.Quiet.iOS;

namespace QuietIoSSample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var transitterFrame = new QMFrameTransmitter(new QMTransmitterConfig("ultrasonic-experimental"));
            transitterFrame.Send(NSData.FromString("InsaneLab INSANELAB InsaneLab INSANELAB InsaneLab INSANELAB InsaneLab INSANELAB InsaneLab INSANELAB", NSStringEncoding.UTF8));
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
