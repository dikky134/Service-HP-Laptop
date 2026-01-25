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

            lvwDashboard.Columns.Add("ID", 40, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Pelanggan", 100, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Perangkat", 150, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Kerusakan", 100, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Tanggal", 90, HorizontalAlignment.Center);
            lvwDashboard.Columns.Add("Keterangan", 80, HorizontalAlignment.Center);
        }
        private void LoadData()
        {
            lvwDashboard.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                SELECT s.Id,
                       pl.Nama AS Pelanggan,
                       p.Jenis || ' ' || p.Merk || ' ' || p.Tipe  AS Perangkat,
                       k.NamaKerusakan,
                       s.Status,
                       s.TanggalServis,
                       s.Keterangan
                FROM Servis s
                JOIN JenisKerusakan k ON s.KerusakanId = k.Id
                JOIN Perangkat p ON k.PerangkatId = p.Id
                JOIN Pelanggan pl ON p.PelangganId = pl.Id
                WHERE s.Id NOT IN (SELECT ServisId FROM Pembayaran WHERE Status = 'Lunas')
                ORDER BY s.Id DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Pelanggan"].ToString());
                    item.SubItems.Add(rd["Perangkat"].ToString());
                    item.SubItems.Add(rd["NamaKerusakan"].ToString());
                    item.SubItems.Add(rd["TanggalServis"].ToString());
                    item.SubItems.Add(rd["Keterangan"].ToString());
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

        private void btnRiwayatPembayaran_Click(object sender, EventArgs e)
        {
            Riwayat_Pembayaran_Karyawan riwayat = new Riwayat_Pembayaran_Karyawan();
            riwayat.Show();
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
