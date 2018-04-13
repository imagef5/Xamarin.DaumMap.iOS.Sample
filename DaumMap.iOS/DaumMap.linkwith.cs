// WARNING: This feature is deprecated. Use the "Native References" folder instead.
// Right-click on the "Native References" folder, select "Add Native Reference",
// and then select the static library or framework that you'd like to bind.
//
// Once you've added your static library or framework, right-click the library or
// framework and select "Properties" to change the LinkWith values.

//설정 참조 : http://apis.map.daum.net/ios/guide/
using ObjCRuntime;

[assembly: LinkWith("DaumMap.a", 
                    SmartLink = true, 
                    ForceLoad = true, 
                    Frameworks = "OpenGLES SystemConfiguration CoreLocation QuartzCore UIKit Foundation CoreGraphics", 
                    LinkerFlags = "-lstdc++.6 -lxml2 -lsqlite3")]
