using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace AplikasiService.Model.Context
{
    public class DbContext
    {
        private static string connString =
            "Data Source=database.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            string connStr = "Data Source=database.db;Version=3;Busy Timeout=5000;";
            return new SQLiteConnection(connStr);
        }
    }
}
