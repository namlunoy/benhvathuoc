using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BenhVaThuoc.Models;

namespace BenhVaThuoc.Views
{
    public partial class PageChiTietBenh : UserControl
    {
        Benh benh;
        public PageChiTietBenh(Benh benh)
        {
            InitializeComponent();
            Loaded += PageChiTietBenh_Loaded;
            this.benh = benh;
        }

        void PageChiTietBenh_Loaded(object sender, RoutedEventArgs e)
        {
            txt.Text = benh.NoiDung;
        }
    }
}
