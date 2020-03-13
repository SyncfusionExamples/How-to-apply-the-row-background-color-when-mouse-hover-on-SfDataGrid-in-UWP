using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataGridDemo
{
    public class ViewModel : NotificationObject
    {
        internal OrderInfoRepository order;

        internal string[] Customers = new string[] { "Adams", "Crowley", "Ellis", "Gable", "Irvine", "Keefe", "Mendoza", "Owens", "Rooney", "Wadded", };

        public ViewModel()
        {
            order = new OrderInfoRepository();
            SetRowstoGenerate(70);
            SelectedItem = this.ordersInfo[2];
            this.CustomerNames = Customers.ToObservableCollection();
        }

        #region ItemsSource

        public ObservableCollection<string> CustomerNames { get; set; }

        private ObservableCollection<OrderInfo> ordersInfo;
        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set
            {
                this.ordersInfo = value;
                RaiseCollectionChanged("OrdersInfo");
            }
        }

        private OrderInfo selectedItem;

        public OrderInfo SelectedItem
        {
            get { return selectedItem; }
            set
            {
                this.selectedItem = value;
                RaiseCollectionChanged("SelectedItem");
            }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            OrdersInfo = order.GetOrderDetails(count);
        }

        #endregion
    }

    public class NotificationObject : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseCollectionChanged(string propName)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
