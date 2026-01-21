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
    public partial class Data_Service_Karyawan : Form
    {
        public Data_Service_Karyawan()
        {
            InitializeComponent();
            LoadKerusakan();
            SetupListView();
            LoadData();

            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Diproses");
            cmbStatus.Items.Add("Selesai");
            cmbStatus.SelectedIndex = 0;
        }
        private void SetupListView()
        {
            lvwService.View = System.Windows.Forms.View.Details;
            lvwService.FullRowSelect = true;
            lvwService.GridLines = true;
            lvwService.Columns.Clear();

            lvwService.Columns.Add("ID", 40);
            lvwService.Columns.Add("Perangkat & Kerusakan", 150);
            lvwService.Columns.Add("Status", 100);
            lvwService.Columns.Add("Tanggal", 100);
            lvwService.Columns.Add("Keterangan", 200);
        }
        private void LoadKerusakan()
        {
            cmbKerusakan.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT k.Id,
                           p.Jenis || ' ' || p.Merk || ' ' || p.Tipe || 
                           ' - ' || k.NamaKerusakan AS Info
                    FROM JenisKerusakan k
                    JOIN Perangkat p ON k.PerangkatId = p.Id";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    cmbKerusakan.Items.Add(new ComboItem
                    {
                        Text = rd["Info"].ToString(),
                        Value = Convert.ToInt32(rd["Id"])
                    });
                }
            }

            if (cmbKerusakan.Items.Count > 0)
                cmbKerusakan.SelectedIndex = 0;
        }
        private void LoadData()
        {
            lvwService.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT s.Id,
                        p.Jenis || ' ' || p.Merk || ' ' || p.Tipe || 
                        ' - ' || k.NamaKerusakan AS Info,
                        s.Status,
                        s.TanggalServis,
                        s.Keterangan
                    FROM Servis s
                    JOIN JenisKerusakan k ON s.KerusakanId = k.Id
                    JOIN Perangkat p ON k.PerangkatId = p.Id
                    WHERE s.Id NOT IN (
                    SELECT ServisId FROM Pembayaran WHERE Status = 'Lunas')
                    ORDER BY s.Id DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Info"].ToString());
                    item.SubItems.Add(rd["Status"].ToString());
                    item.SubItems.Add(rd["TanggalServis"].ToString());
                    item.SubItems.Add(rd["Keterangan"].ToString());
                    lvwService.Items.Add(item);
                }
            }
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (cmbKerusakan.SelectedItem == null || txtKeterangan.Text == "")
            {
                MessageBox.Show("Lengkapi data");
                return;
            }

            var kerusakan = (ComboItem)cmbKerusakan.SelectedItem;
            long serviceId;

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                // 1️⃣ INSERT ke tabel Servis
                string sqlServis = @"
            INSERT INTO Servis
            (KerusakanId, Status, Keterangan, TanggalServis)
            VALUES (@kid, @s, @k, @t);
            SELECT last_insert_rowid();";

                SQLiteCommand cmdServis = new SQLiteCommand(sqlServis, conn);
                cmdServis.Parameters.AddWithValue("@kid", kerusakan.Value);
                cmdServis.Parameters.AddWithValue("@s", cmbStatus.Text);
                cmdServis.Parameters.AddWithValue("@k", txtKeterangan.Text);
                cmdServis.Parameters.AddWithValue("@t", DateTime.Now.ToString("yyyy-MM-dd"));

                serviceId = (long)cmdServis.ExecuteScalar();

                string sqlDetail = @"
                INSERT INTO DetailService
                (ServiceId, Tanggal, Status, Keterangan)
                VALUES (@sid, @tgl, @status, @ket)";

                SQLiteCommand cmdDetail = new SQLiteCommand(sqlDetail, conn);
                cmdDetail.Parameters.AddWithValue("@sid", serviceId);
                cmdDetail.Parameters.AddWithValue("@tgl", DateTime.Now.ToString("yyyy-MM-dd"));
                cmdDetail.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmdDetail.Parameters.AddWithValue("@ket", txtKeterangan.Text);

                cmdDetail.ExecuteNonQuery();
            }

            MessageBox.Show("Servis dan detail servis berhasil ditambahkan");
            LoadData();
            txtKeterangan.Clear();
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
        private void BtnlogoutDSK_Click(object sender, EventArgs e)
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
