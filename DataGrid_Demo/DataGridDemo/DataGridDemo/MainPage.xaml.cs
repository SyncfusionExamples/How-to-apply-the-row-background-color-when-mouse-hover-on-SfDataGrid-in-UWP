using Syncfusion.SfDataGrid.XForms.DataPager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.Data;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;

namespace DataGridDemo
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        ViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            sfgrid.ItemsSource = viewModel.OrdersInfo;
       }
    }

}


