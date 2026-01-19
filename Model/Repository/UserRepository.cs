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
    public class UserRepository
    {
        public User Login(string username, string password)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT * FROM Users 
                               WHERE Username=@u AND Password=@p";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return new User
                    {
                        Id = int.Parse(rd["Id"].ToString()),
                        Username = rd["Username"].ToString(),
                        Role = rd["Role"].ToString()
                    };
                }
            }
            return null;
        }

        public int Insert(User user)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Users 
                (Username,Password,Role)
                VALUES (@u,@p,@r)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role);
                cmd.ExecuteNonQuery();

                return (int)conn.LastInsertRowId;
            }
        }
    }
}
