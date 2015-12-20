using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BenhVaThuoc.Resources;
using System.Diagnostics;
using Windows.Storage;
using BenhVaThuoc.Database;
using BenhVaThuoc.Views;
using BenhVaThuoc.ViewModels;

namespace BenhVaThuoc
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static MainPage Current { private set; get; }
        private Stack<UIElement> stack = new Stack<UIElement>();
        private PageTinTucSucKhoe tinTucPage;
        private PageNhomBenh traCuuBenhPage;


        /// <summary>
        /// This is the first method that you will use!
        /// (It check and load the database)
        /// </summary>
        private void StartDoingThingsFromHere()
        {
            Debug.WriteLine("LoadData");


        }

        #region Setup - Công stuffs
        public MainPage()
        {
            Current = this;

            traCuuBenhPage = new PageNhomBenh();
            tinTucPage = new PageTinTucSucKhoe();

            MyDB.DBFileIsReady += MyDB_DBFileIsReady;
            InitializeComponent();
            MenuList.Items.Add(new MyMenuItem(new Menu() { Title = "Tin Tức", View = new PageTinTucSucKhoe(), ImageUri = new Uri(@"/Assets/icons/ic_tintuc.png", UriKind.Relative) }));
            MenuList.Items.Add(new MyMenuItem(new Menu() { Title = "Tra Cứu Bệnh", View = new PageNhomBenh(), ImageUri = new Uri(@"/Assets/icons/ic_benh.png", UriKind.Relative) }));
            MenuList.Items.Add(new MyMenuItem(new Menu() { Title = "Tra Cứu Thuốc", View = new PageTraCuuThuoc(), ImageUri = new Uri(@"/Assets/icons/ic_thuoc.png", UriKind.Relative) }));
            MenuList.Items.Add(new MyMenuItem(new Menu() { Title = "Tìm kiếm", View = new PageTimKiem(), ImageUri = new Uri(@"/Assets/icons/ic_map.png", UriKind.Relative) }));
        }
        void MyDB_DBFileIsReady()
        {
            StartDoingThingsFromHere();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (MyDB.DBIsReady)
                StartDoingThingsFromHere();
        }


        private void ChonMenuItem(object sender, SelectionChangedEventArgs e)
        {
            if (e != null && MenuList.SelectedItem != null)
            {
                MyMenuItem item = MenuList.SelectedItem as MyMenuItem;
                if (item != null)
                {
                    ShowChildViewNext(null, item.MenuO.View);
                    slideView.SelectedIndex = 1;
                }
                MenuList.SelectedItem = null;
            }
        }

        public void ShowChildViewNext(UIElement oldView, UIElement newView)
        {
            if (oldView == null)
            {
                contentView.Children.Clear();
                contentView.Children.Add(newView);
            }
            else
            {
                stack.Push(oldView);
                contentView.Children.Clear();
                contentView.Children.Add(newView);
            }

        }


        #endregion

        private void Click_Back(object sender, EventArgs e)
        {
            if (stack.Count == 0)
            {
                slideView.SelectedIndex = 0;
            }
            else
            {
                contentView.Children.Clear();
                contentView.Children.Add(stack.Pop());
            }
        }

        private void Click_Search(object sender, EventArgs e)
        {
            ShowChildViewNext(null, new PageTimKiem());
            slideView.SelectedIndex = 1;
        }

    }
}