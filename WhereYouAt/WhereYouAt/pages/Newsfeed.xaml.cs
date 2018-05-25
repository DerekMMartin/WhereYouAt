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
            StackyBoy.Children.Add(new Story());
            StackyBoy.Children.Add(new Story());
        }
	}
}