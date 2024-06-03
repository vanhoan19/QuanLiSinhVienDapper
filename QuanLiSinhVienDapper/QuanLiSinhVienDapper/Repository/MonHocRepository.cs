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
    public class MonHocRepository
    {
        private readonly string _connectionString;
        public MonHocRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }
        public int Delete(string MaMH)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MonHoc> getAllMonHoc()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<MonHoc>("select * from MonHoc");
            }
        }

        public IEnumerable<MonHoc> getAllMonHocChuaDangKiByMaSV(string MaSV)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlCommand = $"select * from MonHoc where MaMH not in (select distinct MaMH from KetQua where MaSV = N'{MaSV}')";
                return connection.Query<MonHoc>(sqlCommand);
            }
        }

        public MonHoc getMonHocByID(string MaMH)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<MonHoc>($"select * from MonHoc where MaMH = N'{MaMH}'");
            }
        }

        public int InsertMonHoc(MonHoc mh)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int insertedRows;
                StringBuilder sqlInserted = new StringBuilder();
                sqlInserted.Append("insert into MonHoc(MaMH, TenMon, SoTiet, TiLeDTP, TiLeDQT) ");
                sqlInserted.Append($"values(N'{mh.MaMH}', N'{mh.TenMon}', {mh.SoTiet}, {mh.TiLeDTP}, {mh.TiLeDQT})");
                try
                {
                    insertedRows = connection.Execute(sqlInserted.ToString());
                }
                catch
                {
                    insertedRows = 0;
                }
                return insertedRows;
            }
        }

        public int UpdateMonHoc(MonHoc mh)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int updatedRows;
                StringBuilder sqlUpdated = new StringBuilder();
                sqlUpdated.Append($"update MonHoc set TenMon = N'{mh.TenMon}', SoTiet = {mh.SoTiet}, TiLeDTP = {mh.TiLeDTP}, ");
                sqlUpdated.Append($"TiLeDQT = {mh.TiLeDQT} where MaMH = N'{mh.MaMH}'");
                updatedRows = connection.Execute(sqlUpdated.ToString());
                return updatedRows;
            }
        }
    }
}