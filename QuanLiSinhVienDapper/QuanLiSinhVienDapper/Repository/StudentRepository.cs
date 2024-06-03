using QuanLiSinhVienDapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Web;
using System.Text;

namespace QuanLiSinhVienDapper.Repository
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public IEnumerable<SinhVien> getAllSinhVien()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<SinhVien>("SELECT * FROM SinhVien");
            }
        }

        public int InsertSinhVien(SinhVien sv)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int insertedRows;
                StringBuilder sqlInsert = new StringBuilder();
                sqlInsert.Append($"insert into SinhVien(MaSV, TenSV, GioiTinh, DOB, Lop, Khoa) ");
                sqlInsert.Append($"values ('{sv.MaSV}', N'{sv.TenSV}', N'{sv.GioiTinh}', '{sv.DOB}', N'{sv.Lop}', {sv.Lop})");
                insertedRows = connection.Execute(sqlInsert.ToString());
                return insertedRows;
            }
        }

        public int Delete(string MaSV)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int deletedRows;
                deletedRows = connection.Execute($"DELETE FROM SinhVien where MaSV = '{MaSV}'");
                return deletedRows;
            }
        }

        public int UpdateSinhVien(SinhVien sv)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int updatedRows;
                StringBuilder sqlUpdate = new StringBuilder();
                sqlUpdate.Append($"UPDATE SinhVien set TenSV = N'{sv.TenSV}', GioiTinh = N'{sv.GioiTinh}', DOB = '{sv.DOB}', ");
                sqlUpdate.Append($"Lop = N'{sv.Lop}, Khoa = {sv.Khoa} where MaSV = '{sv.MaSV}'");
                updatedRows = connection.Execute(sqlUpdate.ToString());
                return updatedRows;
            }
        }

        public SinhVien getSinhVienByID(string MaSV)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"SELECT * FROM SinhVien where MaSV = '{MaSV}'";
                return connection.QueryFirstOrDefault<SinhVien>(sql);
            }
        }

        public List<SinhVien> getAllSinhVienByMaSVorTenSV(string search)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"SELECT * FROM SinhVien where TenSV like N'%{search}%' or MaSV like N'%{search}%'";
                List<SinhVien> lstSinhVien = connection.Query<SinhVien>(sql).ToList();
                if (lstSinhVien == null) lstSinhVien = new List<SinhVien>();
                return lstSinhVien;
            }
        }
    }
}