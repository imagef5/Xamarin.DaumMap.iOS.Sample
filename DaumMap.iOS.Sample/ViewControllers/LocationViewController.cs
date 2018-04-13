/*
 * 소스 참조 : http://apis.map.daum.net/ios/sample/
 */
using System;
using CoreGraphics;
using UIKit;

namespace DaumMap.iOS.Sample.ViewControllers
{
    public partial class LocationViewController : UIViewController
    {
        #region private member fields area
        MTMapView mapView;
        bool isCustomLocationMarkerUsing;
        #endregion

        public LocationViewController() : base("LocationViewController", null)
        {
        }

        #region override methods area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            isCustomLocationMarkerUsing = false;

            mapView = new MTMapView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            View.AddSubview(mapView);
            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem("메뉴", UIBarButtonItemStyle.Plain, OnClickMenuButton), true);
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

        #region private method area
        void OnClickMenuButton(object sender, EventArgs args)
        {
            var actionSheet = new UIActionSheet();
            actionSheet.Clicked += OnMenuButtonClicked;

            actionSheet.AddButton("취소");
            actionSheet.AddButton("Location");
            actionSheet.AddButton("Reverse Geo-Coding");
            actionSheet.CancelButtonIndex = 0;
            actionSheet.ShowInView(View);
        }

        void OnMenuButtonClicked(object sender, UIButtonEventArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:
                    break;
                case 1:
                    {
                        var locationMarkerTypeTitle = isCustomLocationMarkerUsing ? "Default Location Marker" : "Custom Location Marker";
                        var alertView = new UIAlertView();
                        alertView.Title = "Location";
                        alertView.AddButton("취소");
                        alertView.AddButton("User Location On");
                        alertView.AddButton("User Location On, MapMoving Off");
                        alertView.AddButton("User Location+Heading On");
                        alertView.AddButton("User Location+Heading On, MapMoving Off");
                        alertView.AddButton("Off");
                        alertView.AddButton(locationMarkerTypeTitle);
                        alertView.AddButton("Show Location Marker");
                        alertView.AddButton("Hide Location Marker");

                        alertView.CancelButtonIndex = 0;
                        alertView.Clicked += OnAlertViewClicked;
                        alertView.Tag = (int)AlertViewTag.FOR_LOCATION;
                        alertView.Show();
                    }
                    break;
                case 2:
                    {
                        MTMapReverseGeoCoderCompletionHandler handler = (success, addressProMapPoint, error) => 
                        { 
                            if(success)
                            {
                                var alertView = new UIAlertView();
                                alertView.Title = "DaumMapSample";
                                alertView.Message = addressProMapPoint;
                                alertView.AddButton("OK");
                                alertView.CancelButtonIndex = 0;

                                alertView.Show();
                            }
                            else
                            {
                                var alertView = new UIAlertView();
                                alertView.Title = "DaumMapSample";
                                alertView.Message = $"Reverse Geo-Coding failed with Error : {error.LocalizedDescription}";
                                alertView.AddButton("OK");
                                alertView.CancelButtonIndex = 0;

                                alertView.Show();
                            }
                        };

                        MTMapReverseGeoCoder.ExecuteFindingAddressForMapPoint(mapView.MapCenterPoint, AppSettings.DaumMapApiKey, handler);
                    }
                    break;
                default:
                    break;
            }
        }

        void OnAlertViewClicked(object sender, UIButtonEventArgs e)
        {
            if (sender is UIAlertView alertView)
            {
                if (alertView.Tag == (int)AlertViewTag.FOR_LOCATION)
                {
                    switch (e.ButtonIndex)
                    {
                        case 1:
                            mapView.CurrentLocationTrackingMode = MTMapCurrentLocationTrackingMode.OnWithoutHeading;
                            break;
                        case 2:
                            mapView.CurrentLocationTrackingMode = MTMapCurrentLocationTrackingMode.OnWithoutHeadingWithoutMapMoving;
                            break;
                        case 3:
                            mapView.CurrentLocationTrackingMode = MTMapCurrentLocationTrackingMode.OnWithHeading;
                            break;
                        case 4:
                            mapView.CurrentLocationTrackingMode = MTMapCurrentLocationTrackingMode.OnWithHeadingWithoutMapMoving;
                            break;
                        case 5:
                            mapView.CurrentLocationTrackingMode = MTMapCurrentLocationTrackingMode.Off;
                            break;
                        case 6:
                            if (isCustomLocationMarkerUsing)
                            {
                                mapView.ShowCurrentLocationMarker = true;
                                mapView.UpdateCurrentLocationMarker(null);
                                isCustomLocationMarkerUsing = !isCustomLocationMarkerUsing;
                            } 
                            else 
                            {
                                var markerItem = MTMapLocationMarkerItem.MapLocationMarkerItem();
                                markerItem.CustomImageName = "custom_map_present.png";
                                markerItem.CustomImageAnchorPointOffset = new MTMapImageOffset(27, 27);
                                markerItem.CustomTrackingImageName = "custom_map_present_tracking.png";
                                markerItem.CustomTrackingImageAnchorPointOffset = new MTMapImageOffset(22, 22);
                                markerItem.CustomDirectionImageName = "custom_map_present_direction.png";
                                markerItem.CustomDirectionImageAnchorPointOffset = new MTMapImageOffset(130, 130);
                                markerItem.Radius = 100.0f;
                                markerItem.StrokeColor = UIColor.Blue;
                                markerItem.FillColor = UIColor.FromRGBA(0.0f, 0.0f, 1.0f, 0.5f);
                                isCustomLocationMarkerUsing = !isCustomLocationMarkerUsing;
                            }
                            break;
                        case 7:
                            mapView.ShowCurrentLocationMarker = true;
                            break;
                        case 8:
                            mapView.ShowCurrentLocationMarker = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        enum AlertViewTag
        {
            FOR_LOCATION = 500
        }
        #endregion
    }
}

