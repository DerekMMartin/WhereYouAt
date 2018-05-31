using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereYouAt.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Story : ContentView
	{
        //spoofing for test remove when db working
        static int count = 0;
		public Story ()
        {//When Adding pictures set the HeightRequest = App.DisplayScreenHeight/(How many pictures per page. 5 is good for now.)
            InitializeComponent();
            ProfileImage.Source = ImageSource.FromUri(new Uri(@"https://pbs.twimg.com/profile_images/891014228777226240/-_N7QxuJ_400x400.jpg"));
            ProfileImage.HeightRequest = 50;
            ProfileFrame.HeightRequest = 50;
            for (int i = 0; i < 12; i++)
            {
                if (count == 0)
                {
                    Lay.Children.Add(new Image()
                    { Source = ImageSource.FromUri(new Uri(@"https://assets-cdn.github.com/images/modules/open_graph/github-logo.png")), HeightRequest = App.DisplayScreenHeight / 5 });
                }
                else
                {
                    Lay.Children.Add(new Image() { Source = ImageSource.FromUri(new Uri(@"https://www.petri.com/wp-content/uploads/2015/11/Visual-Studio-Hero.jpg")), HeightRequest = App.DisplayScreenHeight / 5 });
                }

            }
            count++;
            if (count > 1)
                count = 0;

        }

        public void AddPicture(ImageSource source)
        {

        }
    }
}