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
    public partial class Detail_service_pelanggan : Form
    {
        int _ServisId;
        private int _perangkatId;
        public Detail_service_pelanggan(int ServisId)
        {
            InitializeComponent();
            _ServisId = ServisId;
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
            SetupListView();
            LoadData();
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
            lvwDetail.View = System.Windows.Forms.View.Details;
            lvwDetail.FullRowSelect = true;
            lvwDetail.GridLines = true;

            lvwDetail.Columns.Clear();
            lvwDetail.Columns.Add("Perangkat", 120, HorizontalAlignment.Center);
            lvwDetail.Columns.Add("Tanggal", 120, HorizontalAlignment.Center);
            lvwDetail.Columns.Add("Status", 120, HorizontalAlignment.Center);
            lvwDetail.Columns.Add("Keterangan", 250, HorizontalAlignment.Center);
        }
        private void LoadData()
        {
            lvwDetail.Items.Clear();

            int pelangganId = Session.PelangganId;

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        p.Jenis || ' ' || p.Merk || ' ' || p.Tipe AS NamaPerangkat,
                        d.Tanggal,
                        d.Status,
                        d.Keterangan
                    FROM DetailService d
                    JOIN Servis s ON d.ServiceId = s.Id
                    JOIN JenisKerusakan k ON s.KerusakanId = k.Id
                    JOIN Perangkat p ON k.PerangkatId = p.Id
                    WHERE p.PelangganId = @pid
                    ORDER BY d.Tanggal DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", pelangganId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["NamaPerangkat"].ToString());
                    item.SubItems.Add(rd["Tanggal"].ToString());
                    item.SubItems.Add(rd["Status"].ToString());
                    item.SubItems.Add(rd["Keterangan"].ToString());
                    lvwDetail.Items.Add(item);
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
