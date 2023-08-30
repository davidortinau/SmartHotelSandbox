using CoreGraphics;
using CoreLocation;
using MapKit;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using Microsoft.Maui.Maps.Platform;
using Microsoft.Maui.Platform;
using SmartHotel.Clients.Core.Controls;
using SmartHotel.Clients.Core.Helpers;
using SmartHotel.Clients.Core.Models;
using UIKit;

namespace SmartHotel.Clients.Core.Controls;

public partial class CustomMapHandler : MapHandler
{
    static readonly UIImage eventImage = UIImage.FromFile("pushpin_01.png");
    static readonly UIImage restaurantImage = UIImage.FromFile("pushpin_02.png");

    static List<CustomPin> customPins;
    static List<MKAnnotationView> tempAnnotations;
    static UIView customPinView;
    
    static bool isDrawnDone;

    static CustomMap customMap;
    
    // protected override MauiMKMapView CreatePlatformView() => new MauiMKMapView();

    protected override void ConnectHandler(MauiMKMapView platformView)
    {
        base.ConnectHandler(platformView);
    
        // Perform any control setup here
        tempAnnotations = new List<MKAnnotationView>();
        customPins = new List<CustomPin>();
    }
    //
    // protected override void DisconnectHandler(UIButton platformView)
    // {
    //     // Perform any native view cleanup here
    //     platformView.Dispose();
    //     base.DisconnectHandler(platformView);
    // }
    
    private static async void MapCustomPins(CustomMapHandler handler, CustomMap view)
    {
        var iosMapView = (MKMapView)handler.PlatformView;
        customMap = view;    

            if (!isDrawnDone)
            {
                customPins = view.CustomPins.ToList();

                ClearPushPins(iosMapView);

                iosMapView.ZoomEnabled = true;
                iosMapView.GetViewForAnnotation = GetViewForAnnotation;
                iosMapView.DidSelectAnnotationView += OnDidSelectAnnotationView;
                iosMapView.DidDeselectAnnotationView += OnDidDeselectAnnotationView;

                AddPushPins(iosMapView, view.CustomPins);
                PositionMap(view);

                isDrawnDone = true;
            }
        }

    static MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;

            var anno = annotation as MKAnnotation;
            var customPin = GetCustomPin(anno);

            if (customPin == null)
            {
                throw new Exception("Custom pin not found!");
            }

            annotationView = mapView.DequeueReusableAnnotation(customPin.Id.ToString());

            if (annotationView == null)
            {
                annotationView = new CustomMKAnnotationView(annotation, customPin.Id)
                {
                    CalloutOffset = new CGPoint(0, 0)
                };

                switch (customPin.Type)
                {
                    case SuggestionType.Event:
                        annotationView.Image = eventImage;
                        break;
                    case SuggestionType.Restaurant:
                        annotationView.Image = restaurantImage;
                        break;
                }

                ((CustomMKAnnotationView)annotationView).Id = customPin.Id;
            }

            annotationView.CanShowCallout = true;

            return annotationView;
        }

    static void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            var customView = e.View as CustomMKAnnotationView;
            customPinView = new UIView();
            e.View.AddSubview(customPinView);

            var anotation = customView.Annotation as MKAnnotation;
            var selectedPin = GetCustomPin(anotation);
            var pin = customPins.FirstOrDefault((p => p.Id == selectedPin.Id));

            if (pin != null)
            {
                customMap.SelectedPin = pin;
            }
        }

    static void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            if (!e.View.Selected)
            {
                customPinView.RemoveFromSuperview();
                customPinView.Dispose();
                customPinView = null;
            }
        }

    static void AddPushPins(MKMapView mapView, IEnumerable<CustomPin> pins)
        {
            foreach (var formsPin in pins)
            {
                var annotation = new CustomMKAnnotation(new
                    CLLocationCoordinate2D
                {
                    Latitude = formsPin.Position.Latitude,
                    Longitude = formsPin.Position.Longitude
                },
                    formsPin.Label);

                mapView.AddAnnotation(annotation);

                tempAnnotations.Add(GetViewForAnnotation(mapView, annotation));
            }
        }

    static CustomPin GetCustomPin(MKAnnotation annotation)
        {
            var position = new Location(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);

            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }

            return null;
        }

    static void ClearPushPins(MKMapView mapView) => mapView.RemoveAnnotations(mapView.Annotations);

        static void PositionMap(CustomMap map)
        {
            var myMap = map;
            var formsPins = myMap.CustomPins;

            if (formsPins == null || formsPins.Count() == 0)
            {
                return;
            }

            var centerPosition = new Location(formsPins.Average(x => x.Position.Latitude), formsPins.Average(x => x.Position.Longitude));

            var minLongitude = formsPins.Min(x => x.Position.Longitude);
            var minLatitude = formsPins.Min(x => x.Position.Latitude);

            var maxLongitude = formsPins.Max(x => x.Position.Longitude);
            var maxLatitude = formsPins.Max(x => x.Position.Latitude);

            var distance = MapHelper.CalculateDistance(minLatitude, minLongitude,
                maxLatitude, maxLongitude, 'M') / 2;
            
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMiles(distance)));
        }
}

public class CustomMKAnnotation : MKAnnotation
{
    CLLocationCoordinate2D coord;
    readonly string title;

    public override CLLocationCoordinate2D Coordinate => coord;

    public override string Title => title;

    public override void SetCoordinate(CLLocationCoordinate2D coord) => this.coord = coord;

    public CustomMKAnnotation(
        CLLocationCoordinate2D coord,
        string title)
    {
        this.coord = coord;
        this.title = title;
    }
}

public class CustomMKAnnotationView : MKAnnotationView
{
    public int Id { get; set; }

    public CustomMKAnnotationView(IMKAnnotation annotation, int id)
        : base(annotation, id.ToString())
    {
    }
}