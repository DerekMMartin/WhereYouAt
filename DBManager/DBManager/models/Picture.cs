using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhereYouAt.models
{
    public class Picture
    {
        public int id { get; set; }
        public int OwnerId { get; set; }
        public string Text { get; set; }
        public ImageSource Image{ get; set; }
    }

}
