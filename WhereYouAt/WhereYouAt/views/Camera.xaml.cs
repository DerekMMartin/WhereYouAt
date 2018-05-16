using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Android.Content.PM;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereYouAt.views
{
	public partial class Camera : ContentView
	{
		public Camera ()
		{
			InitializeComponent ();
		}
        private async void CameraButton_Clicked(object sender, EventArgs e)
        { 
            var CameraStatus = CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var StorageStatus = CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                if (CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage).IsCompleted) { }

            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                if (CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera).IsCompleted) { }

            if (CameraStatus.Result == PermissionStatus.Granted && StorageStatus.Result == PermissionStatus.Granted)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
                if (photo != null)
                    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
    }
}