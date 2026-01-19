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
    public class PerangkatRepository
    {
        public void Insert(Perangkat p)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Perangkat
                (PelangganId, Jenis, Merk, Tipe)
                VALUES (@pid,@nama,@merk, @model)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", p.PelangganId);
                cmd.Parameters.AddWithValue("@jenis", p.Jenis);
                cmd.Parameters.AddWithValue("@merk", p.Merk);
                cmd.Parameters.AddWithValue("@model", p.Tipe);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Perangkat> GetByPelanggan(int pelangganId)
        {
            List<Perangkat> list = new List<Perangkat>();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT * FROM Perangkat
                               WHERE PelangganId=@pid";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", pelangganId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Perangkat
                    {
                        Id = int.Parse(rd["Id"].ToString()),
                        PelangganId = int.Parse(rd["PelangganId"].ToString()),
                        Jenis = rd["Jenis"].ToString(),
                        Merk = rd["Merk"].ToString(),
                        Tipe = rd["Model"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
