using AplikasiService.Controller;
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
    public partial class Pembayaran_Karyawan : Form
    {
        public Pembayaran_Karyawan()
        {
            InitializeComponent();
            SetupListView();
            LoadServis();
            LoadPembayaran();
            dtpTanggal.Value = DateTime.Now;
        }
        private void SetupListView()
        {
            lvwPembayaran.View = System.Windows.Forms.View.Details;
            lvwPembayaran.FullRowSelect = true;
            lvwPembayaran.GridLines = true;
            lvwPembayaran.Columns.Clear();

            lvwPembayaran.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvwPembayaran.Columns.Add("Perangkat", 160, HorizontalAlignment.Center);
            lvwPembayaran.Columns.Add("Kerusakan", 120, HorizontalAlignment.Center);
            lvwPembayaran.Columns.Add("Biaya Service", 100, HorizontalAlignment.Center);
            lvwPembayaran.Columns.Add("Harga Jasa", 100, HorizontalAlignment.Center);
            lvwPembayaran.Columns.Add("Total", 100, HorizontalAlignment.Center);
        }
        private void LoadServis()
        {
            cmbServis.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                SELECT s.Id,
                   p.Jenis || ' ' || p.Merk || ' ' || p.Tipe AS Perangkat,
                   k.NamaKerusakan,
                   k.Biaya
                FROM Servis s
                JOIN JenisKerusakan k ON s.KerusakanId = k.Id
                JOIN Perangkat p ON k.PerangkatId = p.Id
                WHERE s.Id NOT IN (SELECT ServisId FROM Pembayaran)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    cmbServis.Items.Add(new ComboItem
                    {
                        Text = rd["Perangkat"] + " - " + rd["NamaKerusakan"],
                        Value = Convert.ToInt32(rd["Id"]),     
                        Extra = Convert.ToInt32(rd["Biaya"])  
                    });
                }
            }

            if (cmbServis.Items.Count > 0)
                cmbServis.SelectedIndex = 0;
        }
        private void cmbServis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServis.SelectedItem == null) return;

            var item = (ComboItem)cmbServis.SelectedItem;

            txtHargaService.Text = item.Extra.ToString();

            HitungTotal();
        }
        private void txtHargaJasa_TextChanged(object sender, EventArgs e)
        {
            HitungTotal();
        }
        private void HitungTotal()
        {
            int hargaService = 0;
            int hargaJasa = 0;

            int.TryParse(txtHargaService.Text, out hargaService);
            int.TryParse(txtHargaJasa.Text, out hargaJasa);

            txtTotal.Text = (hargaService + hargaJasa).ToString();
        }
        private void btnDataPelanggan_Click(object sender, EventArgs e)
        {
            Data_Pelanggan_Karyawan dataPelanggan = new Data_Pelanggan_Karyawan();
            dataPelanggan.Show();
            this.Close();
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbServis.SelectedItem == null)
            {
                MessageBox.Show("Pilih servis terlebih dahulu");
                return;
            }

            var servis = (ComboItem)cmbServis.SelectedItem;

            decimal hargaJasa = 0;
            decimal.TryParse(txtHargaJasa.Text, out hargaJasa);

            decimal total = 0;
            decimal.TryParse(txtTotal.Text, out total);

            string tanggalBayar = dtpTanggal.Value.ToString("yyyy-MM-dd");

            int servisId = servis.Value;
            int pelangganId = GetPelangganIdByServis(servisId);

            if (pelangganId == 0)
            {
                MessageBox.Show("Pelanggan tidak ditemukan");
                return;
            }

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
                INSERT INTO Pembayaran
                (ServisId, TanggalBayar, PelangganId, HargaJasa, Total, Status)
                VALUES (@sid, @tgl, @pid, @hj, @t, 'Menunggu')";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sid", servisId);
                cmd.Parameters.AddWithValue("@tgl", tanggalBayar);
                cmd.Parameters.AddWithValue("@pid", pelangganId);
                cmd.Parameters.AddWithValue("@hj", hargaJasa);
                cmd.Parameters.AddWithValue("@t", total);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Pembayaran berhasil ditambahkan");

            LoadPembayaran();
            LoadServis();

            txtHargaJasa.Clear();
            txtHargaService.Clear();
            txtTotal.Clear();
        }
        private int GetPelangganIdByServis(int servisId)
        {
            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT pl.Id
            FROM Servis s
            JOIN JenisKerusakan jk ON s.KerusakanId = jk.Id
            JOIN Perangkat p ON jk.PerangkatId = p.Id
            JOIN Pelanggan pl ON p.PelangganId = pl.Id
            WHERE s.Id = @sid";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sid", servisId);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private void LoadPembayaran()
        {
            lvwPembayaran.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT p.Id,
                           pr.Jenis || ' ' || pr.Merk || ' ' || pr.Tipe AS Perangkat,
                           k.NamaKerusakan,
                           k.biaya,
                           p.HargaJasa,
                           p.Total
                    FROM Pembayaran p
                    JOIN Servis s ON p.ServisId = s.Id
                    JOIN JenisKerusakan k ON s.KerusakanId = k.Id
                    JOIN Perangkat pr ON k.PerangkatId = pr.Id
                    WHERE p.Status = 'Menunggu'
                    ORDER BY p.Id DESC";


                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Perangkat"].ToString());
                    item.SubItems.Add(rd["NamaKerusakan"].ToString());
                    item.SubItems.Add(rd["Biaya"].ToString());
                    item.SubItems.Add(rd["HargaJasa"].ToString());
                    item.SubItems.Add(rd["Total"].ToString());

                    lvwPembayaran.Items.Add(item);
                }
            }
        }
        private void btnDashboard_Click(object sender, EventArgs e)
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
        private void btnRiwayatPembayaran_Click_1(object sender, EventArgs e)
        {
            Riwayat_Pembayaran_Karyawan riwayat = new Riwayat_Pembayaran_Karyawan();
            riwayat.Show();
            this.Close();
        }
       
        private void BtnlogoutPK_Click(object sender, EventArgs e)
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
