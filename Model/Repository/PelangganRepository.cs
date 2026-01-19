using AplikasiService.Model.Context;
using AplikasiService.Model.Entity;
using AplikasiService.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AplikasiService.Model.Repository
{
    public class PelangganRepository
    {
        private SQLiteConnection conn;

        public PelangganRepository(SQLiteConnection conn)
        {
            this.conn = conn;
        }

        public Pelanggan GetByUserId(int userId)
        {
            Pelanggan pelanggan = null;

            string sql = @"SELECT * FROM Pelanggan 
                           WHERE UserId = @UserId";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);

                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        pelanggan = new Pelanggan
                        {
                            Id = dtr.GetInt32(0),
                            UserId = dtr.GetInt32(1),
                            Nama = dtr.GetString(2),
                            Alamat = dtr.GetString(3),
                            NoHp = dtr.GetString(4)
                        };
                    }
                }
            }
            return pelanggan;
        }
    }
}
