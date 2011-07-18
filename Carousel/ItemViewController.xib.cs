using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Carousel
{
	public partial class ItemViewController : UIViewController
	{
		#region Constructors
		
		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code
		
		public ItemViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		[Export ("initWithCoder:")]
		public ItemViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		public ItemViewController () : base ("ItemViewController", null)
		{
			Initialize ();
		}
		
		void Initialize ()
		{
			
		}
		
		#endregion
		
		
		
	}
}

