using DaumMap.iOS.Sample.ViewControllers;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DaumMap.iOS.Sample
{
    public partial class ViewController : UITableViewController
    {
        #region private member fileds area
        List<SampleList> sampleList;
        #endregion

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        #region override methods area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Title = NSLocalizedString(@"DaumMapApiDemos", nil);
            Title = "DaumMapApiDemos";
            sampleList = new List<SampleList>
            {
                new SampleList{Title="MapView", SubTitle="기본 맵, 타일 종류"},
                new SampleList{Title="Markers", SubTitle="기본 마커, 커스텀 마커, 마커 동작"},
                new SampleList{Title="Polyline,Polygon", SubTitle="지도 위 그래픽 요소 그리기"},
                new SampleList{Title="Location", SubTitle="위치 관련 API"},
                new SampleList{Title="Camera", SubTitle="카메라 관련 API"},
                new SampleList{Title="Events", SubTitle="지도 이벤트"},
            };
        }

		public override nint NumberOfSections(UITableView tableView)
		{
            return 1;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
            return sampleList.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            var cell = tableView.DequeueReusableCell("sampleCell");
            if(cell != null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, "sampleCell");
                cell.TextLabel.Text = sampleList[indexPath.Row].Title;
                cell.DetailTextLabel.Text = sampleList[indexPath.Row].SubTitle;
            }
            return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            switch(indexPath.Row)
            {
                case 0:
                    {
                        var viewController = new SampleMapViewController();
                        viewController.Title = sampleList[indexPath.Row].Title;
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 1:
                    {
                        var viewController = new SampleMarkerViewController();
                        viewController.Title = sampleList[indexPath.Row].Title;
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 2:
                    {
                        var viewController = new PolylineViewController();
                        viewController.Title = sampleList[indexPath.Row].Title;
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 3:
                    {
                        var viewController = new LocationViewController();
                        viewController.Title = sampleList[indexPath.Row].Title;
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 4:
                    {
                        var viewController = new CameraUpdateViewController();
                        viewController.Title = sampleList[indexPath.Row].Title;
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 5:
                    {
                        var viewController = new EventViewController();
                        viewController.Title = sampleList[indexPath.Row].Title;
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                default:
                    break;
            }
		}
		#endregion

		#region private class area
		class SampleList
        {
            public string Title;
            public string SubTitle;
        }
        #endregion
    }
}