using System;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhereYouAt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            Console.WriteLine(status);
            if (status != PermissionStatus.Granted)
            {
                Console.WriteLine("not granted");
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                {
                    Console.WriteLine("displaying alert");
                    await DisplayAlert("camera", "please", "K");
                }
                Console.WriteLine("requesting");
                var r = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                Console.WriteLine("requested");
                status = r[Permission.Camera];
            }
            else
            {
                await DisplayAlert("Fuck", "My", "Ass");
            }
            if (status == PermissionStatus.Granted)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

                if (photo != null)
                    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
    }
}
