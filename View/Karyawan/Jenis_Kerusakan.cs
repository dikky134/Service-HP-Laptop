using AplikasiService.Model.Context;
using AplikasiService.Model.Session;
using AplikasiService.Model.Entity;
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
    public partial class Jenis_Kerusakan : Form
    {
        public Jenis_Kerusakan()
        {
            InitializeComponent();
            SetupListView();
            LoadPerangkat();
            LoadData();
        }
        private void SetupListView()
        {
            lvwKerusakan.View = System.Windows.Forms.View.Details;
            lvwKerusakan.FullRowSelect = true;
            lvwKerusakan.GridLines = true;

            lvwKerusakan.Columns.Clear();
            lvwKerusakan.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwKerusakan.Columns.Add("Perangkat", 120, HorizontalAlignment.Center);
            lvwKerusakan.Columns.Add("Biaya", 120, HorizontalAlignment.Center);
            lvwKerusakan.Columns.Add("Kerusakan", 120, HorizontalAlignment.Center);
            lvwKerusakan.Columns.Add("Tanggal", 100, HorizontalAlignment.Center);
        }
        private void LoadData()
        {
            lvwKerusakan.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT k.Id,
                           p.Jenis || ' ' || p.Merk || ' ' || p.Tipe AS Perangkat,
                           k.NamaKerusakan,
                           k.Biaya,
                           k.Status,
                           k.Tanggal
                    FROM JenisKerusakan k
                    JOIN Perangkat p ON k.PerangkatId = p.Id";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Perangkat"].ToString());
                    item.SubItems.Add(rd["NamaKerusakan"].ToString());
                    item.SubItems.Add(rd["Biaya"].ToString());
                    item.SubItems.Add(rd["Tanggal"].ToString());
                    lvwKerusakan.Items.Add(item);
                }
            }
        }
        private void LoadPerangkat()
        {
            cmbPerangkat.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT Id, Jenis, Merk, Tipe FROM Perangkat";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    cmbPerangkat.Items.Add(new ComboItem
                    {
                        Text = $"{rd["Id"]} - {rd["Jenis"]} {rd["Merk"]} {rd["Tipe"]}",
                        Value = Convert.ToInt32(rd["Id"])
                    });
                }
            }

            if (cmbPerangkat.Items.Count > 0)
                cmbPerangkat.SelectedIndex = 0;
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (cmbPerangkat.SelectedItem == null ||
                txtKerusakan.Text == "" ||
                txtBiaya.Text == "" )
            {
                MessageBox.Show("Lengkapi data");
                return;
            }

            var perangkat = (ComboItem)cmbPerangkat.SelectedItem;

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO JenisKerusakan
                    (PerangkatId, NamaKerusakan, Biaya, Tanggal)
                    VALUES (@pid, @k, @b, @t)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", perangkat.Value);
                cmd.Parameters.AddWithValue("@k", txtKerusakan.Text);
                cmd.Parameters.AddWithValue("@b", int.Parse(txtBiaya.Text));
                cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
            }

            LoadData();
            txtKerusakan.Clear();
            txtBiaya.Clear();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
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

        private void btnService_Click(object sender, EventArgs e)
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
        private void BtnlogoutJK_Click(object sender, EventArgs e)
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
