using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVienDapper.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime DOB { get; set; }
        public string Lop { get; set; }
        public int Khoa { get; set; }

        public SinhVien(string maSV, string tenSV, string gioiTinh, DateTime dOB, string lop, int khoa)
        {
            MaSV = maSV;
            TenSV = tenSV;
            GioiTinh = gioiTinh;
            DOB = dOB;
            Lop = lop;
            Khoa = khoa;
        }
    }
}