using System;

using UIKit;
using DaumMap.iOS;

namespace DaumMap.iOS.Sample
{
    public partial class MainViewController : UITableViewController //UIViewController
    {
        #region private Member fileds area
        MTMapView mapView;
        #endregion

        protected MainViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            mapView = new MTMapView
            {
                Frame = new CoreGraphics.CGRect(0, 0, View.Frame.Size.Width, View.Frame.Size.Height)
            };
            //mapView.DaumMapApiKey = AppSettings.DaumMapApiKey;
            mapView.BaseMapType = MTMapType.Hybrid;
            View.AddSubview(mapView);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
