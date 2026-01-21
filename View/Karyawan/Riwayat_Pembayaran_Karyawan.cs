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
            // 1. Setup dulu kolomnya, baru load datanya
            SetupListView();
            LoadData();

        }
        private void SetupListView()
        {
            lvwRiwayat.View = System.Windows.Forms.View.Details;
            lvwRiwayat.FullRowSelect = true;
            lvwRiwayat.GridLines = true;
            lvwRiwayat.Columns.Clear();

            // Lebar kolom disesuaikan agar rapi
            lvwRiwayat.Columns.Add("ID", 50);
            lvwRiwayat.Columns.Add("Perangkat", 180);
            lvwRiwayat.Columns.Add("Kerusakan", 150);
            lvwRiwayat.Columns.Add("Total", 100); // Akan diformat Rupiah
            lvwRiwayat.Columns.Add("Metode", 100);
            lvwRiwayat.Columns.Add("Tanggal Bayar", 120);
            lvwRiwayat.Columns.Add("Status", 80);
        }

        private void LoadData()
        {
            lvwRiwayat.Items.Clear();

            try
            {
                using (var conn = DbContext.GetConnection())
                {
                    conn.Open();

                    // PERBAIKAN QUERY:
                    // 1. JOIN Perangkat melalui Servis (s.PerangkatId), bukan JenisKerusakan
                    // 2. WHERE clause menggunakan s.PelangganId (karena PelangganId ada di tabel Servis)
                    string sql = @"
                    SELECT pb.Id,
                        p.Jenis || ' ' || p.Merk || ' ' || p.Tipe AS Perangkat,
                        jk.NamaKerusakan,
                        pb.Total,
                        pb.Metode,
                        pb.TanggalBayar,
                        pb.Status
                    FROM Pembayaran pb
                    JOIN Servis s ON pb.ServisId = s.Id
                    JOIN JenisKerusakan jk ON s.KerusakanId = jk.Id
                    JOIN Perangkat p ON s.PerangkatId = p.Id
                    WHERE s.PelangganId = @pid
                    ORDER BY pb.Id DESC";

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@pid", Session.PelangganId);

                    using (SQLiteDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            ListViewItem item = new ListViewItem(rd["Id"].ToString());

                            // Tambah Sub-items
                            item.SubItems.Add(rd["Perangkat"].ToString());
                            item.SubItems.Add(rd["NamaKerusakan"].ToString());

                            // Format Total ke Rupiah (Cek DBNull dulu)
                            if (rd["Total"] != DBNull.Value)
                            {
                                decimal total = Convert.ToDecimal(rd["Total"]);
                                item.SubItems.Add(string.Format("Rp {0:N0}", total));
                            }
                            else
                            {
                                item.SubItems.Add("Rp 0");
                            }

                            item.SubItems.Add(rd["Metode"].ToString());

                            // Format Tanggal (Cek DBNull dulu)
                            if (rd["TanggalBayar"] != DBNull.Value)
                            {
                                DateTime tgl = Convert.ToDateTime(rd["TanggalBayar"]);
                                item.SubItems.Add(tgl.ToString("dd/MM/yyyy"));
                            }
                            else
                            {
                                item.SubItems.Add("-");
                            }

                            item.SubItems.Add(rd["Status"].ToString());

                            lvwRiwayat.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data Riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Kode Tombol Navigasi (Tidak berubah) ---

        
       

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
