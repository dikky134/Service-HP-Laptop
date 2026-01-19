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
        int serviceId = 0;
        int totalBiaya = 0;
        bool serviceValid = false;
        public Pembayaran()
        {
            InitializeComponent();
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
            dtpTanggalBayar.Value = DateTime.Now;
            dtpTanggalBayar.Enabled = false;
            cmbMetode.Items.Add("Tunai");
            cmbMetode.Items.Add("Transfer");
            cmbMetode.Items.Add("QRIS");
            cmbMetode.SelectedIndex = 0;

            txtTotalBiaya.ReadOnly = true;
            btnKonfirmasi.Enabled = false;
        }
        private void btnCek_Click(object sender, EventArgs e)
        {
            serviceValid = false;
            btnKonfirmasi.Enabled = false;

            if (!int.TryParse(txtServiceId.Text, out serviceId))
            {
                MessageBox.Show("ID Service tidak valid");
                txtTotalBiaya.Clear();
                return;
            }

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT Biaya
                       FROM Servis
                       WHERE Id=@id AND PelangganId=@pid";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", serviceId);
                cmd.Parameters.AddWithValue("@pid", Session.PelangganId);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("ID Service tidak ditemukan");
                    txtTotalBiaya.Clear();
                    return;
                }

                totalBiaya = Convert.ToInt32(result);
                txtTotalBiaya.Text = totalBiaya.ToString("N0");

                // 👉 SERVICE VALID
                serviceValid = true;
                btnKonfirmasi.Enabled = true;
            }
        }
        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            if (serviceId == 0)
            {
                MessageBox.Show("Cek ID Service terlebih dahulu");
                return;
            }

            string metode = cmbMetode.Text;

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                // INSERT PEMBAYARAN
                string insert = @"INSERT INTO Pembayaran
                                  (ServisId, TanggalBayar, Metode, Total)
                                  VALUES (@sid, @tgl, @mtd, @total)";

                SQLiteCommand cmd = new SQLiteCommand(insert, conn);
                cmd.Parameters.AddWithValue("@sid", serviceId);
                cmd.Parameters.AddWithValue("@tgl", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@mtd", metode);
                cmd.Parameters.AddWithValue("@total", totalBiaya);
                cmd.ExecuteNonQuery();

                // UPDATE STATUS SERVICE
                string update = @"UPDATE Servis
                                  SET Status='Lunas' 
                                  WHERE Id=@id";

                SQLiteCommand cmdUpdate = new SQLiteCommand(update, conn);
                cmdUpdate.Parameters.AddWithValue("@id", serviceId);
                cmdUpdate.ExecuteNonQuery();
            }

            MessageBox.Show("Pembayaran berhasil");

            txtServiceId.Clear();
            txtTotalBiaya.Clear();
            serviceId = 0;
            totalBiaya = 0;
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
