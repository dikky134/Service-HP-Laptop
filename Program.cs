using AplikasiService.Model.Context;
using AplikasiService.View;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace AplikasiService
{
    internal static class Program
    {
        static void CreateTableIfNotExists()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT,
                    Password TEXT,
                    Role TEXT
                );";

                new SQLiteCommand(sql, conn).ExecuteNonQuery();
            }
        }

        static void CreateAdmin()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string cek = "SELECT COUNT(*) FROM Users WHERE Role='Admin'";
                SQLiteCommand cmd = new SQLiteCommand(cek, conn);

                long count = (long)cmd.ExecuteScalar();
                if (count == 0)
                {
                    string insert = @"
                    INSERT INTO Users (Username, Password, Role)
                    VALUES ('admin','admin','Admin')";
                    new SQLiteCommand(insert, conn).ExecuteNonQuery();
                }
            }
        }
        static void EnableWAL()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                new SQLiteCommand("PRAGMA journal_mode=WAL;", conn).ExecuteNonQuery();
            }
        }

        [STAThread]
        static void Main()
        {
            CreateTableIfNotExists();
            CreateAdmin();
            EnableWAL();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
