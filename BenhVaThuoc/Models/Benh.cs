using BenhVaThuoc.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//cong xing
namespace BenhVaThuoc.Models
{
    public class Benh : IItem
    {
        [SQLite.Column("id")]
        public int ID { get; set; }
        
        [SQLite.Column("title")]
        public string Ten { get; set; }

        [SQLite.Column("content")]
        public String NoiDung { get; set; }
        
        public string GetTitle()
        {
            return Ten;
        }
    }
}
