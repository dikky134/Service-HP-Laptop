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
    public partial class Riwayat_Pembayaran_Karyawan : Form
    {
        public Riwayat_Pembayaran_Karyawan()
        {
            InitializeComponent();
            SetupListView();
            LoadData();

        }
        private void SetupListView()
        {
            lvwRiwayat.View = System.Windows.Forms.View.Details;
            lvwRiwayat.FullRowSelect = true;
            lvwRiwayat.GridLines = true;

            lvwRiwayat.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwRiwayat.Columns.Add("Pelanggan", 100, HorizontalAlignment.Center);
            lvwRiwayat.Columns.Add("Perangkat", 120, HorizontalAlignment.Center);
            lvwRiwayat.Columns.Add("Kerusakan", 80, HorizontalAlignment.Center);
            lvwRiwayat.Columns.Add("Total", 100, HorizontalAlignment.Center);
            lvwRiwayat.Columns.Add("Metode", 100, HorizontalAlignment.Center);
            lvwRiwayat.Columns.Add("Status", 80, HorizontalAlignment.Center);
            lvwRiwayat.Columns.Add("Tanggal", 100, HorizontalAlignment.Center);
        }

        private void LoadData()
        {
            lvwRiwayat.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                SELECT pb.Id,
                       pl.Nama,
                       pr.Jenis || ' ' || pr.Merk || ' ' || pr.Tipe,
                       k.NamaKerusakan,
                       pb.Total,
                       pb.Metode,
                       pb.Status,
                       pb.TanggalBayar
                FROM Pembayaran pb
                JOIN Pelanggan pl ON pb.PelangganId = pl.Id
                JOIN Servis s ON pb.ServisId = s.Id
                JOIN JenisKerusakan k ON s.KerusakanId = k.Id
                JOIN Perangkat pr ON k.PerangkatId = pr.Id
                ORDER BY pb.Id DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Nama"].ToString());
                    item.SubItems.Add(rd[2].ToString());
                    item.SubItems.Add(rd["NamaKerusakan"].ToString());
                    item.SubItems.Add(rd["Total"].ToString());
                    item.SubItems.Add(rd["Metode"].ToString());
                    item.SubItems.Add(rd["Status"].ToString());
                    item.SubItems.Add(rd["TanggalBayar"].ToString());

                    lvwRiwayat.Items.Add(item);
                }
            }
        }

        private void BtnlogoutSK_Click(object sender, EventArgs e)
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Karyawan dashboard = new Dashboard_Karyawan();
            dashboard.Show();
            this.Close();
        }

        private void btnPelanggan_Click(object sender, EventArgs e)
        {
            Data_Pelanggan_Karyawan dataPelanggan = new Data_Pelanggan_Karyawan();
            dataPelanggan.Show();
            this.Close();
        }

        private void btnPerangkat_Click(object sender, EventArgs e)
        {
            Data_Perangkat_Karyawan dataPerangkat = new Data_Perangkat_Karyawan();
            dataPerangkat.Show();
            this.Close();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            Data_Service_Karyawan dataService = new Data_Service_Karyawan();
            dataService.Show();
            this.Close();
        }

        private void btnkerusakan_Click(object sender, EventArgs e)
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
    }
}
