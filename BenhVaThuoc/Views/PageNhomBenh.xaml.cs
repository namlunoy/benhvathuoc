﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using BenhVaThuoc.Database;
using BenhVaThuoc.Models;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BenhVaThuoc.Views
{
    public partial class PageNhomBenh : UserControl
    {
        private List<NhomBenh> listNhomBenh;
        public PageNhomBenh()
        {
            InitializeComponent();
            Loaded += TraCuuBenh_Loaded;
        }

        void TraCuuBenh_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("TraCuuBenh_Loaded");
            listNhomBenh = MyDB.Instance.Conn.Query<NhomBenh>("select * from benh_category");
            listbox.ItemsSource = listNhomBenh;
        }



        private void ClickVaoNhomBenh(object sender, SelectionChangedEventArgs e)
        {
            NhomBenh nhom = listbox.SelectedItem as NhomBenh;
            if (nhom != null)
                MainPage.Current.ShowChildViewNext(this, new PageDanhSachBenh(nhom));
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            String key = tbSearch.Text;
            MainPage.Current.ShowChildViewNext(this, new PageDanhSachBenh(key));

        }
    }
}