using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Gms.Maps;
using Android.Content;
using Xamarin.Forms.Platform.Android;

namespace WhereYouAt.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();

            //MapView m = new MapView(Android.App.Application.Context);

            GoogleMapOptions googleMapOptions = new GoogleMapOptions()
            .InvokeMapType(GoogleMap.MapTypeNormal)
            .InvokeZoomControlsEnabled(true)
            .InvokeCompassEnabled(true);

            MapView m2 = new MapView(Android.App.Application.Context,  googleMapOptions);

            //Content = m2.ToView();
            
            MapContainer.Children.Add(m2.ToView());
            //MapContainer.Children.Add(m2);

            //MapFragment mapFragment = new MapFragment();

            //Content = m;
        }
    }
}