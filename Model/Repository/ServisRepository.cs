using AplikasiService.Model.Context;
using AplikasiService.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiService.Model.Repository
{
    public class ServisRepository
    {
        public void Insert(Servis s)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Servis
                (PerangkatId, JenisKerusakanId, TanggalServis, Status, Biaya)
                VALUES (@pid,@jkid,@tgl,@status, @biaya)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", s.PerangkatId);
                cmd.Parameters.AddWithValue("@jkid", s.KerusakanId);
                cmd.Parameters.AddWithValue("@status", s.Status);
                cmd.Parameters.AddWithValue("@biaya", s.Biaya);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Servis> GetByPelanggan(int pelangganId)
        {
            List<Servis> list = new List<Servis>();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
                SELECT s.* FROM Servis s
                JOIN Perangkat p ON s.PerangkatId = p.Id
                WHERE p.PelangganId = @pid";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", pelangganId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Servis
                    {
                        Id = int.Parse(rd["Id"].ToString()),
                        PerangkatId = int.Parse(rd["PerangkatId"].ToString()),
                        KerusakanId = int.Parse(rd["KerusakanId"].ToString()),
                        Status = rd["Status"].ToString(),
                        Biaya = int.Parse(rd["Biaya"].ToString())
                    });
                }
            }
            return list;
        }
    }
}
