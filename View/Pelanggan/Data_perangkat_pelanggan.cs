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
    public partial class Data_perangkat_pelanggan : Form
    {
        public Data_perangkat_pelanggan()
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
            lvwPerangkat.Columns.Add("Jenis", 120, HorizontalAlignment.Center);
            lvwPerangkat.Columns.Add("Merk", 120, HorizontalAlignment.Center);
            lvwPerangkat.Columns.Add("Tipe", 120, HorizontalAlignment.Center);
        }
        void LoadData()
        {
            lblNama.Text = "Pelanggan : " + GetNamaPelanggan();
            lvwPerangkat.Items.Clear();

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT Id, Jenis, Merk, Tipe 
                       FROM Perangkat 
                       WHERE PelangganId = @pid";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", Session.PelangganId);

                    using (SQLiteDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            ListViewItem item = new ListViewItem(rd["Id"].ToString());
                            item.SubItems.Add(rd["Jenis"].ToString());
                            item.SubItems.Add(rd["Merk"].ToString());
                            item.SubItems.Add(rd["Tipe"].ToString());
                            lvwPerangkat.Items.Add(item);
                        }
                    }
                }
            }
        }
        private void lvwPerangkat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPerangkat.SelectedItems.Count > 0)
            {
                var item = lvwPerangkat.SelectedItems[0];
                txtJenis.Text = item.SubItems[1].Text;
                txtMerk.Text = item.SubItems[2].Text;
                txtTipe.Text = item.SubItems[3].Text;
            }
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
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtJenis.Text == "" || txtMerk.Text == "" || txtTipe.Text == "")
            {
                MessageBox.Show("Semua field wajib diisi");
                return;
            }

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Perangkat 
                       (PelangganId, Jenis, Merk, Tipe)
                       VALUES (@pid, @j, @m, @t)";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", Session.PelangganId);
                cmd.Parameters.AddWithValue("@j", txtJenis.Text);
                cmd.Parameters.AddWithValue("@m", txtMerk.Text);
                cmd.Parameters.AddWithValue("@t", txtTipe.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData();
            txtJenis.Clear();
            txtMerk.Clear();
            txtTipe.Clear();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPerangkat.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            int id = int.Parse(lvwPerangkat.SelectedItems[0].Text);

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE Perangkat 
                       SET Jenis=@j, Merk=@m, Tipe=@t
                       WHERE Id=@id AND PelangganId=@pid";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@j", txtJenis.Text);
                cmd.Parameters.AddWithValue("@m", txtMerk.Text);
                cmd.Parameters.AddWithValue("@t", txtTipe.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pid", Session.PelangganId);

                cmd.ExecuteNonQuery();
            }

            LoadData();
        }
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwPerangkat.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            int id = int.Parse(lvwPerangkat.SelectedItems[0].Text);

            if (MessageBox.Show("Yakin hapus data?", "Konfirmasi",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = DbContext.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Perangkat WHERE Id=@id AND PelangganId=@pid";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pid", Session.PelangganId);
                    cmd.ExecuteNonQuery();
                }

                LoadData();
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

        private void BtnlogoutDPP_Click(object sender, EventArgs e)
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
