using CoreAnimation;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace SmartHotel.Clients.Core.Controls;

public partial class ExtendedEntryHandler : EntryHandler
{
    private static async void MapLineColor(ExtendedEntryHandler handler, ExtendedEntry view)
    {
        handler.PlatformView.BorderStyle = UITextBorderStyle.None;
        var lineLayer = handler.PlatformView.Layer.Sublayers?.OfType<LineLayer>().FirstOrDefault();
            
        if (lineLayer == null)
        {
            lineLayer = new LineLayer();

            handler.PlatformView.Layer.AddSublayer(lineLayer);
            handler.PlatformView.Layer.MasksToBounds = true;
        }
        
        lineLayer.BorderColor = view.LineColor.ToCGColor();
        handler.PlatformView.TintColor = view.TextColor.ToPlatform();
    }
    class LineLayer : CALayer
    {
        public static nfloat LineHeight = 2f;

        public LineLayer() => BorderWidth = LineHeight;
    }
}