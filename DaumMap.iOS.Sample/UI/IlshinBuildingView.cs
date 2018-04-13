/*
 * 참조 : https://developer.xamarin.com/recipes/ios/general/templates/using_the_ios_view_xib_template/
 */
using Foundation;
using ObjCRuntime;
using System;
using UIKit;

namespace DaumMap.iOS.Sample
{
    public partial class IlshinBuildingView : UIView
    {
        public IlshinBuildingView (IntPtr handle) : base (handle)
        {
        }

        public static IlshinBuildingView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("CustomCalloutBalloonView_IlshinBuilding", null, null);
            var v = Runtime.GetNSObject<IlshinBuildingView>(arr.ValueAt(0));

            return v;
        }
    }
}