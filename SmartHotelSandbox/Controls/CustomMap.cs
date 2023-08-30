using SmartHotel.Clients.Core.Models;
using System.Collections.Generic;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace SmartHotel.Clients.Core.Controls
{
    public class CustomMap : Map
    {
        public static readonly BindableProperty CustomPinsProperty =
            BindableProperty.Create("CustomPins",
                typeof(IEnumerable<CustomPin>), typeof(CustomMap), default(IEnumerable<CustomPin>),
                BindingMode.TwoWay);

        public IEnumerable<CustomPin> CustomPins
        {
            get => (IEnumerable<CustomPin>)base.GetValue(CustomPinsProperty);
            set { base.SetValue(CustomPinsProperty, value); }
        }

        public static readonly BindableProperty SelectedPinProperty =
            BindableProperty.Create("SelectedPin",
                typeof(CustomPin), typeof(CustomMap), null);

        public CustomPin SelectedPin
        {
            get => (CustomPin)base.GetValue(SelectedPinProperty);
            set { base.SetValue(SelectedPinProperty, value); }
        }

    }
}