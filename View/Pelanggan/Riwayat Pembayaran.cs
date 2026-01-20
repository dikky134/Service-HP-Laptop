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
    public partial class Riwayat_Pembayaran : Form
    {
        public Riwayat_Pembayaran()
        {
            InitializeComponent();
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
            LoadData();
            SetupListView();
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
        private void SetupListView()
        {
            lvwRiwayat.View = System.Windows.Forms.View.Details;
            lvwRiwayat.FullRowSelect = true;
            lvwRiwayat.GridLines = true;
            lvwRiwayat.Columns.Clear();

            lvwRiwayat.Columns.Add("ID", 50);
            lvwRiwayat.Columns.Add("Perangkat", 150);
            lvwRiwayat.Columns.Add("Kerusakan", 120);
            lvwRiwayat.Columns.Add("Total", 100);
            lvwRiwayat.Columns.Add("Metode", 100);
            lvwRiwayat.Columns.Add("Tanggal", 120);
            lvwRiwayat.Columns.Add("Status", 80);
        }
        private void LoadData()
        {
            lvwRiwayat.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

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
                JOIN Perangkat p ON jk.PerangkatId = p.Id
                WHERE pb.PelangganId = @pid
                ORDER BY pb.Id DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", Session.PelangganId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["Id"].ToString());
                    item.SubItems.Add(rd["Perangkat"].ToString());
                    item.SubItems.Add(rd["NamaKerusakan"].ToString());
                    item.SubItems.Add("Rp " + rd["Total"].ToString());
                    item.SubItems.Add(rd["Metode"].ToString());
                    item.SubItems.Add(rd["TanggalBayar"].ToString());
                    item.SubItems.Add(rd["Status"].ToString());

                    lvwRiwayat.Items.Add(item);
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Pelanggan dashboard = new Dashboard_Pelanggan();
            dashboard.Show();
            this.Close();
        }

        private void btnDataPerangkat_Click(object sender, EventArgs e)
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

        private void btnLogOut_Click(object sender, EventArgs e)
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
