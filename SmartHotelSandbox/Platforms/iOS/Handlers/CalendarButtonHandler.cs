using CoreGraphics;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using SmartHotel.Clients.Core.Controls;
using UIKit;

namespace SmartHotel.Clients.Core.Controls;

public partial class CalendarButtonHandler : ButtonHandler
{
    protected override UIButton CreatePlatformView() => new UIButton();

    protected override void ConnectHandler(UIButton platformView)
    {
        base.ConnectHandler(platformView);

        // Perform any control setup here
    }

    protected override void DisconnectHandler(UIButton platformView)
    {
        // Perform any native view cleanup here
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }
    
    private static async void MapBackgroundImage(CalendarButtonHandler handler, CalendarButton view)
    {
        var element = view as CalendarButton;
        if (element == null) return;
        if (element.BackgroundImage != null)
        {
            var image = await GetImage(element.BackgroundImage);
            handler.PlatformView.SetBackgroundImage(image, UIControlState.Normal);
            handler.PlatformView.SetBackgroundImage(image, UIControlState.Disabled);
        }
        else
        {
            handler.PlatformView.SetBackgroundImage(null, UIControlState.Normal);
            handler.PlatformView.SetBackgroundImage(null, UIControlState.Disabled);
        }
    }
    
    private static Task<UIImage> GetImage(FileImageSource image)
    {
        var handler = new FileImageSourceHandler();
        return handler.LoadImageAsync(image);
    }

    private static void MapBackgroundPattern(CalendarButtonHandler handler, CalendarButton view)
    {
        if (!(view is CalendarButton element) || view.BackgroundPattern == null || handler.PlatformView.Frame.Width == 0) return;

        UIImage image;
        UIGraphics.BeginImageContext(handler.PlatformView.Frame.Size);
        using (var g = UIGraphics.GetCurrentContext())
        {
            for (var i = 0; i < view.BackgroundPattern.Pattern.Count; i++)
            {
                var p = view.BackgroundPattern.Pattern[i];
                g.SetFillColor(p.Color.ToCGColor());
                var l = (int)Math.Ceiling(handler.PlatformView.Frame.Width * view.BackgroundPattern.GetLeft(i));
                var t = (int)Math.Ceiling(handler.PlatformView.Frame.Height * view.BackgroundPattern.GetTop(i));
                var w = (int)Math.Ceiling(handler.PlatformView.Frame.Width * view.BackgroundPattern.Pattern[i].WidthPercent);
                var h = (int)Math.Ceiling(handler.PlatformView.Frame.Height * view.BackgroundPattern.Pattern[i].HightPercent);
                g.FillRect(new CGRect { X = l, Y = t, Width = w, Height = h });
            }

            image = UIGraphics.GetImageFromCurrentImageContext();
        }
        UIGraphics.EndImageContext();
        handler.PlatformView.SetBackgroundImage(image, UIControlState.Normal);
        handler.PlatformView.SetBackgroundImage(image, UIControlState.Disabled);
    }

    private static void MapTextWithoutMeasure(CalendarButtonHandler handler, CalendarButton view)
    {
        handler.PlatformView.SetTitle(view.TextWithoutMeasure, UIControlState.Normal);
        handler.PlatformView.SetTitle(view.TextWithoutMeasure, UIControlState.Disabled);
    }
}