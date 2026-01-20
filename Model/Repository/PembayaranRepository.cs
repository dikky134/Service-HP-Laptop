using AplikasiService.Model.Context;
using AplikasiService.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Model.Repository
{
    public class PembayaranRepository
    {
        public void Insert(Pembayaran p)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Pembayaran
                (ServisId, TanggalBayar, TanggalBuat, Total, Metode, Status)
                VALUES (@sid,@tglbyr, @tglbuat ,@total,@metode, @status)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sid", p.ServisId);
                cmd.Parameters.AddWithValue("@tglbyr", p.TanggalBayar);
                cmd.Parameters.AddWithValue("@tglbuat", p.TanggalBuat);
                cmd.Parameters.AddWithValue("@total", p.Total);
                cmd.Parameters.AddWithValue("@metode", p.Metode);
                cmd.Parameters.AddWithValue("@status", p.Status);

                cmd.ExecuteNonQuery();
            }
        }

        public Pembayaran GetByServis(int servisId)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT * FROM Pembayaran
                               WHERE ServisId=@sid";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sid", servisId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return new Pembayaran
                    {
                        Id = int.Parse(rd["Id"].ToString()),
                        ServisId = int.Parse(rd["ServisId"].ToString()),
                        TanggalBayar = rd["TanggalBayar"].ToString(),
                        TanggalBuat = rd["TanggalBuat"].ToString(),
                        Total = int.Parse(rd["Total"].ToString()),
                        Metode = rd["Metode"].ToString(),
                        Status = rd["Status"].ToString()
                    };
                }
            }
            return null;
        }
    }
}
