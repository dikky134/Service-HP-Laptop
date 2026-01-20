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
    public partial class Dashboard_Pelanggan : Form
    {
        public Dashboard_Pelanggan()
        {
            InitializeComponent();
            SetupListView();
            LoadData();
        }
        private void SetupListView()
        {
            lvwDashboard.View = System.Windows.Forms.View.Details;
            lvwDashboard.FullRowSelect = true;
            lvwDashboard.GridLines = true;
            lvwDashboard.Columns.Clear();

            lvwDashboard.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Perangkat", 120, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Kerusakan", 120, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Tanggal", 100, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Biaya", 100, HorizontalAlignment.Center);
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
        private void LoadData()
        {
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
            lvwDashboard.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT k.Id,
                           p.Jenis || ' ' || p.Merk || ' ' || p.Tipe AS Perangkat,
                           k.NamaKerusakan,
                           k.Tanggal,
                           k.Biaya
                    FROM JenisKerusakan k
                    JOIN Perangkat p ON k.PerangkatId = p.Id
                    WHERE p.PelangganId = @pid
                    ORDER BY k.Id DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", Session.PelangganId);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Perangkat"].ToString());
                    item.SubItems.Add(rd["NamaKerusakan"].ToString());
                    item.SubItems.Add(rd["Tanggal"].ToString());
                    item.SubItems.Add(rd["Biaya"].ToString());
                    lvwDashboard.Items.Add(item);
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Pelanggan dashboard = new Dashboard_Pelanggan();
            dashboard.Show();
            this.Close();
        }

        private void btnPerangkat_Click(object sender, EventArgs e)
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

        private void btnLogOut_Click_1(object sender, EventArgs e)
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
