using Microsoft.Maui.Handlers;
// #if IOS || MACCATALYST
// using PlatformView = UIKit.UIButton;
// #elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
// using PlatformView = System.Object;
// #endif

namespace SmartHotel.Clients.Core.Controls;

public partial class ExtendedEntryHandler : EntryHandler
{
    public static PropertyMapper<ExtendedEntry, ExtendedEntryHandler> PropertyMapper = new PropertyMapper<ExtendedEntry, ExtendedEntryHandler>(Mapper)
    {
        [nameof(ExtendedEntry.LineColor)] = MapLineColor,
    };


    public ExtendedEntryHandler() : base(PropertyMapper)
    {
    }
}
