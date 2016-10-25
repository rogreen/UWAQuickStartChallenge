using System;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyMapApp
{
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
            MapControl.Loaded += MapControl_Loaded;
            MapControl.MapTapped += MapControl_MapTapped;
        }

        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            MapControl.Center =
                new Geopoint(new BasicGeoposition()
                {
                    //Geopoint for Seattle 
                    Latitude = 47.604,
                    Longitude = -122.329
                });
            MapControl.ZoomLevel = 12;
        }

        private void TrafficCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MapControl.TrafficFlowVisible = true;
        }

        private void TrafficCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MapControl.TrafficFlowVisible = false;
        }

        private void MapStyleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MapControl.Style ==
                Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial)
            {
                MapControl.Style =
                    Windows.UI.Xaml.Controls.Maps.MapStyle.Road;
                MapStyleButton.Content = "Aerial";
            }
            else
            {
                MapControl.Style =
                    Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial;
                MapStyleButton.Content = "Road";
            }
        }

        private async void MapControl_MapTapped(
            Windows.UI.Xaml.Controls.Maps.MapControl sender,
            Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            var tappedGeoPosition = args.Location.Position;
            string status =
                $"Robert Green - MSFT checked in at \nLatitude: {tappedGeoPosition.Latitude} " +
                $"\nLongitude: {tappedGeoPosition.Longitude}";

            var messageDialog = new MessageDialog(status);
            await messageDialog.ShowAsync();
        }
    }
}
