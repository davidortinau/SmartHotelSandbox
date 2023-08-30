using System;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SmartHotel.Clients.Core.Controls;
using SmartHotel.Clients.Core.Effects;
using SmartHotel.Clients.iOS.Renderers;

namespace SmartHotelSandbox.iOS;

public static class MauiProgram
{
    public static MauiAppBuilder builder;
    public static MauiAppBuilder Builder
    {
        get
        {
            if (builder == null)
            {
                builder = MauiApp.CreateBuilder();
            }

            return builder;
        }
    }

    public static MauiApp CreateMauiApp()
    {
        var build = Builder;
        build.UseMauiApp<App>()
            .UseMauiCompatibility()
            .UseMauiCommunityToolkit()
            .UseFFImageLoading()
            .ConfigureEffects(effects =>
            {
                effects.Add<UnderlineTextEffect, SmartHotel.Clients.iOS.Effects.UnderlineTextEffect>();
            })
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(CalendarButton), typeof(CalendarButtonHandler));
                handlers.AddHandler(typeof(ViewCell), typeof(TransparentViewCell));
                handlers.AddHandler(typeof(ExtendedEntry), typeof(ExtendedEntryHandler));
                handlers.AddHandler(typeof(CustomMap), typeof(CustomMapHandler));
            });

        return builder.Build();
    }
}
