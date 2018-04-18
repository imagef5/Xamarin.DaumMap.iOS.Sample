using System;
using System.Runtime.InteropServices;

namespace DaumMap.iOS
{
    internal class Messaging
    {
        const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::DaumMap.iOS.MTMapPointGeo MTMapPointGeo_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::DaumMap.iOS.MTMapPointGeo MTMapPointGeo_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void MTMapPointGeo_objc_msgSend_stret(out global::DaumMap.iOS.MTMapPointGeo retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void MTMapPointGeo_objc_msgSendSuper_stret(out global::DaumMap.iOS.MTMapPointGeo retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        public extern static void void_objc_msgSend_MTMapPointGeo(IntPtr receiver, IntPtr selector, global::DaumMap.iOS.MTMapPointGeo arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        public extern static void void_objc_msgSendSuper_MTMapPointGeo(IntPtr receiver, IntPtr selector, global::DaumMap.iOS.MTMapPointGeo arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::DaumMap.iOS.MTMapPointPlain MTMapPointPlain_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::DaumMap.iOS.MTMapPointPlain MTMapPointPlain_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void MTMapPointPlain_objc_msgSend_stret(out global::DaumMap.iOS.MTMapPointPlain retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void MTMapPointPlain_objc_msgSendSuper_stret(out global::DaumMap.iOS.MTMapPointPlain retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        public extern static void void_objc_msgSend_MTMapPointPlain(IntPtr receiver, IntPtr selector, global::DaumMap.iOS.MTMapPointPlain arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        public extern static void void_objc_msgSendSuper_MTMapPointPlain(IntPtr receiver, IntPtr selector, global::DaumMap.iOS.MTMapPointPlain arg1);
    }
}
