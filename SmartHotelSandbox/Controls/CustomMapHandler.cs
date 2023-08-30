using Microsoft.Maui.Handlers;
using Microsoft.Maui.Maps.Handlers;

// #if IOS || MACCATALYST
// using PlatformView = UIKit.UIButton;
// #elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
// using PlatformView = System.Object;
// #endif

namespace SmartHotel.Clients.Core.Controls;

public partial class CustomMapHandler : MapHandler
{
    public static PropertyMapper<CustomMap, CustomMapHandler> PropertyMapper = new PropertyMapper<CustomMap, CustomMapHandler>(Mapper)
    {
        [nameof(CustomMap.CustomPins)] = MapCustomPins,
    };


    public CustomMapHandler() : base(PropertyMapper)
    {
    }
}
