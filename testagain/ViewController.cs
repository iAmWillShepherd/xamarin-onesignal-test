using Foundation;
using System;
using UIKit;
using OneSignalSDK.Xamarin;

namespace testagain
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            OneSignal.Default.Initialize("8da6cb79-6938-42e9-aa3b-def99b42d8a9");
            OneSignal.Default.PromptForPushNotificationsWithUserResponse();

            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
