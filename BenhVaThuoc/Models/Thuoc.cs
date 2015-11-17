using BenhVaThuoc.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVaThuoc.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Thuoc : IItem
    {
        [SQLite.Column("id")]
        public string ID { get; set; }

        [SQLite.Column("ten")]
        public string Ten { get; set; }

        [SQLite.Column("dang_bao_che")]
        public string DangBaoChe { get; set; }

        [SQLite.Column("nsx")]
        public string NhaSanXuat { get; set; }

        [SQLite.Column("img")]
        public string ImgUrl { get; set; }

        [SQLite.Column("dong_goi")]
        public string DongGoi { get; set; }

        [SQLite.Column("duoc_ly")]
        public string DuocLy { get; set; }

        [SQLite.Column("thanh_phan")]
        public string ThanhPhan { get; set; }

        [SQLite.Column("ham_luong")]
        public string HamLuong { get; set; }

        [SQLite.Column("chi_dinh")]
        public string ChiDinh { get; set; }


        [SQLite.Column("chong_chi_dinh")]
        public string ChongChiDinh { get; set; }

        [SQLite.Column("tuong_tac")]
        public string TuongTac { get; set; }

        [SQLite.Column("tac_dung_phu")]
        public string TacDungPhu { get; set; }

        [SQLite.Column("de_phong")]
        public string DePhong { get; set; }

        [SQLite.Column("lieu_luong")]
        public string LieuLuong { get; set; }

        [SQLite.Column("bao_quan")]
        public string BaoQuan { get; set; }

        public string GetTitle()
        {
            return Ten;
        }
    }
}
