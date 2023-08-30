using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;

namespace SmartHotel.Clients.Core.Models
{
    public class CustomPin
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string PinIcon { get; set; }

        public string Address { get; set; }

        public Location Position { get; set; }

        public SuggestionType Type { get; set; }
    }
}