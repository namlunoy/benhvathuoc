using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System.Windows.Shapes;
using System.Windows.Media;
using Microsoft.Phone.Maps.Controls;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BenhVaThuoc.Views
{
    public partial class PageTimKiem : UserControl
    {
        string s = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=nha+thuoc&key=AIzaSyDjpYbcGOvN7GxL7OnovQQz1dBxhFUrBzE&location={0},{1}&radius=100";
        
        public PageTimKiem()
        {
            InitializeComponent();
            Loaded += PageTimKiem_Loaded;
        }

        void PageTimKiem_Loaded(object sender, RoutedEventArgs e)
        {
            ShowMyLocationOnTheMap();
        }




        private async void ShowMyLocationOnTheMap()
        {
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            GeoCoordinate myGeoCoordinate =
                CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

            this.map.Center = myGeoCoordinate;
            this.map.ZoomLevel = 13;

          

            // Create a small circle to mark the current location.
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;


            // Create a MapOverlay to contain the circle.
            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeoCoordinate;


            // Create a MapLayer to contain the MapOverlay.
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);


            map.Layers.Add(myLocationLayer);


            await HienThiCacNhaThuoc(myGeoCoordinate);
        }


        private async Task HienThiCacNhaThuoc(GeoCoordinate myGeoCoordinate)
        {
            string url = String.Format(s, myGeoCoordinate.Latitude, myGeoCoordinate.Longitude);

            WebClient clien = new WebClient();
            clien.DownloadStringCompleted += clien_DownloadStringCompleted;
            clien.DownloadStringAsync(new Uri(url));
            Debug.WriteLine("url : " + url);
        }

        void clien_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
        }

    }
}
