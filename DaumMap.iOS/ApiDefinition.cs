using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace DaumMap.iOS
{
    // @interface MTMapCameraUpdate : NSObject
    [BaseType(typeof(NSObject))]
    interface MTMapCameraUpdate
    {
        // +(MTMapCameraUpdate *)move:(id)mapPoint;
        [Static]
        [Export("move:")]
        MTMapCameraUpdate Move(MTMapPoint mapPoint);

        // +(MTMapCameraUpdate *)move:(id)mapPoint withZoomLevel:(id)zoomLevel;
        [Static]
        [Export("move:withZoomLevel:")]
        MTMapCameraUpdate Move(MTMapPoint mapPoint, int zoomLevel);

        // +(MTMapCameraUpdate *)move:(id)mapPoint withDiameter:(id)meter;
        [Static]
        [Export("move:withDiameter:")]
        MTMapCameraUpdate Move(MTMapPoint mapPoint, double meter);

        // +(MTMapCameraUpdate *)move:(id)mapPoint withDiameter:(id)meter withPadding:(id)padding;
        [Static]
        [Export("move:withDiameter:withPadding:")]
        MTMapCameraUpdate Move(MTMapPoint mapPoint, double meter, double padding);

        // +(MTMapCameraUpdate *)fitMapView:(id)bounds;
        [Static]
        [Export("fitMapView:")]
        [Internal]
        MTMapCameraUpdate FitMapView(MTMapBounds bounds);

        // +(MTMapCameraUpdate *)fitMapView:(id)bounds withPadding:(id)padding;
        [Static]
        [Export("fitMapView:withPadding:")]
        [Internal]
        MTMapCameraUpdate FitMapView(MTMapBounds bounds, double padding);

        // +(MTMapCameraUpdate *)fitMapView:(id)bounds withPadding:(id)padding withMinZoomLevel:(id)minZoomLevel withMaxZoomLevel:(id)maxZoomLevel;
        [Static]
        [Export("fitMapView:withPadding:withMinZoomLevel:withMaxZoomLevel:")]
        [Internal]
        MTMapCameraUpdate FitMapView(MTMapBounds bounds, double padding, int minZoomLevel, int maxZoomLevel);

        // +(MTMapCameraUpdate *)fitMapViewWithMapBounds:(id)bounds;
        [Static]
        [Export("fitMapViewWithMapBounds:")]
        MTMapCameraUpdate FitMapViewWithMapBounds(MTMapBoundsRect bounds);

        // +(MTMapCameraUpdate *)fitMapViewWithMapBounds:(id)bounds withPadding:(id)padding;
        [Static]
        [Export("fitMapViewWithMapBounds:withPadding:")]
        MTMapCameraUpdate FitMapViewWithMapBounds(MTMapBoundsRect bounds, double padding);

        // +(MTMapCameraUpdate *)fitMapViewWithMapBounds:(id)bounds withPadding:(id)padding withMinZoomLevel:(id)minZoomLevel withMaxZoomLevel:(id)maxZoomLevel;
        [Static]
        [Export("fitMapViewWithMapBounds:withPadding:withMinZoomLevel:withMaxZoomLevel:")]
        MTMapCameraUpdate FitMapViewWithMapBounds(MTMapBoundsRect bounds, double padding, int minZoomLevel, int maxZoomLevel);
    }

    // @interface MTMapCircle : NSObject
    [BaseType(typeof(NSObject))]
    interface MTMapCircle
    {
        // +(instancetype)circle;
        [Static]
        [Export("circle")]
        MTMapCircle Circle();

        // @property (retain, nonatomic) MTMapPoint * circleCenterPoint;
        [Export("circleCenterPoint", ArgumentSemantic.Retain)]
        MTMapPoint CircleCenterPoint { set; }

        // @property (assign, nonatomic) float circleLineWidth;
        [Export("circleLineWidth")]
        float CircleLineWidth { set; }

        // @property (retain, nonatomic) UIColor * circleLineColor;
        [Export("circleLineColor", ArgumentSemantic.Retain)]
        UIColor CircleLineColor { set; }

        // @property (retain, nonatomic) UIColor * circleFillColor;
        [Export("circleFillColor", ArgumentSemantic.Retain)]
        UIColor CircleFillColor { set; }

        // @property (assign, nonatomic) float circleRadius;
        [Export("circleRadius")]
        float CircleRadius { set; }

        // @property (assign, nonatomic) NSInteger tag;
        [Export("tag")]
        nint Tag { set; }
    }

    // @interface MTMapPoint : NSObject
    [BaseType(typeof(NSObject))]
    public interface MTMapPoint
    {
        // +(instancetype)mapPointWithGeoCoord:(MTMapPointGeo)mapPointGeo;
        [Static]
        [Export("mapPointWithGeoCoord:")]
        MTMapPoint MapPointWithGeoCoord(MTMapPointGeo mapPointGeo);

        // +(instancetype)mapPointWithWCONG:(MTMapPointPlain)mapPointWCONG;
        [Static]
        [Export("mapPointWithWCONG:")]
        MTMapPoint MapPointWithWCONG(MTMapPointPlain mapPointWCONG);

        // +(instancetype)mapPointWithCONG:(MTMapPointPlain)mapPointCONG;
        [Static]
        [Export("mapPointWithCONG:")]
        MTMapPoint MapPointWithCONG(MTMapPointPlain mapPointCONG);

        // +(instancetype)mapPointWithWTM:(MTMapPointPlain)mapPointWTM;
        [Static]
        [Export("mapPointWithWTM:")]
        MTMapPoint MapPointWithWTM(MTMapPointPlain mapPointWTM);

        // +(instancetype)mapPointWithScreenLocation:(MTMapPointPlain)mapPointScreenLocation;
        [Static]
        [Export("mapPointWithScreenLocation:")]
        MTMapPoint MapPointWithScreenLocation(MTMapPointPlain mapPointScreenLocation);

        // -(MTMapPointGeo)mapPointGeo;
        // -(void)setMapPointGeo:(MTMapPointGeo)mapPointGeo;
        [Export("mapPointGeo")]
        [Internal]
        IntPtr _GetMapPointGeo();
        //MTMapPointGeo MapPointGeo { get; set; }
        //IntPtr MapPointGeo { get; }

        // -(void)setMapPointGeo:(MTMapPointGeo)mapPointGeo;
        [Export("setMapPointGeo:")]
        void SetMapPointGeo(MTMapPointGeo mapPointGeo);

        // -(MTMapPointPlain)mapPointWCONG;
        [Export("mapPointWCONG")]
        [Internal]
        //MTMapPointPlain MapPointWCONG();
        IntPtr _MapPointWCONG();

        // -(void)setMapPointWCONG:(MTMapPointPlain)mapPointWCONG;
        [Export("setMapPointWCONG:")]
        void SetMapPointWCONG(MTMapPointPlain mapPointWCONG);

        // -(MTMapPointPlain)mapPointCONG;
        [Export("mapPointCONG")]
        [Internal]
        //MTMapPointPlain MapPointCONG();
        IntPtr _MapPointCONG();

        // -(void)setMapPointCONG:(MTMapPointPlain)mapPointCONG;
        [Export("setMapPointCONG:")]
        void SetMapPointCONG(MTMapPointPlain mapPointCONG);

        // -(MTMapPointPlain)mapPointWTM;
        [Export("mapPointWTM")]
        [Internal]
        //MTMapPointPlain MapPointWTM();
        IntPtr _MapPointWTM();

        // -(void)setMapPointWTM:(MTMapPointPlain)mapPointWTM;
        [Export("setMapPointWTM:")]
        void SetMapPointWTM(MTMapPointPlain mapPointWTM);

        // -(MTMapPointPlain)mapPointScreenLocation;
        [Export("mapPointScreenLocation")]
        [Internal]
        //MTMapPointPlain MapPointScreenLocation();
        IntPtr _MapPointScreenLocation();
    }

    // @interface MTMapBoundsRect : NSObject
    [BaseType(typeof(NSObject))]
    interface MTMapBoundsRect
    {
        // +(instancetype)boundsRect;
        [Static]
        [Export("boundsRect")]
        MTMapBoundsRect BoundsRect();

        // @property (retain, nonatomic) MTMapPoint * bottomLeft;
        [Export("bottomLeft", ArgumentSemantic.Retain)]
        MTMapPoint BottomLeft { get; set; }

        // @property (retain, nonatomic) MTMapPoint * topRight;
        [Export("topRight", ArgumentSemantic.Retain)]
        MTMapPoint TopRight { get; set; }
    }

    // @interface MTMapLocationMarkerItem : NSObject
    [BaseType(typeof(NSObject))]
    interface MTMapLocationMarkerItem
    {
        // +(instancetype)mapLocationMarkerItem;
        [Static]
        [Export("mapLocationMarkerItem")]
        MTMapLocationMarkerItem MapLocationMarkerItem();

        // @property (copy, nonatomic) NSString * customImageName;
        [Export("customImageName")]
        string CustomImageName { get; set; }

        // @property (copy, nonatomic) NSString * customTrackingImageName;
        [Export("customTrackingImageName")]
        string CustomTrackingImageName { get; set; }

        // @property (copy, nonatomic) NSArray * customTrackingAnimationImageNames;
        //[Verify (StronglyTypedNSArray)]
        [Export("customTrackingAnimationImageNames", ArgumentSemantic.Copy)]
        string[] CustomTrackingAnimationImageNames { get; set; }

        // @property (assign, nonatomic) float customTrackingAnimationDuration;
        [Export("customTrackingAnimationDuration")]
        float CustomTrackingAnimationDuration { get; set; }

        // @property (copy, nonatomic) NSString * customDirectionImageName;
        [Export("customDirectionImageName")]
        string CustomDirectionImageName { get; set; }

        // @property (assign, nonatomic) MTMapImageOffset customImageAnchorPointOffset;
        [Export("customImageAnchorPointOffset", ArgumentSemantic.Assign)]
        //MTMapImageOffset CustomImageAnchorPointOffset { get; set; }
        MTMapImageOffset CustomImageAnchorPointOffset { set; }

        // @property (assign, nonatomic) MTMapImageOffset customTrackingImageAnchorPointOffset;
        [Export("customTrackingImageAnchorPointOffset", ArgumentSemantic.Assign)]
        //MTMapImageOffset CustomTrackingImageAnchorPointOffset { get; set; }
        MTMapImageOffset CustomTrackingImageAnchorPointOffset { set; }

        // @property (assign, nonatomic) MTMapImageOffset customDirectionImageAnchorPointOffset;
        [Export("customDirectionImageAnchorPointOffset", ArgumentSemantic.Assign)]
        //MTMapImageOffset CustomDirectionImageAnchorPointOffset { get; set; }
        MTMapImageOffset CustomDirectionImageAnchorPointOffset { set; }

        // @property (assign, nonatomic) float radius;
        [Export("radius")]
        float Radius { get; set; }

        // @property (retain, nonatomic) UIColor * strokeColor;
        [Export("strokeColor", ArgumentSemantic.Retain)]
        UIColor StrokeColor { get; set; }

        // @property (retain, nonatomic) UIColor * fillColor;
        [Export("fillColor", ArgumentSemantic.Retain)]
        UIColor FillColor { get; set; }
    }

    // @interface MTMapPOIItem : NSObject
    [BaseType(typeof(NSObject))]
    interface MTMapPOIItem
    {
        // +(instancetype)poiItem;
        [Static]
        [Export("poiItem")]
        MTMapPOIItem PoiItem();

        // @property (copy, nonatomic) NSString * itemName;
        [Export("itemName")]
        string ItemName { get; set; }

        // @property (retain, nonatomic) MTMapPoint * mapPoint;
        [Export("mapPoint", ArgumentSemantic.Retain)]
        MTMapPoint MapPoint { get; set; }

        // @property (assign, nonatomic) MTMapPOIItemMarkerType markerType;
        [Export("markerType", ArgumentSemantic.Assign)]
        MTMapPOIItemMarkerType MarkerType { get; set; }

        // @property (assign, nonatomic) MTMapPOIItemMarkerSelectedType markerSelectedType;
        [Export("markerSelectedType", ArgumentSemantic.Assign)]
        MTMapPOIItemMarkerSelectedType MarkerSelectedType { get; set; }

        // @property (assign, nonatomic) MTMapPOIItemShowAnimationType showAnimationType;
        [Export("showAnimationType", ArgumentSemantic.Assign)]
        MTMapPOIItemShowAnimationType ShowAnimationType { get; set; }

        // @property (assign, nonatomic) BOOL showDisclosureButtonOnCalloutBalloon;
        [Export("showDisclosureButtonOnCalloutBalloon")]
        bool ShowDisclosureButtonOnCalloutBalloon { get; set; }

        // @property (assign, nonatomic) BOOL draggable;
        [Export("draggable")]
        bool Draggable { get; set; }

        // @property (assign, nonatomic) NSInteger tag;
        [Export("tag")]
        nint Tag { get; set; }

        // @property (retain, nonatomic) NSObject * userObject;
        [Export("userObject", ArgumentSemantic.Retain)]
        NSObject UserObject { get; set; }

        // @property (copy, nonatomic) NSString * customImageName;
        [Export("customImageName")]
        string CustomImageName { get; set; }

        // @property (copy, nonatomic) NSString * customSelectedImageName;
        [Export("customSelectedImageName")]
        string CustomSelectedImageName { get; set; }

        // @property (copy, nonatomic) UIImage * customImage;
        [Export("customImage", ArgumentSemantic.Copy)]
        UIImage CustomImage { get; set; }

        // @property (copy, nonatomic) UIImage * customSelectedImage;
        [Export("customSelectedImage", ArgumentSemantic.Copy)]
        UIImage CustomSelectedImage { get; set; }

        // @property (copy, nonatomic) NSString * imageNameOfCalloutBalloonLeftSide;
        [Export("imageNameOfCalloutBalloonLeftSide")]
        string ImageNameOfCalloutBalloonLeftSide { get; set; }

        // @property (copy, nonatomic) NSString * imageNameOfCalloutBalloonRightSide;
        [Export("imageNameOfCalloutBalloonRightSide")]
        string ImageNameOfCalloutBalloonRightSide { get; set; }

        // @property (assign, nonatomic) MTMapImageOffset customImageAnchorPointOffset;
        //[Export("customImageAnchorPointOffset")]
        //[Internal]
        //IntPtr _GetCustomImageAnchorPointOffset();

        [Export("customImageAnchorPointOffset", ArgumentSemantic.Assign)]
        MTMapImageOffset CustomImageAnchorPointOffset { set; }

        // @property (retain, nonatomic) UIView * customCalloutBalloonView;
        [Export("customCalloutBalloonView", ArgumentSemantic.Retain)]
        UIView CustomCalloutBalloonView { get; set; }

        // @property (retain, nonatomic) UIView * customHighlightedCalloutBalloonView;
        [Export("customHighlightedCalloutBalloonView", ArgumentSemantic.Retain)]
        UIView CustomHighlightedCalloutBalloonView { get; set; }

        // @property (assign, nonatomic) float rotation;
        [Export("rotation")]
        float Rotation { get; set; }

        // -(void)move:(MTMapPoint *)pt withAnimation:(BOOL)animate;
        [Export("move:withAnimation:")]
        void Move(MTMapPoint pt, bool animate);
    }

    // @interface MTMapPolyline : NSObject
    [BaseType(typeof(NSObject))]
    interface MTMapPolyline
    {
        // +(instancetype)polyLine;
        [Static]
        [Export("polyLine")]
        MTMapPolyline PolyLine();

        // +(instancetype)polyLineWithCapacity:(NSUInteger)capacity;
        [Static]
        [Export("polyLineWithCapacity:")]
        MTMapPolyline PolyLineWithCapacity(nuint capacity);

        // @property (readonly, nonatomic) NSArray * mapPointList;
        //[Verify (StronglyTypedNSArray)]
        [Export("mapPointList")]
        MTMapPoint[] MapPointList { get; }

        // @property (retain, nonatomic) UIColor * polylineColor;
        [Export("polylineColor", ArgumentSemantic.Retain)]
        UIColor PolylineColor { get; set; }

        // @property (assign, nonatomic) NSInteger tag;
        [Export("tag")]
        nint Tag { get; set; }

        // -(void)addPoint:(MTMapPoint *)mapPoint;
        [Export("addPoint:")]
        void AddPoint(MTMapPoint mapPoint);

        // -(void)addPoints:(NSArray *)mapPointList;
        //[Verify (StronglyTypedNSArray)]
        [Export("addPoints:")]
        void AddPoints(MTMapPoint[] mapPointList);
    }

    // @interface MTMapReverseGeoCoder : NSObject
    [BaseType(typeof(NSObject))]
    interface MTMapReverseGeoCoder
    {
        // -(instancetype)initWithMapPoint:(MTMapPoint *)mapPoint withDelegate:(id<MTMapReverseGeoCoderDelegate>)delegate withOpenAPIKey:(NSString *)openAPIKey;
        [Export("initWithMapPoint:withDelegate:withOpenAPIKey:")]
        IntPtr Constructor(MTMapPoint mapPoint, MTMapReverseGeoCoderDelegate @delegate, string openAPIKey);

        // -(void)startFindingAddress;
        [Export("startFindingAddress")]
        void StartFindingAddress();

        // -(void)startFindingAddressWithAddressType:(enum AddressType)addressType;
        [Export("startFindingAddressWithAddressType:")]
        void StartFindingAddressWithAddressType(AddressType addressType);

        // -(void)cancelFindingAddress;
        [Export("cancelFindingAddress")]
        void CancelFindingAddress();

        // +(NSString *)findAddressForMapPoint:(MTMapPoint *)mapPoint withOpenAPIKey:(NSString *)openAPIKey;
        [Static]
        [Export("findAddressForMapPoint:withOpenAPIKey:")]
        string FindAddressForMapPoint(MTMapPoint mapPoint, string openAPIKey);

        // +(NSString *)findAddressForMapPoint:(MTMapPoint *)mapPoint withOpenAPIKey:(NSString *)openAPIKey withAddressType:(enum AddressType)addressType;
        [Static]
        [Export("findAddressForMapPoint:withOpenAPIKey:withAddressType:")]
        string FindAddressForMapPoint(MTMapPoint mapPoint, string openAPIKey, AddressType addressType);

        // +(void)executeFindingAddressForMapPoint:(MTMapPoint *)mapPoint openAPIKey:(NSString *)openAPIKey completionHandler:(MTMapReverseGeoCoderCompletionHandler)handler;
        [Static]
        [Export("executeFindingAddressForMapPoint:openAPIKey:completionHandler:")]
        void ExecuteFindingAddressForMapPoint(MTMapPoint mapPoint, string openAPIKey, MTMapReverseGeoCoderCompletionHandler handler);

        // +(void)executeFindingAddressForMapPoint:(MTMapPoint *)mapPoint openAPIKey:(NSString *)openAPIKey addressType:(enum AddressType)addressType completionHandler:(MTMapReverseGeoCoderCompletionHandler)handler;
        [Static]
        [Export("executeFindingAddressForMapPoint:openAPIKey:addressType:completionHandler:")]
        void ExecuteFindingAddressForMapPoint(MTMapPoint mapPoint, string openAPIKey, AddressType addressType, MTMapReverseGeoCoderCompletionHandler handler);
    }

    // typedef void (^MTMapReverseGeoCoderCompletionHandler)(BOOL, NSString *, NSError *);
    delegate void MTMapReverseGeoCoderCompletionHandler(bool arg0, string arg1, NSError arg2);

    // @protocol MTMapReverseGeoCoderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MTMapReverseGeoCoderDelegate
    {
        // @optional -(void)MTMapReverseGeoCoder:(MTMapReverseGeoCoder *)rGeoCoder foundAddress:(NSString *)addressString;
        [Export("MTMapReverseGeoCoder:foundAddress:")]
        void FoundAddress(MTMapReverseGeoCoder rGeoCoder, string addressString);

        // @optional -(void)MTMapReverseGeoCoder:(MTMapReverseGeoCoder *)rGeoCoder failedToFindAddressWithError:(NSError *)error;
        [Export("MTMapReverseGeoCoder:failedToFindAddressWithError:")]
        void FailedToFindAddressWithError(MTMapReverseGeoCoder rGeoCoder, NSError error);
    }

    // @interface MTMapView : UIView
    [BaseType(typeof(UIView), 
              Delegates = new string[] { "WeakDelegate" }, 
              Events = new Type[] {typeof(MTMapViewDelegate)})]
    interface MTMapView
    {
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        // @property (retain, nonatomic) NSString * daumMapApiKey __attribute__((deprecated("Info.plist의 KAKAO_APP_KEY의 값을 읽어 오도록 수정되었습니다. daumMapApiKey는 더이상 작동 하지 않습니다.")));
        [Export("daumMapApiKey", ArgumentSemantic.Retain)]
        string DaumMapApiKey { get; set; }

        [Wrap("WeakDelegate")]
        IMTMapViewDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<MTMapViewDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        IMTMapViewDelegate WeakDelegate { get; set; }

        // @property (nonatomic) MTMapType baseMapType;
        [Export("baseMapType", ArgumentSemantic.Assign)]
        MTMapType BaseMapType { get; set; }

        // @property (nonatomic) BOOL useHDMapTile;
        [Export("useHDMapTile")]
        bool UseHDMapTile { get; set; }

        // +(BOOL)isMapTilePersistentCacheEnabled;
        [Static]
        [Export("isMapTilePersistentCacheEnabled")]
        bool IsMapTilePersistentCacheEnabled { get; }

        // +(void)setMapTilePersistentCacheEnabled:(BOOL)enableCache;
        [Static]
        [Export("setMapTilePersistentCacheEnabled:")]
        void SetMapTilePersistentCacheEnabled(bool enableCache);

        // +(void)clearMapTilePersistentCache;
        [Static]
        [Export("clearMapTilePersistentCache")]
        void ClearMapTilePersistentCache();

        // @property (nonatomic) BOOL showCurrentLocationMarker;
        [Export("showCurrentLocationMarker")]
        bool ShowCurrentLocationMarker { get; set; }

        // -(void)updateCurrentLocationMarker:(MTMapLocationMarkerItem *)locationMarkerItem;
        [Export("updateCurrentLocationMarker:")]
        void UpdateCurrentLocationMarker(MTMapLocationMarkerItem locationMarkerItem);

        // @property (nonatomic) MTMapCurrentLocationTrackingMode currentLocationTrackingMode;
        [Export("currentLocationTrackingMode", ArgumentSemantic.Assign)]
        MTMapCurrentLocationTrackingMode CurrentLocationTrackingMode { get; set; }

        // @property (readonly, nonatomic) MTMapPoint * mapCenterPoint;
        [Export("mapCenterPoint")]
        MTMapPoint MapCenterPoint { get; }

        // @property (readonly, nonatomic) MTMapBoundsRect * mapBounds;
        [Export("mapBounds")]
        MTMapBoundsRect MapBounds { get; }

        // @property (readonly, nonatomic) MTMapZoomLevel zoomLevel;
        [Export("zoomLevel")]
        int ZoomLevel { get; }

        // @property (readonly, nonatomic) MTMapRotationAngle mapRotationAngle;
        [Export("mapRotationAngle")]
        float MapRotationAngle { get; }

        // -(void)setMapCenterPoint:(MTMapPoint *)mapPoint animated:(BOOL)animated;
        [Export("setMapCenterPoint:animated:")]
        void SetMapCenterPoint(MTMapPoint mapPoint, bool animated);

        // -(void)setMapCenterPoint:(MTMapPoint *)mapPoint zoomLevel:(MTMapZoomLevel)zoomLevel animated:(BOOL)animated;
        [Export("setMapCenterPoint:zoomLevel:animated:")]
        void SetMapCenterPoint(MTMapPoint mapPoint, int zoomLevel, bool animated);

        // -(void)setZoomLevel:(MTMapZoomLevel)zoomLevel animated:(BOOL)animated;
        [Export("setZoomLevel:animated:")]
        void SetZoomLevel(int zoomLevel, bool animated);

        // -(void)zoomInAnimated:(BOOL)animated;
        [Export("zoomInAnimated:")]
        void ZoomInAnimated(bool animated);

        // -(void)zoomOutAnimated:(BOOL)animated;
        [Export("zoomOutAnimated:")]
        void ZoomOutAnimated(bool animated);

        // -(void)setMapRotationAngle:(MTMapRotationAngle)angle animated:(BOOL)animated;
        [Export("setMapRotationAngle:animated:")]
        void SetMapRotationAngle(float angle, bool animated);

        // -(void)fitMapViewAreaToShowMapPoints:(NSArray *)mapPoints;
        //[Verify (StronglyTypedNSArray)]
        [Export("fitMapViewAreaToShowMapPoints:")]
        void FitMapViewAreaToShowMapPoints(MTMapPoint[] mapPoints);

        // -(void)animateWithCameraUpdate:(MTMapCameraUpdate *)cameraUpdate;
        [Export("animateWithCameraUpdate:")]
        void AnimateWithCameraUpdate(MTMapCameraUpdate cameraUpdate);

        // -(void)refreshMapTiles;
        [Export("refreshMapTiles")]
        void RefreshMapTiles();

        // -(void)didReceiveMemoryWarning;
        [Export("didReceiveMemoryWarning")]
        void DidReceiveMemoryWarning();

        // @property (readonly, nonatomic) NSArray * poiItems;
        //[Verify (StronglyTypedNSArray)]
        [Export("poiItems")]
        MTMapPOIItem[] PoiItems { get; }

        // -(void)addPOIItem:(MTMapPOIItem *)poiItem;
        [Export("addPOIItem:")]
        void AddPOIItem(MTMapPOIItem poiItem);

        // -(void)addPOIItems:(NSArray *)poiItems;
        //[Verify (StronglyTypedNSArray)]
        [Export("addPOIItems:")]
        void AddPOIItems(MTMapPOIItem[] poiItems);

        // -(void)selectPOIItem:(MTMapPOIItem *)poiItem animated:(BOOL)animated;
        [Export("selectPOIItem:animated:")]
        void SelectPOIItem(MTMapPOIItem poiItem, bool animated);

        // -(void)deselectPOIItem:(MTMapPOIItem *)poiItem;
        [Export("deselectPOIItem:")]
        void DeselectPOIItem(MTMapPOIItem poiItem);

        // -(MTMapPOIItem *)findPOIItemByTag:(NSInteger)tag;
        [Export("findPOIItemByTag:")]
        MTMapPOIItem FindPOIItemByTag(nint tag);

        // -(NSArray *)findPOIItemByName:(NSString *)name;
        //[Verify (StronglyTypedNSArray)]
        [Export("findPOIItemByName:")]
        MTMapPOIItem[] FindPOIItemByName(string name);

        // -(void)removePOIItem:(MTMapPOIItem *)poiItem;
        [Export("removePOIItem:")]
        void RemovePOIItem(MTMapPOIItem poiItem);

        // -(void)removePOIItems:(NSArray *)poiItems;
        //[Verify (StronglyTypedNSArray)]
        [Export("removePOIItems:")]
        void RemovePOIItems(MTMapPOIItem[] poiItems);

        // -(void)removeAllPOIItems;
        [Export("removeAllPOIItems")]
        void RemoveAllPOIItems();

        // -(void)fitMapViewAreaToShowAllPOIItems;
        [Export("fitMapViewAreaToShowAllPOIItems")]
        void FitMapViewAreaToShowAllPOIItems();

        // @property (readonly, nonatomic) NSArray * polylines;
        //[Verify (StronglyTypedNSArray)]
        [Export("polylines")]
        MTMapPolyline[] Polylines { get; }

        // -(void)addPolyline:(MTMapPolyline *)polyline;
        [Export("addPolyline:")]
        void AddPolyline(MTMapPolyline polyline);

        // -(MTMapPolyline *)findPolylineByTag:(NSInteger)tag;
        [Export("findPolylineByTag:")]
        MTMapPolyline FindPolylineByTag(nint tag);

        // -(void)removePolyline:(MTMapPolyline *)polyline;
        [Export("removePolyline:")]
        void RemovePolyline(MTMapPolyline polyline);

        // -(void)removeAllPolylines;
        [Export("removeAllPolylines")]
        void RemoveAllPolylines();

        // -(void)fitMapViewAreaToShowPolyline:(MTMapPolyline *)polyline;
        [Export("fitMapViewAreaToShowPolyline:")]
        void FitMapViewAreaToShowPolyline(MTMapPolyline polyline);

        // -(void)fitMapViewAreaToShowAllPolylines;
        [Export("fitMapViewAreaToShowAllPolylines")]
        void FitMapViewAreaToShowAllPolylines();

        // @property (readonly, nonatomic) NSArray * circles;
        //[Verify (StronglyTypedNSArray)]
        [Export("circles")]
        MTMapCircle[] Circles { get; }

        // -(void)addCircle:(MTMapCircle *)circle;
        [Export("addCircle:")]
        void AddCircle(MTMapCircle circle);

        // -(MTMapCircle *)findCircleByTag:(NSInteger)tag;
        [Export("findCircleByTag:")]
        MTMapCircle FindCircleByTag(nint tag);

        // -(void)removeCircle:(MTMapCircle *)circle;
        [Export("removeCircle:")]
        void RemoveCircle(MTMapCircle circle);

        // -(void)removeAllCircles;
        [Export("removeAllCircles")]
        void RemoveAllCircles();

        // -(void)fitMapViewAreaToShowCircle:(MTMapCircle *)circle;
        [Export("fitMapViewAreaToShowCircle:")]
        void FitMapViewAreaToShowCircle(MTMapCircle circle);

        // -(void)fitMapViewAreaToShowAllCircleOverlays;
        [Export("fitMapViewAreaToShowAllCircleOverlays")]
        void FitMapViewAreaToShowAllCircleOverlays();
    }

    // @protocol MTMapViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MTMapViewDelegate
    {
        // @optional -(void)mapView:(MTMapView *)mapView openAPIKeyAuthenticationResultCode:(int)resultCode resultMessage:(NSString *)resultMessage;
        [Export("mapView:openAPIKeyAuthenticationResultCode:resultMessage:")]
        [EventArgs("APIKeyAuthenticationResult", ArgName ="APIKeyAuthenticationResult"), EventName("APIKeyAuthentication")]
        void MapView(MTMapView mtmapView, int resultCode, string resultMessage);

        // @optional -(void)mapView:(MTMapView *)mapView centerPointMovedTo:(MTMapPoint *)mapCenterPoint;
        [Export("mapView:centerPointMovedTo:")]
        [EventArgs("MapPoint"),EventName("MoveToCentered")]
        void MapViewMoveToCenter(MTMapView mapView, MTMapPoint mapCenterPoint);

        // @optional -(void)mapView:(MTMapView *)mapView finishedMapMoveAnimation:(MTMapPoint *)mapCenterPoint;
        [Export("mapView:finishedMapMoveAnimation:")]
        [EventArgs("MapPoint"), EventName("FinishedMoveAnimation")]
        void MapViewFinishedMapMoveAnimination(MTMapView mapView, MTMapPoint mapCenterPoint);

        // @optional -(void)mapView:(MTMapView *)mapView zoomLevelChangedTo:(MTMapZoomLevel)zoomLevel;
        [Export("mapView:zoomLevelChangedTo:")]
        [EventArgs("ChangedZoomLevel"), EventName("ZoomLevelChanged")]
        void MapViewChangedZoomLevel(MTMapView mapView, int zoomLevel);

        // @optional -(void)mapView:(MTMapView *)mapView singleTapOnMapPoint:(MTMapPoint *)mapPoint;
        [Export("mapView:singleTapOnMapPoint:")]
        [EventArgs("MapPoint"), EventName("SingleTapped")]
        void MapViewSingleTap(MTMapView mapView, MTMapPoint mapPoint);

        // @optional -(void)mapView:(MTMapView *)mapView doubleTapOnMapPoint:(MTMapPoint *)mapPoint;
        [Export("mapView:doubleTapOnMapPoint:")]
        [EventArgs("MapPoint"), EventName("DoubleTapped")]
        void MapViewDoubleTap(MTMapView mapView, MTMapPoint mapPoint);

        // @optional -(void)mapView:(MTMapView *)mapView dragStartedOnMapPoint:(MTMapPoint *)mapPoint;
        [Export("mapView:dragStartedOnMapPoint:")]
        [EventArgs("MapPoint"), EventName("DragStarted")]
        void MapViewDragStarted(MTMapView mapView, MTMapPoint mapPoint);

        // @optional -(void)mapView:(MTMapView *)mapView dragEndedOnMapPoint:(MTMapPoint *)mapPoint;
        [Export("mapView:dragEndedOnMapPoint:")]
        [EventArgs("MapPoint"), EventName("DragEnded")]
        void MapViewDragEnded(MTMapView mapView, MTMapPoint mapPoint);

        // @optional -(void)mapView:(MTMapView *)mapView longPressOnMapPoint:(MTMapPoint *)mapPoint;
        [Export("mapView:longPressOnMapPoint:")]
        [EventArgs("MapPoint"), EventName("LongPressed")]
        void MapViewLongPress(MTMapView mapView, MTMapPoint mapPoint);

        // @optional -(void)mapView:(MTMapView *)mapView updateCurrentLocation:(MTMapPoint *)location withAccuracy:(MTMapLocationAccuracy)accuracy;
        [Export("mapView:updateCurrentLocation:withAccuracy:")]
        [EventArgs("UpdateCurrentLocation"), EventName("UpdateCurrentLocation")]
        void MapViewUpdateCurrentLocation(MTMapView mapView, MTMapPoint location, double accuracy);

        // @optional -(void)mapView:(MTMapView *)mapView failedUpdatingCurrentLocationWithError:(NSError *)error;
        [Export("mapView:failedUpdatingCurrentLocationWithError:")]
        [EventArgs("MTMapViewError"), EventName("FailedUpdatingCurrentLocation")]
        void MapViewFailedUpdatingCurrentLocation(MTMapView mapView, NSError error);

        // @optional -(void)mapView:(MTMapView *)mapView updateDeviceHeading:(MTMapRotationAngle)headingAngle;
        [Export("mapView:updateDeviceHeading:")]
        [EventArgs("UpdateDeviceHeading"), EventName("UpdateDeviceHeading")]
        void MapViewUpdateDeviceHeading(MTMapView mapView, float headingAngle);

        // @optional -(BOOL)mapView:(MTMapView *)mapView selectedPOIItem:(MTMapPOIItem *)poiItem;
        [Export("mapView:selectedPOIItem:"), DelegateName("SelectedPOIItem"), NoDefaultValue]
        //[EventArgs("MapPOIItem"), EventName("SelectedPOIItem"), NoDefaultValue]
        bool MapViewSelectedPOIItem(MTMapView mapView, MTMapPOIItem poiItem);

        // @optional -(void)mapView:(MTMapView *)mapView touchedCalloutBalloonOfPOIItem:(MTMapPOIItem *)poiItem;
        [Export("mapView:touchedCalloutBalloonOfPOIItem:")]
        [EventArgs("MapPOIItem"), EventName("TouchedCalloutBalloonOfPOIItem")]
        void MapViewTouchedCalloutBalloonOfPOIItem(MTMapView mapView, MTMapPOIItem poiItem);

        // @optional -(void)mapView:(MTMapView *)mapView touchedCalloutBalloonLeftSideOfPOIItem:(MTMapPOIItem *)poiItem;
        [Export("mapView:touchedCalloutBalloonLeftSideOfPOIItem:")]
        [EventArgs("MapPOIItem"), EventName("TouchedCalloutBalloonLeftSideOfPOIItem")]
        void MapViewTouchedCalloutBalloonLeftSideOfPOIItem(MTMapView mapView, MTMapPOIItem poiItem);

        // @optional -(void)mapView:(MTMapView *)mapView touchedCalloutBalloonRightSideOfPOIItem:(MTMapPOIItem *)poiItem;
        [Export("mapView:touchedCalloutBalloonRightSideOfPOIItem:")]
        [EventArgs("MapPOIItem"), EventName("TouchedCalloutBalloonRightSideOfPOIItem")]
        void MapViewTouchedCalloutBalloonRightSideOfPOIItem(MTMapView mapView, MTMapPOIItem poiItem);

        // @optional -(void)mapView:(MTMapView *)mapView draggablePOIItem:(MTMapPOIItem *)poiItem movedToNewMapPoint:(MTMapPoint *)newMapPoint;
        [Export("mapView:draggablePOIItem:movedToNewMapPoint:")]
        [EventArgs("DragPOIItemToNewMapPoint"), EventName("DraPOIItemToNewMapPoint")]
        void MapViewDraPOIItemToNewMapPoint(MTMapView mapView, MTMapPOIItem poiItem, MTMapPoint newMapPoint);
    }

    interface IMTMapViewDelegate { }
}
