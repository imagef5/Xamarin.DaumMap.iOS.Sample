/*
 * 소스 참조 : http://apis.map.daum.net/ios/sample/
 */
using System;
using CoreGraphics;
using UIKit;


namespace DaumMap.iOS.Sample.ViewControllers
{
    public partial class SampleMarkerViewController : UIViewController
    {
        #region private member fileds area
        MTMapView mapView;
        MTMapPOIItem poiItem1;
        MTMapPOIItem poiItem2;
        #endregion
        public SampleMarkerViewController() : base("SampleMarkerViewController", null)
        {
        }

        #region override methods area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
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
            actionSheet.AddButton("DefaultMarker");
            actionSheet.AddButton("CustomMarker");
            actionSheet.AddButton("ShowAll");
            actionSheet.CancelButtonIndex = 0;
            actionSheet.ShowInView(View);
        }

        private void OnMenuButtonClicked(object sender, UIButtonEventArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:
                    break;
                case 1:
                    ShowDefaultMarker();
                    break;
                case 2:
                    ShowCustomMarker();
                    break;
                case 3:
                    ShowAllMarkers();
                    break;
                default:
                    break;
            }
        }

        void ShowDefaultMarker()
        {
            poiItem1 = MTMapPOIItem.PoiItem();
            poiItem1.ItemName = "Default Marker";
            poiItem1.MarkerType = MTMapPOIItemMarkerType.RedPin;
            poiItem1.ShowDisclosureButtonOnCalloutBalloon = true;
            poiItem1.MarkerSelectedType = MTMapPOIItemMarkerSelectedType.RedPin;
            poiItem1.ShowAnimationType = MTMapPOIItemShowAnimationType.DropFromHeaven;
            var point1 = MTMapPoint.MakeMapPointGeo(37.402110, 127.108451);
            poiItem1.MapPoint = MTMapPoint.MapPointWithGeoCoord(point1);
            mapView.AddPOIItem(poiItem1);
            mapView.FitMapViewAreaToShowMapPoints(new MTMapPoint[] {poiItem1.MapPoint});
        }

        void ShowCustomMarker()
        {
            poiItem2 = MTMapPOIItem.PoiItem();
            poiItem2.ItemName = "다음커뮤니케이션";
            poiItem2.MarkerType = MTMapPOIItemMarkerType.CustomImage;
            poiItem2.CustomImageName = "map_pin_custom.png";
            var point2 = MTMapPoint.MakeMapPointGeo(37.537229, 127.005515);
            poiItem2.MapPoint = MTMapPoint.MapPointWithGeoCoord(point2);
            poiItem2.ShowAnimationType = MTMapPOIItemShowAnimationType.SpringFromGround;
            poiItem2.CustomImageName = "custom_poi_marker.png";
            poiItem2.MarkerSelectedType = MTMapPOIItemMarkerSelectedType.CustomImage;
            poiItem2.CustomSelectedImageName = "custom_poi_marker_selected.png";
            poiItem2.CustomImageAnchorPointOffset = new MTMapImageOffset(30,0);
            poiItem2.CustomCalloutBalloonView =  IlshinBuildingView.Create();
            mapView.AddPOIItem(poiItem2);
            mapView.SelectPOIItem(poiItem2, true);
        }

        void ShowAllMarkers()
        {
            ShowDefaultMarker();
            ShowCustomMarker();

            MTMapBoundsRect bounds = MTMapBoundsRect.BoundsRect();
            bounds.BottomLeft = poiItem1.MapPoint;
            bounds.TopRight = poiItem2.MapPoint;

            float padding = 50;
            MTMapCameraUpdate cameraUpdate = MTMapCameraUpdate.FitMapViewWithMapBounds(bounds, padding);
            mapView.AnimateWithCameraUpdate(cameraUpdate);
        }
        #endregion
    }
}

