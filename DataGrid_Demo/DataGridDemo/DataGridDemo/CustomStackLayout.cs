using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataGridDemo
{
    public class CustomStackLayout : StackLayout
    {
        public CustomStackLayout()
        {

        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
        }
    }
}
