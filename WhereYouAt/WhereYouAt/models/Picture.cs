using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhereYouAt.models
{
    public class Picture
    {
        public int ownerid { get; set; }
        public string text { get; set; }
        public ImageSource Image{ get; set; }
    }

}
