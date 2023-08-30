using SmartHotel.Clients.Core.Controls;
using MvvmHelpers;
using SmartHotel.Clients.Core.Helpers;
using SmartHotel.Clients.Core.Models;

namespace SmartHotelSandbox;

public partial class MainPage : ContentPage
{
	private ObservableRangeCollection<Suggestion> _suggestions;
	
	public Suggestion Suggestion { get; set; }

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		
		MapHelper.CenterMapInDefaultLocation(Map);
		
		
		var TitleLeftArrow = new CalendarButton
		{
			FontAttributes = FontAttributes.None,
			BackgroundColor = Colors.Transparent,
			BackgroundImage = FileImageSource.FromFile((Device.RuntimePlatform == Device.UWP) ? "Assets/ic_arrow_left_normal.png" : "ic_arrow_left_normal") as FileImageSource,
			HeightRequest = 48,
			WidthRequest = 48,
			Margin = new Thickness(24, 0, 0, 0),
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.End,
			Text = "Hello",
			TextColor = Colors.Red
		};
		
		VStack.Add(TitleLeftArrow);
		
		Suggestions = new ObservableRangeCollection<Suggestion>
		{
			new Suggestion { Name = "The Salty Chicken", Description = "Loren ipsum dolor sit amet, consectetur adipisicing elit.", Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_1.png" : "img_1", Rating = 4, Votes = 81, SuggestionType = SuggestionType.Restaurant, Latitude = 47.5743905f, Longitude = -122.4023376f },
			new Suggestion { Name = "The Autumn Club", Description = "Loren ipsum dolor sit amet, consectetur adipisicing elit.", Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_2.png" : "img_2", Rating = 4, Votes = 66, SuggestionType = SuggestionType.Event, Latitude = 47.5790791f, Longitude = -122.4136163f },
			new Suggestion { Name = "Bike Rider", Description = "Loren ipsum dolor sit amet, consectetur adipisicing elit.", Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_3.png" : "img_3", Rating = 5, Votes = 22, SuggestionType = SuggestionType.Event, Latitude = 47.5766275f, Longitude = -122.4217906f },
			new Suggestion { Name = "C# Conference", Description = "Loren ipsum dolor sit amet, consectetur adipisicing elit.", Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_1.png" : "img_1", Rating = 4, Votes = 17, SuggestionType = SuggestionType.Event, Latitude = 47.5743905f, Longitude = -122.4023376f },
			new Suggestion { Name = "The Autumn Club", Description = "Loren ipsum dolor sit amet, consectetur adipisicing elit.", Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_2.png" : "img_2", Rating = 5, Votes = 132, SuggestionType = SuggestionType.Restaurant, Latitude = 47.5743905f, Longitude = -122.4023376f }
		};
		
		CustomPins = new ObservableRangeCollection<CustomPin>();

		foreach (var suggestion in Suggestions)
		{
			CustomPins.Add(new CustomPin
			{
				Label = suggestion.Name,
				Position = new Microsoft.Maui.Devices.Sensors.Location(suggestion.Latitude, suggestion.Longitude),
				Type = suggestion.SuggestionType
			});
		}
	}

	public ObservableRangeCollection<Suggestion> Suggestions
	{
		get => _suggestions;
		set
		{
			if (Equals(value, _suggestions)) return;
			_suggestions = value;
			OnPropertyChanged();
		}
	}
	
	ObservableRangeCollection<CustomPin> customPins;
	public ObservableRangeCollection<CustomPin> CustomPins
	{
		get => customPins;
		set
		{
			customPins = value;
			OnPropertyChanged();
		}
	}
}

