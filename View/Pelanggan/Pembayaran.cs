using AplikasiService.Model.Context;
using AplikasiService.Model.Entity;
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
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
            LoadPembayaran();
            SetupModePembayaran();

            dtpTanggalBayar.Value = DateTime.Now;
            dtpTanggalBayar.Enabled = false;
        }
        private void LoadPembayaran()
        {
            cmbPembayaran.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT Id, Total
            FROM Pembayaran
            WHERE PelangganId = @pid
              AND Status = 'Menunggu'";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", Session.PelangganId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cmbPembayaran.Items.Add(new ComboItem
                    {
                        Value = Convert.ToInt32(rd["Id"]),
                        Text = "Pembayaran #" + rd["Id"] + " - Rp " + rd["Total"]
                    });
                }
            }

            if (cmbPembayaran.Items.Count > 0)
                cmbPembayaran.SelectedIndex = 0;
        }
        private void cmbIdPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPembayaran.SelectedItem == null) return;

            int pembayaranId = ((ComboItem)cmbPembayaran.SelectedItem).Value;

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Total FROM Pembayaran WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", pembayaranId);

                object result = cmd.ExecuteScalar();
                txtTotal.Text = result.ToString();
            }
        }
        private void SetupModePembayaran()
        {
            cmbMetode.Items.Add("Tunai");
            cmbMetode.Items.Add("Transfer");
            cmbMetode.Items.Add("QRIS");
            cmbMetode.SelectedIndex = 0;
        }
        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            if (cmbPembayaran.SelectedItem == null)
            {
                MessageBox.Show("Pilih pembayaran");
                return;
            }

            if (cmbMetode.SelectedItem == null)
            {
                MessageBox.Show("Pilih metode pembayaran");
                return;
            }

            int pembayaranId = ((ComboItem)cmbPembayaran.SelectedItem).Value;
            string metode = cmbMetode.Text;

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
            UPDATE Pembayaran
            SET Metode = @m,
                Status = 'Dibayar',
                TanggalBayar = @tgl
            WHERE Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@m", metode);
                cmd.Parameters.AddWithValue("@tgl", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@id", pembayaranId);

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    MessageBox.Show("Data pembayaran tidak ditemukan");
                    return;
                }
            }

            MessageBox.Show("Pembayaran berhasil");
            LoadPembayaran();
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
        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            Riwayat_Pembayaran riwayat = new Riwayat_Pembayaran();
            riwayat.Show();
            this.Close();
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
