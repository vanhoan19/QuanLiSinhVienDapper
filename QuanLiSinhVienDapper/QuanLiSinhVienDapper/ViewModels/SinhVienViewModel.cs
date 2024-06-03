using QuanLiSinhVienDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiSinhVienDapper.ViewModels
{
    public class SinhVienViewModel
    {
        public SinhVien sinhVien { get; set; }
        public IEnumerable<KetQua> listDangKy { get; set; }
        public IEnumerable<MonHoc> listChuaDangKy { get; set; }

        public SinhVienViewModel(SinhVien sinhVien, IEnumerable<KetQua> listDangKy, IEnumerable<MonHoc> listChuaDangKy)
        {
            this.sinhVien = sinhVien;
            this.listDangKy = listDangKy;
            this.listChuaDangKy = listChuaDangKy;
        }
    }
}