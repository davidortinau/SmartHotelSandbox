﻿using System;
using System.Globalization;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Converters
{
    public class SelectedToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            if (Device.RuntimePlatform == Device.UWP)
            {
                var cell = parameter as Grid;

                if (cell != null)
                {
                    if (cell.Children.Any(c => c.GetType() == typeof(Label)))
                    {
                        var label = cell.Children
                            .FirstOrDefault(c => c.GetType() == typeof(Label)) as Label;

                        if (label != null)
                        {
                            var valueText = value.ToString();
                            var labelText = label.Text;

                            if(valueText.Equals(labelText))
                                return true;
                        }
                    }
                }

                return false;
            }
            else
            {
                return value == ((View)parameter).BindingContext;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}