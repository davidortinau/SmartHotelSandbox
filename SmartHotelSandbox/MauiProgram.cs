using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microcharts.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using SmartHotel.Clients.Core.Controls;

namespace SmartHotelSandbox;
public static class MauiProgram
{
    // this never gets called. It's always called in the platform version
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCompatibility()
            .UseMauiCommunityToolkit()
            .UseFFImageLoading()
            .UseMicrocharts()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("FiraSans_Bold.ttf", "FiraSansBold");
                fonts.AddFont("FiraSans_Regular.ttf", "FiraSansRegular");
                fonts.AddFont("FiraSans_SemiBold.ttf", "FiraSansSemiBold");

                fonts.AddFont("Poppins_Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins_Light.ttf", "PoppinsLight");
                fonts.AddFont("Poppins_Medium.ttf", "PoppinsMedium");
                fonts.AddFont("Poppins_Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins_SemiBold.ttf", "PoppinsSemiBold");
            });

        OverrideHandlers();
        
        return builder.Build();
    }

    private static void OverrideHandlers()
    {
#if ANDROID
        Microsoft.Maui.Handlers.SliderHandler.Mapper.AppendToMapping("AllThumbs", (handler, slider) =>
        {
            handler.PlatformView.IsThumbToolTipEnabled = false;  
        });
#endif
    }

    public static MauiApp App { get; private set; }
    public static IServiceProvider Services => App.Services;
}

// FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
//             CarouselViewRenderer.Init();
//             Renderers.Calendar.Init();
//             Rg.Plugins.Popup.Popup.Init();
