using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLiSinhVienDapper.Models
{
    public class MonHoc
    {
        [Required(ErrorMessage = "Mã MH là bắt buộc")]
        [DisplayName("Mã MH")]
        public string MaMH { get; set; }
        [Required(ErrorMessage = "Tên môn là bắt buộc")]
        [DisplayName("Tên môn")]
        public string TenMon { get; set; }
        [DisplayName("Số tiết")]
        public int SoTiet { get; set; }
        [DisplayName("Tỉ lệ DTP")]
        public int TiLeDTP { get; set; }
        [DisplayName("Tỉ lệ DQT")]
        public int TiLeDQT { get; set; }
        public MonHoc()
        {
            
        }
        public MonHoc(string maMH, string tenMon, int soTiet, int tiLeDTP, int tiLeDQT)
        {
            MaMH = maMH;
            TenMon = tenMon;
            SoTiet = soTiet;
            TiLeDTP = tiLeDTP;
            TiLeDQT = tiLeDQT;
        }
    }
}