﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
//using Android.Content.PM;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereYouAt.pages
{
	public partial class Camera : ContentPage
	{
		public Camera ()
		{
			InitializeComponent ();
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            GestureLabel.IsVisible = false;
            GestureLabel.Text = "";
            if (CrossPermissions.Current.RequestPermissionsAsync(new Permission[] { Permission.Camera, Permission.Storage, Permission.Location }).IsCompleted) { }
            Task<PermissionStatus>[] statuses = { CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera),
            CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage),
            CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location)};

            if (statuses[0].Result == PermissionStatus.Granted && statuses[1].Result == PermissionStatus.Granted && statuses[2].Result == PermissionStatus.Granted)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
                if (photo != null)
                    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                var pos = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(5));
                LocationLabel.Text = pos.Latitude+" "+pos.Longitude+"\n"+pos.Speed+"\n"+pos.Heading;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            GestureLabel.IsVisible = true;
            GestureLabel.Focus();
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}