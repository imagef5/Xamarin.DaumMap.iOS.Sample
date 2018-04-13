/*
 * 소스 참조 : http://apis.map.daum.net/ios/sample/
 */
using System;
using CoreGraphics;
using UIKit;

namespace DaumMap.iOS.Sample.ViewControllers
{
    public partial class PolylineViewController : UIViewController
    {
        #region private member fields area
        MTMapView mapView;
        #endregion

        public PolylineViewController() : base("PolylineViewController", null)
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
            actionSheet.AddButton("Add Polyline1");
            actionSheet.AddButton("Add Polyline2");
            actionSheet.AddButton("Remove All Polylines");
            actionSheet.AddButton("Add Circle");
            actionSheet.AddButton("Remove All Circles");
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
                    mapView.RemoveAllPolylines();
                    AddPolyline1();
                    break;
                case 2:
                    RemovePreviousMarkers();
                    mapView.RemoveAllPolylines();
                    AddPolyline2();
                    break;
                case 3:
                    RemovePreviousMarkers();
                    mapView.RemoveAllPolylines();
                    break;
                case 4:
                    AddCircle();
                    break;
                case 5:
                    mapView.RemoveAllCircles();
                    break;
                default:
                    break;
            }
        }

        void AddPolyline1()
        {
            var polyline1 = MTMapPolyline.PolyLine();
            polyline1.PolylineColor = UIColor.FromRGBA(1.0f, 0.2f, 0.0f, 0.5f);
            var point1 = MTMapPoint.MakeMapPointGeo(37.537229, 127.005515);
            var point2 = MTMapPoint.MakeMapPointGeo(37.545024, 127.03923);
            var point3 = MTMapPoint.MakeMapPointGeo(37.527896, 127.036245);
            var point4 = MTMapPoint.MakeMapPointGeo(37.541889, 127.095388);
            polyline1.AddPoint(MTMapPoint.MapPointWithGeoCoord(point1));
            polyline1.AddPoint(MTMapPoint.MapPointWithGeoCoord(point2));
            polyline1.AddPoint(MTMapPoint.MapPointWithGeoCoord(point3));
            polyline1.AddPoint(MTMapPoint.MapPointWithGeoCoord(point4));

            mapView.AddPolyline(polyline1);
            mapView.FitMapViewAreaToShowPolyline(polyline1);
        }

        void AddPolyline2()
        {
            var startPOIItem = MTMapPOIItem.PoiItem();
            startPOIItem.ItemName = "출발";
            startPOIItem.Tag = (int)ViewTag.START_MARKER;
            startPOIItem.MapPoint = MTMapPoint.MapPointWithCONG(new MTMapPointPlain(475334.0, 1101210.0));
            startPOIItem.MarkerType = MTMapPOIItemMarkerType.CustomImage;
            startPOIItem.ShowAnimationType = MTMapPOIItemShowAnimationType.SpringFromGround;
            startPOIItem.CustomImageName = "custom_poi_marker_start.png";
            startPOIItem.CustomImageAnchorPointOffset = new MTMapImageOffset(42, 2);

            var endPOIItem = MTMapPOIItem.PoiItem();
            endPOIItem.ItemName = "도";
            endPOIItem.Tag = (int)ViewTag.END_MARKER;
            endPOIItem.MapPoint = MTMapPoint.MapPointWithCONG(new MTMapPointPlain(485016.0, 1118034.0));
            endPOIItem.MarkerType = MTMapPOIItemMarkerType.CustomImage;
            endPOIItem.ShowAnimationType = MTMapPOIItemShowAnimationType.SpringFromGround;
            endPOIItem.CustomImageName = "custom_poi_marker_end.png";
            endPOIItem.CustomImageAnchorPointOffset = new MTMapImageOffset(42, 2);

            //[_mapView addPOIItems:[NSArray arrayWithObjects:startPOIItem, endPOIItem, nil]];
            mapView.AddPOIItems(new MTMapPOIItem[] { startPOIItem, endPOIItem });

            var polyline2 = MTMapPolyline.PolyLine();
            polyline2.PolylineColor = UIColor.FromRGBA(0.0f, 0.0f, 1.0f, 0.8f);
            polyline2.AddPoints(new MTMapPoint[]
                                    {
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(475334.0, 1101210.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(474300.0, 1104123.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(473873.0, 1105377.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(473302.0, 1107097.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(473126.0, 1109606.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(473063.0, 1110548.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(473435.0, 1111020.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(474068.0, 1111714.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(475475.0, 1112765.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(476938.0, 1113532.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(478725.0, 1114391.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(479453.0, 1114785.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(480145.0, 1115145.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(481280.0, 1115237.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(481777.0, 1115164.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(482322.0, 1115923.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(482832.0, 1116322.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(483384.0, 1116754.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(484401.0, 1117547.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(484893.0, 1117930.0)),
                                        MTMapPoint.MapPointWithCONG(new MTMapPointPlain(485016.0, 1118034.0)),
                                    }
                               );
            mapView.AddPolyline(polyline2);
            mapView.FitMapViewAreaToShowPolyline(polyline2);
        }

        void AddCircle()
        {
            var circle = MTMapCircle.Circle();
            var centerPoint = MTMapPoint.MakeMapPointGeo(37.537229, 127.005515);
            circle.CircleCenterPoint = MTMapPoint.MapPointWithGeoCoord(centerPoint);
            circle.CircleLineColor = UIColor.FromRGBA(1, 0, 0, 0.5f);
            circle.CircleFillColor = UIColor.FromRGBA(0, 1, 0, 0.5f);
            circle.CircleRadius = 500;

            mapView.AddCircle(circle);
            mapView.FitMapViewAreaToShowCircle(circle);
        }

        void RemovePreviousMarkers()
        {
            var prevStartPOIItem = mapView.FindPOIItemByTag((int)ViewTag.START_MARKER);
            if(prevStartPOIItem != null)
            {
                mapView.RemovePOIItem(prevStartPOIItem);
            }

            var prevEndPOIItem = mapView.FindPOIItemByTag((int)ViewTag.END_MARKER);
            if (prevEndPOIItem != null)
            {
                mapView.RemovePOIItem(prevEndPOIItem);
            }
        }

        enum ViewTag 
        {
            START_MARKER = 1000,
            END_MARKER
        };

        #endregion
    }
}

