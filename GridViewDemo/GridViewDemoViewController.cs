using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MonoTouch.KKGrid;

namespace GridViewDemo {

	public partial class GridViewDemoViewController : UIViewController {
		
		private KKGridView _gridView;
		
		public GridViewDemoViewController(IntPtr handle) : base (handle) {
		}
		
		public override void DidReceiveMemoryWarning() {
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		#region View lifecycle
		
		public override void ViewDidLoad() {
			base.ViewDidLoad();
			//this.GridView.DataSource = new GridViewDataSource();
			//this.GridView.ReloadData();
			this._gridView = new KKGridView();
			this._gridView.Frame = new RectangleF(0f, 0f, this.View.Frame.Width, this.View.Frame.Height);
			this._gridView.BackgroundColor = UIColor.Gray;
			this.View.AddSubview(this._gridView);
			
			this._gridView.DataSource = new GridViewDataSource();
		}
		
		public override void ViewDidUnload() {
			base.ViewDidUnload();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets();
		}
		
		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);
		}
		
		public override void ViewDidAppear(bool animated) {
			base.ViewDidAppear(animated);
		}
		
		public override void ViewWillDisappear(bool animated) {
			base.ViewWillDisappear(animated);
		}
		
		public override void ViewDidDisappear(bool animated) {
			base.ViewDidDisappear(animated);
		}
		
		#endregion
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation) {
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
	
	public class GridViewDataSource : KKGridViewDataSource {
		
		public override uint NumberOfSectionsInGridView(KKGridView gridView) {
			return 18;
		}
		
		public override uint GridViewNumberOfItemsInSection(KKGridView gridView, uint section) {
			return 4;
		}
		
		/*
		public override string GridViewTitleForHeaderInSection(KKGridView gridView, uint section) {
			if (section == 0) {
				return section.ToString();
			}
			return null;
		}
		*/

		public override KKGridViewCell GridViewCellForItemAtIndexPath(KKGridView gridView, KKIndexPath indexPath) {
			var cell = KKGridViewCell.CellFroGridView(gridView);
			cell.AccessoryType = KKGridViewCellAccessoryType.ChristianDalonzo;
			return cell;
		}
		
		
	}
}

