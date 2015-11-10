using BenhVaThuoc.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVaThuoc.Models
{
    public class NhomBenh : IItem
    {
        [SQLite.Column("id")]
        public int ID { get; set; }

         [SQLite.Column("name")]
        public string Ten { get; set; }

        public string GetTitle()
        {
            return Ten;
        }

        public override string ToString()
        {
            return Ten;
        }
    }
}
