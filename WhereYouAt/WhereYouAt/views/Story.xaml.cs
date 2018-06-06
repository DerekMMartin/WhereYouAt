using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WhereYouAt.pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereYouAt.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Story : ContentView
	{
        private Newsfeed newsFeed;
		public Story (byte[] ProfilePicture, Newsfeed n)
        { 
            newsFeed = n;
            InitializeComponent();
            //ProfileImage.Source = ImageSource.FromStream(() => new MemoryStream(ProfilePicture));
            ProfileImage.HeightRequest = 50;
            ProfileFrame.HeightRequest = 50;

            var client = new WebClient();
            ProfileImage.Source = ImageSource.FromUri(new Uri(@"https://pbs.twimg.com/profile_images/891014228777226240/-_N7QxuJ_400x400.jpg"));

            AddPicture(client.DownloadData(@"https://assets-cdn.github.com/images/modules/open_graph/github-logo.png"));
            AddPicture(client.DownloadData(@"https://www.petri.com/wp-content/uploads/2015/11/Visual-Studio-Hero.jpg"));
        }

        public void AddPicture(byte[] image)
        {
            Image i = new Image() { Source = ImageSource.FromStream(() => new MemoryStream(image)), HeightRequest = App.DisplayScreenHeight / 5 };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                ImageTap((Image)s);
            };
            i.GestureRecognizers.Add(tapGestureRecognizer);
            Lay.Children.Add(i);
        }

        private void ImageTap(Image sender)
        {
            newsFeed.BigImage(sender);
        }
    }
}