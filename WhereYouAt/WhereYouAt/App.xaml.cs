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
		public App ()
		{
			InitializeComponent();
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
