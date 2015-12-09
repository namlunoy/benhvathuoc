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
using System.IO;

namespace BenhVaThuoc.Views
{
    public partial class PageTinTucSucKhoe : UserControl
    {
        public PageTinTucSucKhoe()
        {
            InitializeComponent();
            //Loaded += TinTucSucKhoe_Loaded;
            UseWebClient("http://vnexpress.net/rss/suc-khoe.rss");
        }

        private void UseWebClient(string address)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(address);
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback);
            client.DownloadStringAsync(uri);
        }

        private void DownloadStringCallback(object sender, DownloadStringCompletedEventArgs e)
        {
            //string text = e.Result;
            //System.Diagnostics.Debugger.Break();
            if (!e.Cancelled && e.Error == null)
            {
                string textString = (string)e.Result;

                Console.WriteLine(textString);
            }
        }


        //void TinTucSucKhoe_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Debug.WriteLine("TinTucSucKhoe_Loaded");
        //}

        //private void Click_XemChiTiet(object sender, RoutedEventArgs e)
        //{
        //    MainPage.Current.ShowChildViewNext(this, new PageChiTietBaiBao());
        //}
        //private void tile_Tap()
        //{
        //    WebClient wc = new WebClient();
        //    wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);

        //    wc.OpenReadAsync(new Uri("http://vnexpress.net/rss/suc-khoe.rss"));
        //}

        //void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        //{
        //    try
        //    {
        //        StreamReader s = new StreamReader(e.Result);
        //        string r = s.ReadToEnd();
        //        MessageBox.Show(r);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        
       
    }
}
