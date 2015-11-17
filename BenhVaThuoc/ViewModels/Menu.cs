using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BenhVaThuoc.ViewModels
{
    public class Menu
    {
        public String Title { get; set; }
        public Uri ImageUri { get; set; }
        public UIElement View { get; set; }
    }
}
