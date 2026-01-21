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
    public partial class Data_Pelanggan_Karyawan : Form
    {
        public Data_Pelanggan_Karyawan()
        {
            InitializeComponent();
            SetupListView();
            LoadData();
        }
        private void SetupListView()
        {
            lvwDataPelanggan.View = System.Windows.Forms.View.Details;
            lvwDataPelanggan.FullRowSelect = true;
            lvwDataPelanggan.GridLines = true;
            lvwDataPelanggan.Columns.Clear();

            lvwDataPelanggan.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwDataPelanggan.Columns.Add("Nama", 120, HorizontalAlignment.Center);
            lvwDataPelanggan.Columns.Add("No. HP", 120, HorizontalAlignment.Center);
            lvwDataPelanggan.Columns.Add("Alamat", 80, HorizontalAlignment.Center);
        }
        private void LoadData()
        {
            lvwDataPelanggan.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
                 SELECT
                    p.Id,
                    p.Nama,
                    p.NoHP,
                    p.Alamat
                FROM Pelanggan p";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                using (SQLiteDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ListViewItem item = new ListViewItem(rd["Id"].ToString());
                        item.SubItems.Add(rd["Nama"].ToString());
                        item.SubItems.Add(rd["NoHP"].ToString());
                        item.SubItems.Add(rd["Alamat"].ToString());

                        lvwDataPelanggan.Items.Add(item);
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
        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            RIwayat_pb_Karyawan Riwayat = new RIwayat_pb_Karyawan();
            Riwayat.Show();
            this.Close();
        }
        private void BtnlogoutPP1_Click(object sender, EventArgs e)
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
