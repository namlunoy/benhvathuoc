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
    public partial class PageDanhSachThuoc : UserControl
    {
        private List<Thuoc> listthuoc;
        NhomThuoc nhomThuoc;
        private string keySearch;

        public PageDanhSachThuoc(NhomThuoc  nhomThuoc)
        {
            InitializeComponent();
            this.nhomThuoc = nhomThuoc;
            Loaded += PageDanhSachThuoc_Loaded;
        }

        public PageDanhSachThuoc(string keySearch)
        {
            InitializeComponent();
            this.keySearch = keySearch;
            listthuoc = MyDB.Instance.Conn.Query<Thuoc>("select * from thuoc where ten like '%"+keySearch+"%'");
            listbox.ItemsSource = listthuoc;
        }

        void PageDanhSachThuoc_Loaded(object sender, RoutedEventArgs e)
        {
            listthuoc = MyDB.Instance.Conn.Query<Thuoc>("select * from thuoc where id_cate='"+nhomThuoc.ID+"'");
            listbox.ItemsSource = listthuoc;
        }

        private void ClickViewChiTietThuoc(object sender, SelectionChangedEventArgs e)
        {
            Thuoc thuoc = listbox.SelectedItem as Thuoc;
            if (thuoc != null)
            {
                MainPage.Current.ShowChildViewNext(this, new PageChiTietThuoc(thuoc));
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Thuoc> lsThuocResult = new List<Thuoc>();
            lsThuocResult=listthuoc.Where(c => c.Ten.ToLower().Contains(tbSearch.Text)).ToList();
            listbox.ItemsSource = lsThuocResult;
        }
    }
}
