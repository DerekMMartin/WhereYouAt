using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoConnectionLib.Modules;
using MongoDB.Bson;
using Plugin.Geolocator;
//using Android.Content.PM;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MongoConnectionLib.Services;
using Plugin.Media.Abstractions;

namespace WhereYouAt.pages
{
    public partial class Camera : ContentPage
    {
        MediaFile Taken;
        public Camera()
        {
            InitializeComponent();
            PhotoImage.IsVisible = false;
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
                    PhotoImage.Source = ImageSource.FromStream(() => { Taken = photo;  return photo.GetStream(); });
                //var pos = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(5));
                //LocationLabel.Text = pos.Latitude+" "+pos.Longitude+"\n"+pos.Speed+"\n"+pos.Heading;
            }
            PhotoImage.IsVisible = true;
            SendButton.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            GestureLabel.IsVisible = true;
            GestureLabel.Focus();
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            PhotoImage.Source = null;
            PhotoImage.IsVisible = false;
            GestureLabel.IsVisible = false;
            GestureLabel.Text = "";
            SendButton.IsVisible = false;

            #region
            MobileService ms = new MobileService();

            ObjectId user = ObjectId.GenerateNewId();
            #region
            Images i = new Images()
            {
                ID = ObjectId.GenerateNewId(),
                UserId = user,
                ImageData = new List<EmbeddedImageData>()
            };

            Locations l = new Locations()
            {
                ID = ObjectId.GenerateNewId(),
                UserId = user,
                LocationData = new List<EmbeddedLocationData>()
            };

            MongoConnectionLib.Modules.Profile p = new MongoConnectionLib.Modules.Profile()
            {
                ID = ObjectId.GenerateNewId(),
                UserId = user,
                ProfileName = "User1",
            };

            Users u = new Users()
            {
                ID = user,
                UserName = "User1",
                Password = "pass",
                ImageId = i.ID,
                ProfileId = p.ID,
                LocationId = l.ID
            };
            #endregion
            #region
            user = ObjectId.GenerateNewId();
            Images i2 = new Images()
            {
                ID = ObjectId.GenerateNewId(),
                UserId = user,
                ImageData = new List<EmbeddedImageData>()
            };
            Locations l2 = new Locations()
            {
                ID = ObjectId.GenerateNewId(),
                UserId = user,
                LocationData = new List<EmbeddedLocationData>()
            };
            MongoConnectionLib.Modules.Profile p2 = new MongoConnectionLib.Modules.Profile()
            {
                ID = ObjectId.GenerateNewId(),
                UserId = user,
                ProfileName = "User2"
            };
            Users u2 = new Users()
            {
                ID = user,
                UserName = "User2",
                Password = "pass",
                ImageId = i2.ID,
                ProfileId = p2.ID,
                LocationId = l2.ID
            };
            #endregion
            Console.WriteLine("inserting");
            ms.Insert(u);
            Console.WriteLine("insertefd first");
            ms.Insert(u2);
            Console.WriteLine("inserted 2nd");
            //EmbeddedImageData m = new EmbeddedImageData();
            //m.ExpiresAt = DateTime.Now.AddDays(7);
            //m.ID = ObjectId.GenerateNewId();

            ////var u = ms.RetrieveOneDocument<Users>(//User ID);
            //var i = u.imagesid //objectid
            //var images = ms.RetrieveOneDocument<Images>(i);
            //ms.AppendNewDataItem(images, m);
            //Users u = new Users();

            //ms.Insert<Users>()
            //ms.RetrieveAllDocumentIds<Users>(); //get all users
            #endregion

        }
    }
}