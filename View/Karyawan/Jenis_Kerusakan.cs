using AplikasiService.Model.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
