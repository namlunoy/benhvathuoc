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

namespace BenhVaThuoc
{
    public partial class MainPage : PhoneApplicationPage
    {

        public MainPage()
        {
            MyDB.DBFileIsReady += MyDB_DBFileIsReady;

            InitializeComponent();
        }

        void MyDB_DBFileIsReady()
        {
            LoadData();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (MyDB.DBIsReady)
                LoadData();
        }
        private void LoadData()
        {
            Debug.WriteLine("LoadData");
           var l = MyDB.Instance.GetListNhomBenh();
           foreach (var item in l)
           {
               listbox.Items.Add(item.ToString());
           }

        }


    }
}