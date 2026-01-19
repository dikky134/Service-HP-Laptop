using AplikasiService.Model.Context;
using AplikasiService.Model.Session;
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
    public partial class Pembayaran : Form
    {
        public Pembayaran()
        {
            InitializeComponent();
        }
        private void Nama_Pelanggan_Load(object sender, EventArgs e)
        {
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
        }

        private string GetNamaPelanggan()
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = "SELECT Nama FROM Pelanggan WHERE UserId=@uid";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", Session.UserId);

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "-";
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Pelanggan dashboard = new Dashboard_Pelanggan();
            dashboard.Show();
            this.Close();
        }

        private void btnDataPerangkat_Click(object sender, EventArgs e)
        {
            Data_perangkat_pelanggan dataPerangkat = new Data_perangkat_pelanggan();
            dataPerangkat.Show();
            this.Close();
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            Pembayaran pembayaran = new Pembayaran();
            pembayaran.Show();
            this.Close();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Hapus session
                Session.Clear();

                // Kembali ke login
                Login login = new Login();
                login.Show();

                this.Close();
            }
        }
    }
}
