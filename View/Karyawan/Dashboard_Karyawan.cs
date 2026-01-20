using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplikasiService.Model.Context;
using AplikasiService.Model.Session;
using System.Data.SQLite;

namespace AplikasiService.View
{
    public partial class Dashboard_Karyawan : Form
    {
        public Dashboard_Karyawan()
        {
            InitializeComponent();
            SetupListView();
            LoadData();
        }
        void SetupListView()
        {
            lvwDashboard.View = System.Windows.Forms.View.Details;
            lvwDashboard.FullRowSelect = true;
            lvwDashboard.GridLines = true;
            lvwDashboard.Columns.Clear();

            lvwDashboard.Columns.Add("ID", 40);
            lvwDashboard.Columns.Add("Pelanggan", 100);
            lvwDashboard.Columns.Add("Perangkat", 150);
            lvwDashboard.Columns.Add("Kerusakan", 100);
            lvwDashboard.Columns.Add("Status", 90);
            lvwDashboard.Columns.Add("Tanggal", 90);
            lvwDashboard.Columns.Add("Biaya", 80);
        }
        private void LoadData()
        {
            lvwDashboard.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT k.Id,
                           pl.Nama AS Pelanggan,
                           p.Jenis || ' ' || p.Merk || ' ' || p.Tipe AS Perangkat,
                           k.NamaKerusakan,
                           k.Status,
                           k.Tanggal,
                           k.Biaya
                    FROM JenisKerusakan k
                    JOIN Perangkat p ON k.PerangkatId = p.Id
                    JOIN Pelanggan pl ON p.PelangganId = pl.Id
                    ORDER BY k.Id DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Pelanggan"].ToString());
                    item.SubItems.Add(rd["Perangkat"].ToString());
                    item.SubItems.Add(rd["NamaKerusakan"].ToString());
                    item.SubItems.Add(rd["Status"].ToString());
                    item.SubItems.Add(rd["Tanggal"].ToString());
                    item.SubItems.Add(rd["Biaya"].ToString());
                    lvwDashboard.Items.Add(item);
                }
            }
        }
        private void btnDasboard_Click(object sender, EventArgs e)
        {
            Dashboard_Karyawan dashboard = new Dashboard_Karyawan();
            dashboard.Show();
            this.Close();
        }
        private void btnDataPelanggan_Click(object sender, EventArgs e)
        {
            Data_Pelanggan_Karyawan dataPelanggan = new Data_Pelanggan_Karyawan();
            dataPelanggan.Show();
            this.Close();
        }

        private void btnDataPerangkat_Click(object sender, EventArgs e)
        {
            Data_Perangkat_Karyawan dataPerangkat = new Data_Perangkat_Karyawan();
            dataPerangkat.Show();
            this.Close();
        }

        private void btnDataService_Click(object sender, EventArgs e)
        {
            Data_Service_Karyawan dataService = new Data_Service_Karyawan();
            dataService.Show();
            this.Close();
        }

        private void btnKerusakan_Click(object sender, EventArgs e)
        {
            Jenis_Kerusakan kerusakan = new Jenis_Kerusakan();
            kerusakan.Show();
            this.Close();
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            Pembayaran_Karyawan pembayaran = new Pembayaran_Karyawan();
            pembayaran.Show();
            this.Close();
        }

        private void BtnlogoutP_Click(object sender, EventArgs e)
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
