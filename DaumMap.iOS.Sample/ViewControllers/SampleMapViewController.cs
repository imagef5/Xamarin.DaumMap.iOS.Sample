/*
 * 소스 참조 : http://apis.map.daum.net/ios/sample/
 */
using System;
using CoreGraphics;
using UIKit;

namespace DaumMap.iOS.Sample.ViewControllers
{
    public partial class SampleMapViewController : UIViewController
    {
        #region private member fields area
        MTMapView mapView;
        bool isMapRotationUsing;
        #endregion

        public SampleMapViewController() : base("SampleMapViewController", null)
        {
        }

        #region override method area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            isMapRotationUsing = false;
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
            if(mapView != null)
            {
                mapView = null;
            }
		}
		#endregion

		#region private method area
        void MapType(MTMapType mapType)
        {
            mapView.BaseMapType = mapType;
        }

        void SetHDMapTile(bool tileMode)
        {
            mapView.UseHDMapTile = tileMode;
        }

        void OnClickMenuButton(object sender, EventArgs args)
        {
            var actionSheet = new UIActionSheet();
            actionSheet.Clicked += OnMenuButtonClicked;

            actionSheet.AddButton("취소");
            actionSheet.AddButton("Maptype");
            actionSheet.AddButton("Move");

            actionSheet.CancelButtonIndex = 0;
            actionSheet.ShowInView(View);
        }

        private void OnMenuButtonClicked(object sender, UIButtonEventArgs e)
        {
            switch(e.ButtonIndex)
            {
                case 0 :
                    break;
                case 1 :
                    {
                        var alertView = new UIAlertView();//("MapType", null, null, "취소", new string[] { "Standrad", "Satellite", "Hybrid", "HD Map Tile Off", "Clear Map Tile Cache", null });
                        alertView.Title = "MayType";
                        alertView.AddButton("취소");
                        alertView.AddButton("Stdadard");
                        alertView.AddButton("Satellite");
                        alertView.AddButton("Hybrid");
                        alertView.AddButton("HD Map Tile Off");
                        alertView.AddButton("Clear Map Tile Cache");
                       
                        alertView.CancelButtonIndex = 0;
                        alertView.Clicked += OnAlertViewClicked;
                        alertView.Tag = (int)AlertType.ALERT_VIEW_TAG_FOR_MAP_TYPE;
                        alertView.Show();
                    }
                    break;
                case 2 :
                    {
                        var rotatitonMenuTitle = isMapRotationUsing ? "Unrotate Map" : "Rotate Map 60";
                        var alertView = new UIAlertView();//("Move", null, null, "취소", new string[] { "Move to", "Zoom to", "Move and Zoom to", "Zoom in", "Zoom out", rotatitonMenuTitle, null });
                        alertView.Title = "Move";
                        alertView.AddButton("취소");
                        alertView.AddButton("Move To");
                        alertView.AddButton("Zoom to");
                        alertView.AddButton("Move and Zoom to");
                        alertView.AddButton("Zoom in");
                        alertView.AddButton("Zoom out");
                        alertView.AddButton(rotatitonMenuTitle);

                        alertView.CancelButtonIndex = 0;
                        alertView.Clicked += OnAlertViewClicked;
                        alertView.Tag = (int)AlertType.ALERT_VIEW_TAG_FOR_MAP_MOVEMENT;
                        alertView.Show();
                    }
                    break;
                default :
                    break;
            }
        }

        private void OnAlertViewClicked(object sender, UIButtonEventArgs e)
        {
            if(sender is UIAlertView alertView)
            {
                if(alertView.Tag == (int)AlertType.ALERT_VIEW_TAG_FOR_MAP_TYPE)
                {
                    switch(e.ButtonIndex)
                    {
                        case 1:
                            MapType(MTMapType.Standard);
                            break;
                        case 2:
                            MapType(MTMapType.Satellite);
                            break;
                        case 3:
                            MapType(MTMapType.Hybrid);
                            break;
                        case 4:
                            SetHDMapTile(false);
                            break;
                        case 5:
                            MTMapView.ClearMapTilePersistentCache();
                            break;
                            
                        default:
                            break;
                    }
                }
                else if(alertView.Tag == (int)AlertType.ALERT_VIEW_TAG_FOR_MAP_MOVEMENT)
                {
                    switch(e.ButtonIndex)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            mapView.ZoomInAnimated(true);
                            break;
                        case 5:
                            mapView.ZoomOutAnimated(true);
                            break;
                        case 6: 
                            if (!isMapRotationUsing) 
                            {
                                mapView.SetMapRotationAngle(60.0f, true);
                                isMapRotationUsing = true;
                            } 
                            else 
                            {
                                mapView.SetMapRotationAngle(0.0f, true);
                                isMapRotationUsing = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        enum AlertType
        {
            ALERT_VIEW_TAG_FOR_MAP_TYPE,
            ALERT_VIEW_TAG_FOR_MAP_MOVEMENT
        }
        #endregion
    }
}

