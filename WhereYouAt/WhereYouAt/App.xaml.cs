using Android.Hardware.Display;
using Android.Util;
using Android.Views;
using System;
using System.Runtime.Remoting.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace WhereYouAt
{
	public partial class App : Application
	{
        public static double Height { get; set; }
		public App ()
		{
			InitializeComponent();
            DisplayMetrics s = new DisplayMetrics();

            Height = 2;//(s.HeightPixels / (float)s.Density);
            MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
