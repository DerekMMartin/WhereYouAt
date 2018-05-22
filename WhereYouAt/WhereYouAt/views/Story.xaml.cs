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
		public Story ()
		{
            InitializeComponent();
            //RowDef.Height = new GridLength(((Height * 0.20)));
            for (int i = 0; i < 10; i++)
            {
                Lay.Children.Add(new Image()
                { Source = ImageSource.FromUri(new Uri(@"https://assets-cdn.github.com/images/modules/open_graph/github-logo.png"))});
            }
            //Lay.ItemsSource = s;
            //SwipeLayout
            
            //this.Content += new AndroidSwipeLayout.SwipeLayout();
        }
    }
}