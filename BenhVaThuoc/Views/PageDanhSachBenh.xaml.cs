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
using BenhVaThuoc.Database;

namespace BenhVaThuoc.Views
{
    public partial class PageDanhSachBenh : UserControl
    {
        public List<Benh> listBenh;
        NhomBenh nhom;
        public PageDanhSachBenh(NhomBenh nhomBenh)
        {
            InitializeComponent();
            nhom = nhomBenh;
            Loaded += PageChiTietBenh_Loaded;
        }

        void PageChiTietBenh_Loaded(object sender, RoutedEventArgs e)
        {
            listBenh = MyDB.Instance.Conn.Query<Benh>("select * from benh_chitiet where idcat=" + nhom.ID);
            listbox.ItemsSource = listBenh;
        }

        private void ClickVaoBenh(object sender, SelectionChangedEventArgs e)
        {
            Benh benhselected = listbox.SelectedItem as Benh;
            if (benhselected != null)
            {
                MainPage.Current.ShowChildViewNext(this, new PageChiTietBenh(benhselected));
            }
        }
    }
}
