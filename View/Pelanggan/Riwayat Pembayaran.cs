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
    public partial class Riwayat_Pembayaran : Form
    {
        public Riwayat_Pembayaran()
        {
            InitializeComponent();
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
            SetupListView();
            LoadRiwayatPembayaran();
        }

        private void LoadRiwayatPembayaran()
        {
            lvwRiwayatPembayaran.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT 
                p.Id_Pembayaran,
                p.Tanggal_Pembayaran,
                p.Total_Bayar,
                p.Metode_Pembayaran,
                p.Status_Pembayaran
            FROM Pembayaran p
            WHERE p.UserId = @uid
            ORDER BY p.Tanggal_Pembayaran DESC
        ";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", Session.UserId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(
                                reader["Id_Pembayaran"].ToString()
                            );

                            item.SubItems.Add(
                                Convert.ToDateTime(reader["Tanggal_Pembayaran"])
                                .ToString("dd/MM/yyyy")
                            );

                            item.SubItems.Add(
                                "Rp. " + reader["Total_Bayar"].ToString()
                            );

                            item.SubItems.Add(
                                reader["Metode_Pembayaran"].ToString()
                            );

                            item.SubItems.Add(
                                reader["Status_Pembayaran"].ToString()
                            );

                            lvwRiwayatPembayaran.Items.Add(item);

                            if (item.SubItems[4].Text == "Lunas")
                            {
                                item.ForeColor = Color.Green;
                            }
                            else
                            {
                                item.ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }
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
        private void SetupListView()
        {
            lvwRiwayatPembayaran.View = System.Windows.Forms.View.Details;
            lvwRiwayatPembayaran.FullRowSelect = true;
            lvwRiwayatPembayaran.GridLines = true;
            lvwRiwayatPembayaran.Columns.Clear();

            lvwRiwayatPembayaran.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwRiwayatPembayaran.Columns.Add("Tanggal", 120, HorizontalAlignment.Center);
            lvwRiwayatPembayaran.Columns.Add("Total", 120, HorizontalAlignment.Center);
            lvwRiwayatPembayaran.Columns.Add("Metode", 70, HorizontalAlignment.Center);
            lvwRiwayatPembayaran.Columns.Add("Status", 70, HorizontalAlignment.Center);
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
