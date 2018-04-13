/*
 * 소스 참조 : http://apis.map.daum.net/ios/sample/
 */
using System;
using CoreGraphics;
using UIKit;

namespace DaumMap.iOS.Sample.ViewControllers
{
    public partial class EventViewController : UIViewController
    {
        #region private member fields area
        MTMapView mapView;
        UILabel eventResultLabel;
        #endregion

        public EventViewController() : base("EventViewController", null)
        {
        }

        #region override methods area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            mapView = new MTMapView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            //Add MTMapView delegate(events)
            mapView.APIKeyAuthentication += OnAPIKeyAuthentication;
            mapView.FinishedMoveAnimation += OnFinishedMoveAnimation;
            mapView.MoveToCentered += OnMoveToCentered;
            mapView.ZoomLevelChanged += OnZoomLevelChanged;
            mapView.DragStarted += OnDragStarted;
            mapView.DragEnded += OnDragEnded;
            mapView.SingleTapped += OnSingleTapped;
            mapView.DoubleTapped += OnDoubleTapped;
            mapView.LongPressed += OnLongPressed;

            View.AddSubview(mapView);

            eventResultLabel = new UILabel(new CGRect(0, 0, View.Frame.Width, 40))
            {
                Font = UIFont.SystemFontOfSize(10.0f),
                BackgroundColor = UIColor.Clear,
                TextAlignment = UITextAlignment.Left
            };

            UIBarButtonItem toolBarLabel = new UIBarButtonItem(eventResultLabel);
            this.ToolbarItems = new UIBarButtonItem[] { toolBarLabel };
            this.NavigationController.ToolbarHidden = false;
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillDisappear(bool animated)
        {
            if (mapView != null)
            {
                mapView = null;
            }
        }
        #endregion

        #region Implement MTMapView Event
        private void OnAPIKeyAuthentication(object sender, APIKeyAuthenticationResultEventArgs e)
        {
            Console.WriteLine(nameof(OnAPIKeyAuthentication));
        }

        private void OnFinishedMoveAnimation(object sender, MapPointEventArgs e)
        {
            Console.WriteLine(nameof(OnFinishedMoveAnimation));
        }

        private void OnMoveToCentered(object sender, MapPointEventArgs e)
        {
            try
            {
                eventResultLabel.Text = $"Camera Position : lat:{e.MapPoint.MapPointGeo().Latitude}, lng:{e.MapPoint.MapPointGeo().Longitude}";
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{nameof(OnMoveToCentered)} : {ex.Message}");
            }
        }

        private void OnZoomLevelChanged(object sender, ChangedZoomLevelEventArgs e)
        {
            try
            {
                var map = (MTMapView)sender;
                var mapPointGeo = map.MapCenterPoint.MapPointGeo();
                eventResultLabel.Text = $"Camera Position : lat:{mapPointGeo.Latitude}, lng:{mapPointGeo.Longitude}, ZoomLevel:{e.ZoomLevel}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnZoomLevelChanged)} : {ex.Message}");
            }
        }

        private void OnDragStarted(object sender, MapPointEventArgs e)
        {
            try
            {
                eventResultLabel.Text = $"Drag Started Position : lat:{e.MapPoint.MapPointGeo().Latitude}, lng:{e.MapPoint.MapPointGeo().Longitude}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnDragStarted)} : {ex.Message}");
            }
        }

        private void OnDragEnded(object sender, MapPointEventArgs e)
        {
            try
            {
                eventResultLabel.Text = $"Drag Ended Position : lat:{e.MapPoint.MapPointGeo().Latitude}, lng:{e.MapPoint.MapPointGeo().Longitude}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnDragEnded)} : {ex.Message}");
            }
        }

        private void OnSingleTapped(object sender, MapPointEventArgs e)
        {
            try
            {
                eventResultLabel.Text = $"Single Tapped Position : lat:{e.MapPoint.MapPointGeo().Latitude}, lng:{e.MapPoint.MapPointGeo().Longitude}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnSingleTapped)} : {ex.Message}");
            }
        }

        private void OnDoubleTapped(object sender, MapPointEventArgs e)
        {
            try
            {
                eventResultLabel.Text = $"Double Tapped Position : lat:{e.MapPoint.MapPointGeo().Latitude}, lng:{e.MapPoint.MapPointGeo().Longitude}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnDoubleTapped)} : {ex.Message}");
            }
        }

        private void OnLongPressed(object sender, MapPointEventArgs e)
        {
            try
            {
                eventResultLabel.Text = $"Long Pressed Position : lat:{e.MapPoint.MapPointGeo().Latitude}, lng:{e.MapPoint.MapPointGeo().Longitude}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnLongPressed)} : {ex.Message}");
            }
        }

        #endregion
    }
}

