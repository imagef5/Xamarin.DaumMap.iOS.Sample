using System;
using Foundation;
using ObjCRuntime;

namespace DaumMap.iOS
{
    #region MTMapPoint Class Extensions
    public partial class MTMapPoint
    {
        public MTMapPointGeo MapPointGeo
        {
            [Export("mapPointGeo")]
            get
            {
                MTMapPointGeo ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSend(this.Handle, Selector.GetHandle("mapPointGeo"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointGeo"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSend(this.Handle, Selector.GetHandle("mapPointGeo"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointGeo"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointGeo"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointGeo"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointGeo"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointGeo_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointGeo"));
                    }
                }
                return ret;
            }

            [Export("setMapPointGeo:")]
            set
            {
                if (IsDirectBinding)
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSend_MTMapPointGeo(this.Handle, Selector.GetHandle("setMapPointGeo:"), value);
                }
                else
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSendSuper_MTMapPointGeo(this.SuperHandle, Selector.GetHandle("setMapPointGeo:"), value);
                }
            }
        }

        public MTMapPointPlain MapPointWCONG
        {
            [Export("mapPointWCONG")]
            get
            {
                MTMapPointPlain ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointWCONG"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointWCONG"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointWCONG"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointWCONG"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointWCONG"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointWCONG"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointWCONG"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointWCONG"));
                    }
                }
                return ret;
            }

            [Export("setMapPointWCONG:")]
            set
            {
                if (IsDirectBinding)
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSend_MTMapPointPlain(this.Handle, Selector.GetHandle("setMapPointWCONG:"), value);
                }
                else
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSendSuper_MTMapPointPlain(this.SuperHandle, Selector.GetHandle("setMapPointWCONG:"), value);
                }
            }
        }

        public MTMapPointPlain MapPointCONG
        {
            [Export("mapPointCONG")]
            get
            {
                MTMapPointPlain ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointCONG"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointCONG"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointCONG"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointCONG"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointCONG"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointCONG"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointCONG"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointCONG"));
                    }
                }
                return ret;
            }

            [Export("setMapPointCONG:")]
            set
            {
                if (IsDirectBinding)
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSend_MTMapPointPlain(this.Handle, Selector.GetHandle("setMapPointCONG:"), value);
                }
                else
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSendSuper_MTMapPointPlain(this.SuperHandle, Selector.GetHandle("setMapPointCONG:"), value);
                }
            }
        }

        public MTMapPointPlain MapPointWTM
        {
            [Export("mapPointWTM")]
            get
            {
                MTMapPointPlain ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointWTM"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointWTM"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointWTM"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointWTM"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointWTM"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointWTM"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointWTM"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointWTM"));
                    }
                }
                return ret;
            }

            [Export("setMapPointWTM:")]
            set
            {
                if (IsDirectBinding)
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSend_MTMapPointPlain(this.Handle, Selector.GetHandle("setMapPointWTM:"), value);
                }
                else
                {
                    global::DaumMap.iOS.Messaging.void_objc_msgSendSuper_MTMapPointPlain(this.SuperHandle, Selector.GetHandle("setMapPointWTM:"), value);
                }
            }
        }

        public MTMapPointPlain MapPointScreenLocation
        {
            [Export("mapPointScreenLocation")]
            get
            {
                MTMapPointPlain ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointScreenLocation"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointScreenLocation"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend(this.Handle, Selector.GetHandle("mapPointScreenLocation"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("mapPointScreenLocation"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointScreenLocation"));
                        }
                        else
                        {
                            global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointScreenLocation"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("mapPointScreenLocation"));
                    }
                    else
                    {
                        global::DaumMap.iOS.Messaging.MTMapPointPlain_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("mapPointScreenLocation"));
                    }
                }
                return ret;
            }

        }

        public static MTMapPointGeo MakeMapPointGeo(double latitude, double longitude)
        {
            MTMapPointGeo pointGeo;
            pointGeo.Latitude = latitude;
            pointGeo.Longitude = longitude;

            return pointGeo;
        }
    }
    #endregion
}
