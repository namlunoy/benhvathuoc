using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BenhVaThuoc.Views
{
    public partial class PageTimKiem : UserControl
    {
        public PageTimKiem()
        {
            InitializeComponent();
        }

        private void Click_TimKiem(object sender, RoutedEventArgs e)
        {
            MainPage.Current.ShowChildViewNext(this, new PageKetQua());
        }
    }
}
