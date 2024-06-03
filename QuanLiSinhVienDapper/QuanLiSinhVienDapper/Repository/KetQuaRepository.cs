using Dapper;
using QuanLiSinhVienDapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace QuanLiSinhVienDapper.Repository
{
    public class KetQuaRepository
    {
        private readonly string _connectionString;

        public KetQuaRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public int Delete(string MaSV, string MaMH)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int deletedRows;
                deletedRows = connection.Execute($"delete KetQua where MaSV = N'{MaSV}' and MaMH = N'{MaMH}'");
                return deletedRows;
            }
        }

        public IEnumerable<KetQua> getAllKetQua()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                StringBuilder sqlSelect = new StringBuilder();
                sqlSelect.Append("select sv.MaSV, mh.MaMH, DQT, DTP, DiemTong, TrangThai, TenSV, TenMon from KetQua kq");
                sqlSelect.Append(" inner join SinhVien sv on sv.MaSV = kq.MaSV ");
                sqlSelect.Append(" inner join MonHoc mh on mh.MaMH = kq.MaMH ");
                return connection.Query<KetQua>(sqlSelect.ToString());
            }
        }

        public int InsertKetQua(KetQua kq)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int insertedRows;
                var dqtValue = kq.DQT != null ? kq.DQT.ToString() : "NULL";
                var dtpValue = kq.DTP != null ? kq.DTP.ToString() : "NULL";
                var diemTongValue = kq.DiemTong != null ? kq.DiemTong.ToString() : "NULL";
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"insert into KetQua(MaSV, MaMH, DQT, DTP, DiemTong, TrangThai) ");
                stringBuilder.Append($"values (N'{kq.MaSV}', N'{kq.MaMH}', {dqtValue}, {dtpValue}, {diemTongValue}, N'{kq.TrangThai}')");
                insertedRows = connection.Execute(stringBuilder.ToString());
                return insertedRows;
            }
        }

        public int UpdateKetQua(KetQua kq)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int updatedRows;
                StringBuilder sqlUpdate = new StringBuilder();
                var dqt = (kq.DQT != null) ? kq.DQT.ToString() : "NULL"; 
                var dtp = (kq.DTP != null) ? kq.DTP.ToString() : "NULL"; 
                var diemTong = (kq.DiemTong != null) ? kq.DiemTong.ToString() : "NULL";
                sqlUpdate.Append($"update KetQua set DQT = {dqt}, DTP = {dtp}, ");
                sqlUpdate.Append($"DiemTong = {diemTong}, TrangThai = N'{kq.TrangThai}' ");
                sqlUpdate.Append($" where MaSV = N'{kq.MaSV}' and MaMH = N'{kq.MaMH}'");
                updatedRows = connection.Execute(sqlUpdate.ToString());
                return updatedRows;
            }
        }

        public IEnumerable<KetQua> getAllKetQuaByMaSV(string MaSV)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                StringBuilder sqlSelect = new StringBuilder();
                sqlSelect.Append("select sv.MaSV, mh.MaMH, DQT, DTP, DiemTong, TrangThai, TenSV, TenMon from KetQua kq");
                sqlSelect.Append(" inner join SinhVien sv on sv.MaSV = kq.MaSV ");
                sqlSelect.Append(" inner join MonHoc mh on mh.MaMH = kq.MaMH ");
                sqlSelect.Append($" where kq.MaSV = N'{MaSV}'");
                return connection.Query<KetQua>(sqlSelect.ToString());
            }
        }

        public IEnumerable<KetQua> getAllKetQuaDangHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                StringBuilder sqlSelect = new StringBuilder();
                sqlSelect.Append("select sv.MaSV, mh.MaMH, DQT, DTP, DiemTong, TrangThai, TenSV, TenMon from KetQua kq");
                sqlSelect.Append(" inner join SinhVien sv on sv.MaSV = kq.MaSV ");
                sqlSelect.Append(" inner join MonHoc mh on mh.MaMH = kq.MaMH ");
                sqlSelect.Append($" where TrangThai = N'Đang học'");
                return connection.Query<KetQua>(sqlSelect.ToString());
            }
        }

        public IEnumerable<KetQua> getAllKetQuaDangHocByMaMH(string MaMH)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                StringBuilder sqlSelect = new StringBuilder();
                sqlSelect.Append("select sv.MaSV, mh.MaMH, DQT, DTP, DiemTong, TrangThai, TenSV, TenMon from KetQua kq");
                sqlSelect.Append(" inner join SinhVien sv on sv.MaSV = kq.MaSV ");
                sqlSelect.Append(" inner join MonHoc mh on mh.MaMH = kq.MaMH ");
                sqlSelect.Append($" where TrangThai = N'Đang học' and kq.MaMH = N'{MaMH}'");
                return connection.Query<KetQua>(sqlSelect.ToString());
            }
        }
    }
}