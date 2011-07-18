using System;
using System.Drawing;
using MonoTouch.UIKit;

namespace Carousel
{
	public class CustomScrollView : UIScrollView
	{
		public Action<object, EventArgs> CenterSlide;
		public bool AnimateTransition { get; set; }
		private object instanceLock = 0;
		
		public CustomScrollView(RectangleF rect)
		{
			this.Frame = rect;
			this.PagingEnabled = false;
			this.AlwaysBounceHorizontal = true;
			this.AlwaysBounceVertical = false;
			this.ShowsHorizontalScrollIndicator = true;
			this.ShowsVerticalScrollIndicator = false;
			this.UserInteractionEnabled = true;
			this.AnimateTransition = true;
			
			this.DecelerationStarted += delegate(object sender, EventArgs e) {
				CenterSlide(sender, e);
			};
			this.DraggingEnded += delegate(object sender, DraggingEventArgs e) {
				CenterSlide(sender, e);
			};
		}
		
		public void InitScroller ()
		{
			lock(instanceLock) 
			{
				this.AnimateTransition = false;
				CenterSlide(this, null);
				this.AnimateTransition = true;
			}
		}
	}
}

