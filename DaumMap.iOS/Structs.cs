using System;
using System.Runtime.InteropServices;
using DaumMap;
using ObjCRuntime;

namespace DaumMap.iOS
{
    [StructLayout (LayoutKind.Sequential)]
    public struct MTMapPointGeo
    {
        public MTMapPointGeo(double latitude , double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude;

        public double Longitude;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct MTMapPointPlain
    {
        public MTMapPointPlain(double x , double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X;

        public double Y;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct MTMapBounds
    {
        //public MTMapPoint BottoomLeft;
        //public MTMapPoint TopRight;

        public IntPtr BottoomLeft;

        public IntPtr TopRight;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct MTMapImageOffset
    {
        public MTMapImageOffset(int offsetX, int offsetY)
        {
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }

        public int OffsetX;

        public int OffsetY;
    }

    [Native]
    public enum MTMapPOIItemMarkerType : ulong
    {
        BluePin,
        RedPin,
        YellowPin,
        CustomImage
    }

    [Native]
    public enum MTMapPOIItemMarkerSelectedType : ulong
    {
        None,
        BluePin,
        RedPin,
        YellowPin,
        CustomImage
    }

    [Native]
    public enum MTMapPOIItemShowAnimationType : ulong
    {
        NoAnimation,
        DropFromHeaven,
        SpringFromGround
    }

    public enum AddressType : uint
    {
        ShortAddress = 1,
        FullAddress
    }

    [Native]
    public enum MTMapType : ulong
    {
        Standard,
        Satellite,
        Hybrid
    }

    [Native]
    public enum MTMapCurrentLocationTrackingMode : ulong
    {
        Off,
        OnWithoutHeading,
        OnWithHeading,
        OnWithoutHeadingWithoutMapMoving,
        OnWithHeadingWithoutMapMoving
    }
}
