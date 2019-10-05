using AppKit;
using Foundation;
using NoSuchCompany.FacebookMessages.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace FacebookMessages.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        public override NSWindow MainWindow { get; }

        public AppDelegate()
        {
            const NSWindowStyle Style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 200, 800, 600);
            
            MainWindow = new NSWindow(rect, Style, NSBackingStore.Buffered, false)
            {
                Title = "Facebook - Conversations"
            };
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            
            LoadApplication(new App());
            
            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}