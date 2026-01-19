using AplikasiService.Controller;
using AplikasiService.Model.Session;
using AplikasiService.Model.Context;
using AplikasiService.Model.Entity;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnMasuk_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username dan Password wajib diisi");
                return;
            }

            // Panggil controller
            UserController controller = new UserController();
            User user = controller.Login(
                txtUsername.Text,
                txtPassword.Text
            );

            // Jika login gagal
            if (user == null)
            {
                MessageBox.Show("Username atau Password salah");
                return;
            }

            // Simpan ke Session
            Session.UserId = user.Id;
            Session.Username = user.Username;
            Session.Role = user.Role;

            MessageBox.Show("Login berhasil");

            // Arahkan sesuai role
            if (user.Role == "Admin")
            {
                new Dashboard_Karyawan().Show();
            }
            else
            {
                // Ambil data pelanggan
                PelangganController pelController = new PelangganController();
                var pelanggan = pelController.GetByUserId(user.Id);

                Session.PelangganId = pelanggan.Id;

                new Dashboard_Pelanggan().Show();
            }

            this.Hide();
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Close();
        }
    }
}
