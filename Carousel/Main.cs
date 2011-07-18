using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Carousel
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
	
	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		static public AppRootViewController rootController = new AppRootViewController();
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			
			window.RootViewController = rootController;
			
			window.MakeKeyAndVisible ();
	
			return true;
		}
	}
}

