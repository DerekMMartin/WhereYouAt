using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhereYouAt.views;

namespace WhereYouAt.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Newsfeed : ContentPage
	{
        public Newsfeed()
        {
            InitializeComponent();
            StackyBoy.Children.Add(new Story(null,this));
            StackyBoy.Children.Add(new Story(null,this));
        }
        public void BigImage(Image i)
        {
            Image temp = new Image() { Source = i.Source };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                ClearImage();
            };
            temp.GestureRecognizers.Add(tapGestureRecognizer);
            FullImage.Children.Add(temp);
            FullImage.IsEnabled = true;
            FullImage.IsVisible = true;
        }

        public void ClearImage()
        {
            FullImage.IsVisible = false;
            FullImage.IsEnabled = false;
            FullImage.Children.Clear();
        }
        
	}
}