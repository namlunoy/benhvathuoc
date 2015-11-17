using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BenhVaThuoc.ViewModels;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BenhVaThuoc.Views
{
    public partial class MyMenuItem : UserControl
    {

        public Menu MenuO { get; set; }

        public MyMenuItem(Menu menu)
        {
            MenuO = menu;
            InitializeComponent();
            LayoutRoot.Background = new SolidColorBrush(Colors.Transparent);
            Loaded += MenuItem_Loaded;
        }

        void MenuItem_Loaded(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(MenuO.ImageUri);
            title.Text = MenuO.Title;
        }

    }
}
