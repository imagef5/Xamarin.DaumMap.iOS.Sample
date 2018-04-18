# Xamarin Project with Daum Map iOS Framework

## SDK API 문서 및 다운 로드
- SDK 다운로드및 API 신청 : [문서 참조및 API 신청][1]
- Sample 다운로드 : [다운로드][0] 
> *Note : 네이티브 앱 키 발급 및 Bundle ID 등록하기에 대한 내용 확인<br/>
> 추가 참조 라이브러리에 대한 내용 확인 <- native binding 프로젝트 assembly 정보 설정에 참고가 됨  

## 프로젝트 구성 
- Library : Xamarin.iOS Binding Library 용 **DaumMap.framework** Convert 프로젝트
- App : Xamarin iOS 용 다음 지도 Sample 

## Native Binding 프로젝트
1. [sharpie][3] 를 이용하여 ApiDefinitions.cs 및 StructsAndEnums.cs 파일 생성하기 (on MacOS)
  (sharpie 사용법은 링크를 클릭해보시기 바랍니다. 여러 옵션이 있으나 DaumMap.framework 변환시 가장 무난하게 변경된 옵션만 표시하도록 하겠습니다.)
  ```
  sharpie bind -output TempBinding -namespace DaumMap.iOS -sdk iphoneos11.3 -scope DaumMap.framework/Versions/A/Headers DaumMap.framework/Versions/A/Headers/*.h -c 
  ```

 - (sharpie 를 실행하면 다음과 같은 화면이 보이더라도 당황화지 마세요!!)<br/>
    - 옵션중 -sdk iphoneos11.3 <- pc에 설치되어 있는 sdk 버전으로 변경 (sdk 버전 확인:터미널 -> xcodebuild -showsdks)
    - ApiDefinitions.cs , StructsAndEnums.cs 파일이 생성확인
    - Binding Analysis 내용 확인 <- 코드 수정에 대한 가이드
 
  ![sharpie result](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_sharpie_result.png)
 
2. Native Binding 프로젝트 생성
- New Solution -> iOS 라이브러리 -> 바인딩 라이브러리 생성
3. DaumMap.framework 내의 DaumMap 파일을 찾아 확장자 .a 를 추가 한다 -> DaumMap.a

|     변경전      |     변경후    |
|:------------:|:--------------:|
|<img src="https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_binding_0.png"/>|<img src="https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_binding_1.png" />|

4. 프로젝트 우측마우스 클릭 -> 추가 -> 파일추가 -> DaumMap.a 파일 추가 <br/>
![xamarin ios framework](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_setting_1.png)

- 네이티브 참조에 DaumMap.framework를 참조해도 동일한 결과를 얻을 수 있음
- 파일이 추가 되면서 DaumMap.linkwith.cs 파일이 자동으로 생성
- 참조 : [Binging objective-c libraries][5] , [ObjCRuntime.LinkWithAttribute Class][4] 

5. DaumMap.linkwith.cs 파일 수정.<br/> 
- 다음의 [문서가이드][1]를 보면 참조해야할 framework 항목들을 확인 할 수 있음.

```
using ObjCRuntime;

[assembly: LinkWith("DaumMap.a", 
                    SmartLink = true, 
                    ForceLoad = true, 
                    Frameworks = "OpenGLES SystemConfiguration CoreLocation QuartzCore UIKit Foundation CoreGraphics", 
                    LinkerFlags = "-lstdc++.6 -lxml2 -lsqlite3")]
```
     
6. sharpie 로 생성하 ApiDefinitions.cs , StructsAndEnums.cs 파일 내용 복사 또는 Drag and Drop로 프로젝트에 파일 추가
- sharpie로 생성된 파일은 최종 결과 파일이 아니고, [Binging objective-c libraries][5] 등을 참조하여 내용에 맞게 수정해 주어야 함
  - 예 : 
  ```
  변경전 코드 

    ApiDefinition.cs 파일

    [BaseType (typeof(NSObject))]
	interface MTMapPoint
    {
		...
		// -(MTMapPointGeo)mapPointGeo;
		// -(void)setMapPointGeo:(MTMapPointGeo)mapPointGeo;
		[Export ("mapPointGeo")]
		[Verify (MethodToProperty)]
		MTMapPointGeo MapPointGeo { get; set; } <- MTMapPointGeo 타입 getter/setter (C#의 Property 형태로 코드 생성)
          ...
    }

    MTMapPointGeo 는 Structs.cs 파일에 정의 되어 있는 struct type

    [StructLayout (LayoutKind.Sequential)]
    public struct MTMapPointGeo
    {
        public double Latitude;

        public double Longitude;
    }

    setter 의 경우 제대로 동작하지만 getter 의 경우 System.InvalidProgramException : Invalid IL code in ~ 형태의 에러발생
  ```
  - 참조 : [structure 를 반환하는 unmanaged function](http://www.mono-project.com/docs/advanced/pinvoke/#class-and-structure-marshaling)

  ```
  변경후
    [BaseType(typeof(NSObject))]
    public interface MTMapPoint
    {
        주석 처리
        ...
        // -(MTMapPointGeo)mapPointGeo;
        // -(void)setMapPointGeo:(MTMapPointGeo)mapPointGeo;
        //[Export("mapPointGeo")]
        //[Internal]
        //MTMapPointGeo MapPointGeo { get; set; }
        
        ...
    }

    * [Internal] Attribute 는 Method 가 외부로 노출이 안되도록 함

    Messaging.cs 파일 추가

    namespace DaumMap.iOS
    {
        internal class Messaging
        {
            const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

                [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
Attribute 추가 ->[return: MarshalAs(UnmanagedType.Struct)]
                public extern static global::DaumMap.iOS.MTMapPointGeo MTMapPointGeo_objc_msgSend(IntPtr receiver, IntPtr selector);
                [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
Attribute 추가 ->[return: MarshalAs(UnmanagedType.Struct)]
                public extern static global::DaumMap.iOS.MTMapPointGeo MTMapPointGeo_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
                [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
                public extern static void MTMapPointGeo_objc_msgSend_stret(out global::DaumMap.iOS.MTMapPointGeo retval, IntPtr receiver, IntPtr selector);
                [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
                public extern static void MTMapPointGeo_objc_msgSendSuper_stret(out global::DaumMap.iOS.MTMapPointGeo retval, IntPtr receiver, IntPtr selector);
                [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
                public extern static void void_objc_msgSend_MTMapPointGeo(IntPtr receiver, IntPtr selector, global::DaumMap.iOS.MTMapPointGeo arg1);
                [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
                public extern static void void_objc_msgSendSuper_MTMapPointGeo(IntPtr receiver, IntPtr selector, global::DaumMap.iOS.MTMapPointGeo arg1);

            ...
        }
    }


    Extensions.cs 파일에 아래와 같은 추가 코드 생성
    ...
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
        ...
    }

    실제 코드 호출시
    var mapPointGeo = mapView.MapCenterPoint.MapPointGeo;
  ```

 7. 경우에 따라 추가코드 생성 (예 : Extension.cs)
 8. iOS 용 App 프로젝트 생성 ->  Native Binding 프로젝트 참조 
 
 - 다음 API 신청시 등록된 iOS Bundle ID 와 APP KEY 를 동일하게 설정해 주어야 지도 서비스가 제대로 동작합니다.
 
 info.plist -> Bundle ID <br/>
 
 ![번들아이디 등록](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_setting_2.png)

 그리고 Info.plist 파일에 다음과 같은 항목으로 발급 받은 APP KEY 를 설정 

- Key name: KAKAO_APP_KEY
- Value Type : String
- Value : 발급 받은 APP KEY

![키 등록](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_setting_3.png)
 
``` 
  코드 예제
  
  using NMapViewerSDK.iOS;
  ...
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            isMapRotationUsing = false;
            mapView = new MTMapView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            View.AddSubview(mapView);
            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem("메뉴", UIBarButtonItemStyle.Plain, OnClickMenuButton), true);
        }

```
  
## Screenshot
![스크린샷1](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_0.png)
![스크린샷2](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_mapview.png)
![스크린샷3](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_markers.png)
![스크린샷4](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_polyline.png)
![스크린샷5](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_cricle.png)
![스크린샷6](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_location.png)
![스크린샷7](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_camera.png)
![스크린샷8](https://dongsasubstorage.blob.core.windows.net/images/uploads/daum_map_ios_events.png)

- Polyline 예제의 경우 모든라인 지우기 (mapView.RemoveAllPolylines()) 명령을 호출해도 라인이 그대로 보여짐. 내 PC 환경의 영향인지를 모르겠으나 원본소스예제를 실행해도(Xcode 9.3) 마찬가지 결과임. 

## Reference
* [Walkthrough: Binding an iOS Objective-C Library][2]
* [ObjCRuntime.LinkWithAttribute Class][4]
* [Binding Objective-C Libraries][5]
* [Binding Types Reference Guide][6]
* [Truobleshooting][7]
* [Interop with Native Libraries][8]
* [Class and Structure Marshaling][9]

[0]:http://apis.map.daum.net/ios/sample/
[1]:http://apis.map.daum.net/ios/guide/
[2]:https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/walkthrough/
[3]:https://developer.xamarin.com/guides/cross-platform/macios/binding/objective-sharpie/getting-started/
[4]:https://developer.xamarin.com/api/type/ObjCRuntime.LinkWithAttribute/
[5]:https://developer.xamarin.com/guides/cross-platform/macios/binding/objective-c-libraries/
[6]:https://developer.xamarin.com/guides/cross-platform/macios/binding/binding-types-reference/
[7]:https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/troubleshooting
[8]:http://www.mono-project.com/docs/advanced/pinvoke/
[9]:http://www.mono-project.com/docs/advanced/pinvoke/#class-and-structure-marshaling