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
using webservice;
using System.Xml.Serialization;
using System.Text;

namespace BenhVaThuoc.Views
{
    public partial class PageTinTucSucKhoe : UserControl
    {
        public PageTinTucSucKhoe()
        {
            InitializeComponent();
            GetFileAsString();

        }



        private void GetFileAsString()
        {
            WebClient web = new WebClient();
            web.DownloadStringCompleted += downloadXong;
            web.DownloadStringAsync(new Uri("http://vnexpress.net/rss/suc-khoe.rss"));
        }

        void downloadXong(object sender, DownloadStringCompletedEventArgs e)
        {
            var item = GetListItem(e.Result);
            listItem.DataContext = item;
        }

        private static List<Item> GetListItem(string xml)
        {
            List<Item> listitem = null;

            var serializer = new XmlSerializer(typeof(Rss));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var rss = serializer.Deserialize(stream) as Rss;

            //if (rss.Channel != null)
            //{
            //    listitem = (from item in rss.Channel.item
            //                select new Item
            //                {
            //                    Title = item.Title,
            //                    Description = Substring(item.Description),
            //                    PubDate = SubDate(item.PubDate),
            //                    Uri = SubUri(item.Description),
            //                    Comments = (item.Comments),
            //                    Link = item.Link
            //                }).ToList();
            //}

            foreach (var item in rss.Channel.item)
                item.Uri = SubUri(item.Description);

            return rss.Channel.item;
        }

        public static string Substring(String input)
        {
            String searchString1 = "</br>";
            int startIndex = input.IndexOf(searchString1);
            input = input.Substring(startIndex + searchString1.Length);
            String searchString2 = "]]>";
            int endIndex = input.IndexOf(searchString2);
            if (endIndex > 0)
                input = input.Substring(0, endIndex);
            return input;
        }
        public static string SubUri(String input)
        {
            String searchString = "http://img.";
            int startIndex = input.IndexOf(searchString);
            input = input.Substring(startIndex);

            String searchString1 = "jpg";
            String searchString2 = "png";
            String searchString3 = "jpeg";
            int endIndex1 = input.IndexOf(searchString1);
            int endIndex2 = input.IndexOf(searchString2);
            int endIndex3 = input.IndexOf(searchString3);

            if (endIndex1 > 0)
            {
                input = input.Substring(0, endIndex1 + searchString1.Length);
            }
            if (endIndex2 > 0)
            {
                input = input.Substring(0, endIndex2 + searchString2.Length);
            }
            if (endIndex3 > 0)
            {
                input = input.Substring(0, endIndex3 + searchString3.Length);
            }
            return input;
        }
        //public static string SubDate(String input)
        //{
        //    String searchString1 = "<pubDate>";
        //    int startIndex = input.IndexOf(searchString1);
        //    input = input.Substring(startIndex + searchString1.Length);
        //    String searchString2 = "</pubDate>";
        //    int endIndex = input.IndexOf(searchString2);
        //    if (endIndex > 0)
        //        input = input.Substring(0, endIndex);
        //    return input;
        //}
        //public static string SubComment(String input)
        //{
        //    String searchString1 = "<slash:comments>";
        //    int startIndex = input.IndexOf(searchString1);
        //    input = input.Substring(startIndex + searchString1.Length);
        //    String searchString2 = "</slash:comments>";
        //    int endIndex = input.IndexOf(searchString2);
        //    if (endIndex > 0)
        //        input = input.Substring(0, endIndex);
        //    return input;
        //}
        public static Item SelectedItem;
        private void ClickItem(object sender, SelectionChangedEventArgs e)
        {
            SelectedItem = listItem.SelectedItem as Item;
            MainPage.Current.ShowChildViewNext(this, new PageChiTietBaiBao());
        }
    }
}
