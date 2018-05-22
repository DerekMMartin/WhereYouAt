using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WhereYouAt.pages;

namespace WhereYouAt
{
    public partial class MainPage : TabbedPage
    {
        //public double MainHeight { get; } = Application.Current.MainPage.Height;
        public MainPage()
        {
            InitializeComponent();
            CurrentPage = Children[2];
        }
       
    }
}
