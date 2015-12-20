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
    public partial class PageChiTietThuoc : UserControl
    {
        private Thuoc thuoc;
        public PageChiTietThuoc(Thuoc thuoc)
        {
            InitializeComponent();
            this.thuoc = thuoc;
            LayoutRoot.DataContext = this.thuoc;
        }

    }
}
