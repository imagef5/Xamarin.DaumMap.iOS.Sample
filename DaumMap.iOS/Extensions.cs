using System;

namespace DaumMap.iOS
{
    #region MTMapPoint Class Extensions
    public partial class MTMapPoint
    {
        /// <summary>
        /// Get the Maps geo point.
        /// structure 를 반환하는 unmanaged function 
        /// http://www.mono-project.com/docs/advanced/pinvoke/#class-and-structure-marshaling
        /// </summary>
        /// <returns>The geo point.</returns>
        /// <seealso cref="Marshal.PtrToStructure(IntPtr, Type)"/>
        /// <seealso cref="Marshal.PtrToStructure{T}(IntPtr)"/>
        public MTMapPointGeo MapPointGeo()
        {
            var pointGeo = new MTMapPointGeo();
            var ptr = IntPtr.Zero;
            ptr = _GetMapPointGeo();

            if (ptr != IntPtr.Zero)
            {
                unsafe
                {
                    //정확한 이유는 잘 모르겠으나 
                    //마샬링이 발생할때 포인터의 위치값에 +8(dobule 크기)offset 해야 제대로된 위치값을 얻을 수 있음 
                    MTMapPointGeo* ptrGeo = (MTMapPointGeo*)(ptr + sizeof(double));
                    pointGeo = *ptrGeo;
                }
            }

            return pointGeo;
        }

        public MTMapPointPlain MapPointWCONG()
        {
            var pointPlain = new MTMapPointPlain();
            var ptr = IntPtr.Zero;
            ptr = _MapPointWCONG();

            if (ptr != IntPtr.Zero)
            {
                unsafe
                {
                    //정확한 이유는 잘 모르겠으나 
                    //마샬링이 발생할때 포인터의 위치값에 +8(dobule 크기)offset 해야 제대로된 위치값을 얻을 수 있음 
                    MTMapPointPlain* ptrPlain = (MTMapPointPlain*)(ptr + sizeof(double));
                    pointPlain = *ptrPlain;
                }
            }

            return pointPlain;
        }

        public MTMapPointPlain MapPointCONG()
        {
            var pointPlain = new MTMapPointPlain();
            var ptr = IntPtr.Zero;
            ptr = _MapPointCONG();

            if (ptr != IntPtr.Zero)
            {
                unsafe
                {
                    //정확한 이유는 잘 모르겠으나 
                    //마샬링이 발생할때 포인터의 위치값에 +8(dobule 크기)offset 해야 제대로된 위치값을 얻을 수 있음 
                    MTMapPointPlain* ptrPlain = (MTMapPointPlain*)(ptr + sizeof(double));
                    pointPlain = *ptrPlain;
                }
            }

            return pointPlain;
        }

        public MTMapPointPlain MapPointWTM()
        {
            var pointPlain = new MTMapPointPlain();
            var ptr = IntPtr.Zero;
            ptr = _MapPointWTM();

            if (ptr != IntPtr.Zero)
            {
                unsafe
                {
                    //정확한 이유는 잘 모르겠으나 
                    //마샬링이 발생할때 포인터의 위치값에 +8(dobule 크기)offset 해야 제대로된 위치값을 얻을 수 있음 
                    MTMapPointPlain* ptrPlain = (MTMapPointPlain*)(ptr + sizeof(double));
                    pointPlain = *ptrPlain;
                }
            }

            return pointPlain;
        }

        public MTMapPointPlain MapPointScreenLocation()
        {
            var pointPlain = new MTMapPointPlain();
            var ptr = IntPtr.Zero;
            ptr = _MapPointScreenLocation();

            if (ptr != IntPtr.Zero)
            {
                unsafe
                {
                    //정확한 이유는 잘 모르겠으나 
                    //마샬링이 발생할때 포인터의 위치값에 +8(dobule 크기)offset 해야 제대로된 위치값을 얻을 수 있음 
                    MTMapPointPlain* ptrPlain = (MTMapPointPlain*)(ptr + sizeof(double));
                    pointPlain = *ptrPlain;
                }
            }

            return pointPlain;
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
