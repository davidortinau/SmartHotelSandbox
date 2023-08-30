using Microsoft.Maui.Handlers;
// #if IOS || MACCATALYST
// using PlatformView = UIKit.UIButton;
// #elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
// using PlatformView = System.Object;
// #endif

namespace SmartHotel.Clients.Core.Controls;

public partial class CalendarButtonHandler : ButtonHandler
{
    public static PropertyMapper<CalendarButton, CalendarButtonHandler> PropertyMapper = new PropertyMapper<CalendarButton, CalendarButtonHandler>(Mapper)
    {
        [nameof(CalendarButton.TextWithoutMeasure)] = MapTextWithoutMeasure,
        [nameof(CalendarButton.BackgroundPattern)] = MapBackgroundPattern,
        [nameof(CalendarButton.BackgroundImage)] = MapBackgroundImage,
    };


    public CalendarButtonHandler() : base(PropertyMapper)
    {
    }
}
