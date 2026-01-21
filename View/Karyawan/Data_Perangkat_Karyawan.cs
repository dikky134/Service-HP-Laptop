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
    public partial class Data_Perangkat_Karyawan : Form
    {
        public Data_Perangkat_Karyawan()
        {
            InitializeComponent();
            SetupListView();
            LoadData();
        }
        private void SetupListView()
        {
            lvwPerangkat.View = System.Windows.Forms.View.Details;
            lvwPerangkat.FullRowSelect = true;
            lvwPerangkat.GridLines = true;
            lvwPerangkat.Columns.Clear();

            lvwPerangkat.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwPerangkat.Columns.Add("Pelanggan", 120, HorizontalAlignment.Center);
            lvwPerangkat.Columns.Add("Jenis", 120, HorizontalAlignment.Center);
            lvwPerangkat.Columns.Add("Merk", 80, HorizontalAlignment.Center);
            lvwPerangkat.Columns.Add("Tipe", 80, HorizontalAlignment.Center);
        }
        private void LoadData()
        {
            lvwPerangkat.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
                 SELECT
                    p.Id,
                    pl.Nama,
                    p.Jenis,
                    p.Merk,
                    p.Tipe
                FROM Perangkat p
                JOIN Pelanggan pl ON p.PelangganId = pl.Id";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                using (SQLiteDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ListViewItem item = new ListViewItem(rd["Id"].ToString());
                        item.SubItems.Add(rd["Nama"].ToString());
                        item.SubItems.Add(rd["Jenis"].ToString());
                        item.SubItems.Add(rd["Merk"].ToString());
                        item.SubItems.Add(rd["Tipe"].ToString());

                        lvwPerangkat.Items.Add(item);
                    }
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
        private void btnRiwayatPembayaran_Click_1(object sender, EventArgs e)
        {
            Riwayat_Pembayaran_Karyawan riwayat = new Riwayat_Pembayaran_Karyawan();
            riwayat.Show();
            this.Close();
        }
        private void BtnlogoutDPK_Click(object sender, EventArgs e)
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
