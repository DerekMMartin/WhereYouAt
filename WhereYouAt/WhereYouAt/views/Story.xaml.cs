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
        {
            InitializeComponent();
            RowDef.Height = new GridLength(App.DisplayScreenHeight / 5);

            for (int i = 0; i < 5; i++)
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
            if (count > 1)
                count = 0;

        }
    }
}