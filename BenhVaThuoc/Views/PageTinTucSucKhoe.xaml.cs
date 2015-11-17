using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;

namespace BenhVaThuoc.Views
{
    public partial class PageTinTucSucKhoe : UserControl
    {
        public PageTinTucSucKhoe()
        {
            InitializeComponent();
            Loaded += TinTucSucKhoe_Loaded;
        }

        void TinTucSucKhoe_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("TinTucSucKhoe_Loaded");
        }

        private void Click_XemChiTiet(object sender, RoutedEventArgs e)
        {
            MainPage.Current.ShowChildViewNext(this, new PageChiTietBaiBao());
        }

       
    }
}
