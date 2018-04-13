/*
 * 참조 : https://developer.xamarin.com/recipes/ios/general/templates/using_the_ios_view_xib_template/
 */
using Foundation;
using ObjCRuntime;
using System;
using UIKit;

namespace DaumMap.iOS.Sample
{
    public partial class SeoulForestView : UIView
    {
        public SeoulForestView (IntPtr handle) : base (handle)
        {
        }

        public static SeoulForestView Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("CustomCalloutBalloonView_SeoulForest", null, null);
            var v = Runtime.GetNSObject<SeoulForestView>(arr.ValueAt(0));

            return v;
        }
    }
}