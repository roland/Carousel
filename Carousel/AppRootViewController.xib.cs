using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace Carousel
{
	public partial class AppRootViewController : UIViewController
	{
		#region Constructors
		
		// The IntPtr and initWithCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code
		
		public AppRootViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		[Export ("initWithCoder:")]
		public AppRootViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		public AppRootViewController () : base ("AppRootViewController", null)
		{
			Initialize ();
		}
		
		void Initialize ()
		{
			controllers = new List<ItemViewController>();
			stopPoints = new List<float>();
			scrollView = new CustomScrollView(new RectangleF(12f, 30f, 1000f, iHeight));
		}
		
		#endregion
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		
		CustomScrollView scrollView;
		List<ItemViewController> controllers;
		float iWidth = 600f, iHeight = 500f, iSpacing = 50f;
		List<float> stopPoints;
		
		public override void ViewDidLoad ()
		{	
			// Add ScrollView
			View.AddSubview(scrollView);
			
			// Add Events
			scrollView.CenterSlide = ScrollViewDecelerationStarted;
			
			ItemViewController v;
			int i;
			float offset = iSpacing, stopPoint;
			
			// Add Items
			for(i = 0; i < 10; i++)
			{
				v = new ItemViewController();
				v.View.Frame = new System.Drawing.RectangleF(offset, 0, iWidth, iHeight);
				scrollView.AddSubview(v.View);
				controllers.Add(v);
				
				offset += iWidth + iSpacing;
				stopPoint = offset - iSpacing - iWidth/2;
				stopPoints.Add(stopPoint);
				
				/* Markers of center of slide
				UIView mv = new UIView(new RectangleF(stopPoint, 0, 10f, 10f));
				mv.BackgroundColor = UIColor.Red;
				scrollView.AddSubview(mv); */
			}
			
			scrollView.ContentSize = new System.Drawing.SizeF(offset, iHeight);
			
			// Position first slide
			scrollView.InitScroller();
		}

		void ScrollViewDecelerationStarted (object sender, EventArgs e)
		{
			var sv = (CustomScrollView)sender;
			float xOffset = sv.ContentOffset.X,
				  minDiff = float.MaxValue,
				  gotoStopPoint = 0f,
				  diff = 0;
			
			// Find closest stop point to the center
			foreach(float stopPoint in stopPoints)
			{
				diff = Math.Abs(xOffset + sv.Frame.Width/2 - stopPoint);
				if(diff < minDiff) 
				{
					gotoStopPoint = stopPoint;
					minDiff = diff;
				}
			}
			
			// Scroll to the closest stop point ( and center it )
			sv.SetContentOffset(new PointF(gotoStopPoint - sv.Frame.Width/2, 0), sv.AnimateTransition);
		}
	}
}

