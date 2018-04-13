/*
 * 소스 참조 : http://apis.map.daum.net/ios/sample/
 */
using System;
using CoreGraphics;
using UIKit;

namespace DaumMap.iOS.Sample.ViewControllers
{
    public partial class CameraUpdateViewController : UIViewController
    {
        #region private member fields area
        MTMapView mapView;
        MTMapPoint mapPoint1;
        MTMapPoint mapPoint2;
        MTMapPOIItem POIItem1;
        MTMapPOIItem POIItem2;
        #endregion


        public CameraUpdateViewController() : base("CameraUpdateViewController", null)
        {
        }

        #region override methods area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            mapView = new MTMapView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            View.AddSubview(mapView);

            //created poiItems
            var point1 = MTMapPoint.MakeMapPointGeo(37.537229, 127.005515);
            mapPoint1 = MTMapPoint.MapPointWithGeoCoord(point1);
            POIItem1 = MTMapPOIItem.PoiItem();
            POIItem1.MarkerType = MTMapPOIItemMarkerType.BluePin;
            POIItem1.MapPoint = mapPoint1;
            mapView.AddPOIItem(POIItem1);

            var point2 = MTMapPoint.MakeMapPointGeo(37.4020737, 127.1086766);
            mapPoint2 = MTMapPoint.MapPointWithGeoCoord(point2);
            POIItem2 = MTMapPOIItem.PoiItem();
            POIItem2.MarkerType = MTMapPOIItemMarkerType.YellowPin;
            POIItem2.MapPoint = mapPoint2;
            mapView.AddPOIItem(POIItem2);

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
        void Move()
        {
            var camera = MTMapCameraUpdate.Move(mapPoint1);
            mapView.AnimateWithCameraUpdate(camera);
        }

        void MoveWithZoomLevel()
        {
            var camera = MTMapCameraUpdate.Move(mapPoint2, 7);
            mapView.AnimateWithCameraUpdate(camera);
        }

        void MoveWithDiameter()
        {
            var camera = MTMapCameraUpdate.Move(mapPoint2, 500d);
            mapView.AnimateWithCameraUpdate(camera);
        }

        void FitWithBounds()
        {
            var mapBounds = MTMapBoundsRect.BoundsRect();
            mapBounds.BottomLeft = mapPoint1;
            mapBounds.TopRight = mapPoint2;

            var camera = MTMapCameraUpdate.FitMapViewWithMapBounds(mapBounds, 100d);
            mapView.AnimateWithCameraUpdate(camera);
        }

        void FitWithBoundsAndZoomLevels()
        {
            var mapBounds = MTMapBoundsRect.BoundsRect();
            mapBounds.BottomLeft = mapPoint1;
            mapBounds.TopRight = mapPoint2;

            var camera = MTMapCameraUpdate.FitMapViewWithMapBounds(mapBounds, 100d, 3, 7);
            mapView.AnimateWithCameraUpdate(camera);
        }

        void OnClickMenuButton(object sender, EventArgs args)
        {
            var actionSheet = new UIActionSheet();
            actionSheet.Clicked += OnMenuButtonClicked;

            actionSheet.AddButton("취소");
            actionSheet.AddButton("Point 1");
            actionSheet.AddButton("Point 2, Zoom Lv 7");
            actionSheet.AddButton("Point 2, Diameter");
            actionSheet.AddButton("Bounds, Padding");
            actionSheet.AddButton("Bounds, Padding, Zoom min/max");
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
                    Move();
                    break;
                case 2:
                    MoveWithZoomLevel();
                    break;
                case 3:
                    MoveWithDiameter();
                    break;
                case 4:
                    FitWithBounds();
                    break;
                case 5:
                    FitWithBoundsAndZoomLevels();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

