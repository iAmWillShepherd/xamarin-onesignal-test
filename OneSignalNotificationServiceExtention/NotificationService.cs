using System;
using Foundation;
using UIKit;
using UserNotifications;
using OneSignalSDK.Xamarin;

namespace OneSignalNotificationServiceExtention
{
	[Register ("NotificationService")]
	public class NotificationService : UNNotificationServiceExtension
	{
		Action<UNNotificationContent> ContentHandler { get; set; }
		UNMutableNotificationContent BestAttemptContent { get; set; }
        UNNotificationRequest ReceivedRequest { get; set; }

        protected NotificationService (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void DidReceiveNotificationRequest (UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
		{
			ReceivedRequest = request;
			ContentHandler = contentHandler;
			BestAttemptContent = (UNMutableNotificationContent)request.Content.MutableCopy ();

			(OneSignal.Default as OneSignalImplementation).DidReceiveNotificationExtensionRequest(request, BestAttemptContent, ContentHandler);
		}

		public override void TimeWillExpire ()
		{
			(OneSignal.Default as OneSignalImplementation).ServiceExtensionTimeWillExpireRequest(ReceivedRequest, BestAttemptContent);
			ContentHandler (BestAttemptContent);
		}
	}
}

