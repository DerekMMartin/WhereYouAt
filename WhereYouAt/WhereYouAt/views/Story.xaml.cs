using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AndroidSwipeLayout;
using Android.Util;


namespace WhereYouAt.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Story : ContentView
	{
        public double StoryHeight { get; set; }

        static int count = 0;
		public Story ()
        { 
            InitializeComponent();
            RowDef.Height = new GridLength(RowDef.Height.Value * 10);
            //RowDef.Height = new GridLength(((Height * 0.20)));
            for (int i = 0; i < 10; i++)
            {
                if (count == 0)
                    Lay.Children.Add(new Image()
                    { Source = ImageSource.FromUri(new Uri(@"https://assets-cdn.github.com/images/modules/open_graph/github-logo.png")) });
                else
                {
                    Lay.Children.Add(new Image() { Source = ImageSource.FromUri(new Uri(@"https://www.petri.com/wp-content/uploads/2015/11/Visual-Studio-Hero.jpg")) });
                }

            }
            count++;
        }
    }
}