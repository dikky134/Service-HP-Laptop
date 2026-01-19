using AplikasiService.Model.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiService.View
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnDaftar_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" ||
        txtPassword.Text == "" ||
        txtKonfirmasi.Text == "" ||
        txtNama.Text == "" ||
        txtAlamat.Text == "" ||
        txtNoHp.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi");
                return;
            }

            if (txtPassword.Text != txtKonfirmasi.Text)
            {
                MessageBox.Show("Password tidak sama");
                return;
            }

            using (SQLiteConnection conn = DbContext.GetConnection())
            {
                conn.Open();

                // 1️⃣ CEK USERNAME
                string cekUser = "SELECT COUNT(*) FROM Users WHERE Username=@u";
                using (SQLiteCommand cekCmd = new SQLiteCommand(cekUser, conn))
                {
                    cekCmd.Parameters.AddWithValue("@u", txtUsername.Text);

                    long count = (long)cekCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Username sudah digunakan");
                        return;
                    }
                }

                // 2️⃣ INSERT USER
                string insertUser = @"INSERT INTO Users 
            (Username, Password, Role)
            VALUES (@u,@p,'Pelanggan')";

                using (SQLiteCommand userCmd = new SQLiteCommand(insertUser, conn))
                {
                    userCmd.Parameters.AddWithValue("@u", txtUsername.Text);
                    userCmd.Parameters.AddWithValue("@p", txtPassword.Text);
                    userCmd.ExecuteNonQuery();
                }

                long userId = conn.LastInsertRowId;

                // 3️⃣ INSERT PELANGGAN
                string insertPel = @"INSERT INTO Pelanggan
            (UserId, Nama, Alamat, NoHP)
            VALUES (@uid,@n,@a,@hp)";

                using (SQLiteCommand pelCmd = new SQLiteCommand(insertPel, conn))
                {
                    pelCmd.Parameters.AddWithValue("@uid", userId);
                    pelCmd.Parameters.AddWithValue("@n", txtNama.Text);
                    pelCmd.Parameters.AddWithValue("@a", txtAlamat.Text);
                    pelCmd.Parameters.AddWithValue("@hp", txtNoHp.Text);
                    pelCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Pendaftaran berhasil, silakan login");

            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnMasuk_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
