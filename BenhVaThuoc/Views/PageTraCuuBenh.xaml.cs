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
    public partial class PageTraCuuBenh : UserControl
    {
        public PageTraCuuBenh()
        {
            InitializeComponent();
            Loaded += TraCuuBenh_Loaded;
        }

        void TraCuuBenh_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("TraCuuBenh_Loaded");
            //sdfsdfsdf
        }

        private void Click_ChiTietBenh(object sender, RoutedEventArgs e)
        {
            MainPage.Current.ShowChildViewNext(this, new PageChiTietBenh());
        }
    }
}
