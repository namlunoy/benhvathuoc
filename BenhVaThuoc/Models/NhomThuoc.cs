using BenhVaThuoc.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVaThuoc.Models
{
    public class NhomThuoc : IItem
    {
        [SQLite.Column("id")]
        public string ID { get; set; }

        [SQLite.Column("ten")]
        public string Ten { get; set; }

        public string GetTitle()
        {
            return Ten;
        }
    }
}
