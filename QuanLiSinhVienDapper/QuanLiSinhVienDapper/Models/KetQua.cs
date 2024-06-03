using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVienDapper.Models
{
    public class KetQua
    {
        public string MaSV { get; set; }
        public string MaMH { get; set; }
        public double? DQT { get; set; }
        public double? DTP { get; set; }
        public double? DiemTong { get; set; }
        public string TrangThai { get; set; }
        public string TenSV { get; set; }
        public string TenMon { get; set; }
        public KetQua()
        {
            
        }

        public KetQua(string maSV, string maMH, double? dQT, double? dTP, double? diemTong, string trangThai)
        {
            MaSV = maSV;
            MaMH = maMH;
            DQT = dQT;
            DTP = dTP;
            DiemTong = diemTong;
            TrangThai = trangThai;
        }

        public KetQua(string maSV, string maMH, double? dQT, double? dTP, double? diemTong, string trangThai, string tenSV, string tenMon) : this(maSV, maMH, dQT, dTP, diemTong, trangThai)
        {
            TenSV = tenSV;
            TenMon = tenMon;
        }
    }
}