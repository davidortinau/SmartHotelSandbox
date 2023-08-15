using CommunityToolkit.Maui;

namespace SmartHotelSandbox;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();
        // .ConfigureEffects(effects =>
        // {
        //     effects.Add<FocusRoutingEffect, FocusPlatformEffect>();
        // });
        return builder.Build();
    }

    public static MauiApp App { get; private set; }
    public static IServiceProvider Services => App.Services;
}// FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
//             CarouselViewRenderer.Init();
//             Renderers.Calendar.Init();
//             Rg.Plugins.Popup.Popup.Init();
