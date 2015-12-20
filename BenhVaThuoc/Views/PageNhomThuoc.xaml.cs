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
    public partial class PageNhomThuoc : UserControl
    {
        private List<NhomThuoc> listNhomThuoc;
        public PageNhomThuoc()
        {
            InitializeComponent();
            Loaded += PageNhomThuoc_Loaded;
        }

        void PageNhomThuoc_Loaded(object sender, RoutedEventArgs e)
        {
            listNhomThuoc = MyDB.Instance.Conn.Query<NhomThuoc>("select * from thuoc_category ");
            listbox.ItemsSource = listNhomThuoc;
        }

        private void clickVaoNhomThuoc(object sender, SelectionChangedEventArgs e)
        {
            NhomThuoc nhomThuoc = listbox.SelectedItem as NhomThuoc;
            if (nhomThuoc != null)
            {
                MainPage.Current.ShowChildViewNext(this, new PageDanhSachThuoc(nhomThuoc));
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Current.ShowChildViewNext(this, new PageDanhSachThuoc(tbSearch.Text));
        }
    }
}
