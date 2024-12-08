using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3_LTMTW
{
    public class NhanVien
    {
       
        public string Msnv { get; set; } 
        public string TenNhanVien { get; set; } 
        public decimal Luong { get; set; }

        public static List<NhanVien> DanhSachNhanVien { get; set; } = new List<NhanVien>();
        public static void AddNhanVien(NhanVien nv)
        {
            DanhSachNhanVien.Add(nv);
        }

        public NhanVien() { }

        public NhanVien(string msnv, string tenNhanVien, decimal luong)
        {
            Msnv = msnv;
            TenNhanVien = tenNhanVien;
            Luong = luong;
        }


    }
}
