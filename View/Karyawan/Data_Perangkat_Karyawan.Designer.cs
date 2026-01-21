namespace AplikasiService.View
{
    partial class Data_Perangkat_Karyawan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDPK1 = new System.Windows.Forms.Panel();
            this.lblDPK = new System.Windows.Forms.Label();
            this.pnlDPK2 = new System.Windows.Forms.Panel();
            this.btnDasboard = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnKerusakan = new System.Windows.Forms.Button();
            this.TxtDPK1 = new System.Windows.Forms.TextBox();
            this.BtnlogoutDPK = new System.Windows.Forms.Button();
            this.btnDataService = new System.Windows.Forms.Button();
            this.btnDataPerangkat = new System.Windows.Forms.Button();
            this.btnDataPelanggan = new System.Windows.Forms.Button();
            this.pnlDPK3 = new System.Windows.Forms.Panel();
            this.lvwPerangkat = new System.Windows.Forms.ListView();
            this.btnRiwayatPembayaran = new System.Windows.Forms.Button();
            this.pnlDPK1.SuspendLayout();
            this.pnlDPK2.SuspendLayout();
            this.pnlDPK3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDPK1
            // 
            this.pnlDPK1.BackColor = System.Drawing.Color.White;
            this.pnlDPK1.Controls.Add(this.lblDPK);
            this.pnlDPK1.Location = new System.Drawing.Point(1, 10);
            this.pnlDPK1.Name = "pnlDPK1";
            this.pnlDPK1.Size = new System.Drawing.Size(882, 65);
            this.pnlDPK1.TabIndex = 11;
            // 
            // lblDPK
            // 
            this.lblDPK.AutoSize = true;
            this.lblDPK.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPK.Location = new System.Drawing.Point(634, 15);
            this.lblDPK.Name = "lblDPK";
            this.lblDPK.Size = new System.Drawing.Size(178, 31);
            this.lblDPK.TabIndex = 2;
            this.lblDPK.Text = "Data Perangkat";
            this.lblDPK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDPK2
            // 
            this.pnlDPK2.Controls.Add(this.btnRiwayatPembayaran);
            this.pnlDPK2.Controls.Add(this.btnDasboard);
            this.pnlDPK2.Controls.Add(this.btnPembayaran);
            this.pnlDPK2.Controls.Add(this.btnKerusakan);
            this.pnlDPK2.Controls.Add(this.TxtDPK1);
            this.pnlDPK2.Controls.Add(this.BtnlogoutDPK);
            this.pnlDPK2.Controls.Add(this.btnDataService);
            this.pnlDPK2.Controls.Add(this.btnDataPerangkat);
            this.pnlDPK2.Controls.Add(this.btnDataPelanggan);
            this.pnlDPK2.Location = new System.Drawing.Point(1, 76);
            this.pnlDPK2.Name = "pnlDPK2";
            this.pnlDPK2.Size = new System.Drawing.Size(230, 405);
            this.pnlDPK2.TabIndex = 10;
            // 
            // btnDasboard
            // 
            this.btnDasboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDasboard.Location = new System.Drawing.Point(0, 22);
            this.btnDasboard.Name = "btnDasboard";
            this.btnDasboard.Size = new System.Drawing.Size(230, 43);
            this.btnDasboard.TabIndex = 8;
            this.btnDasboard.Text = "Dasboard";
            this.btnDasboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDasboard.UseVisualStyleBackColor = true;
            this.btnDasboard.Click += new System.EventHandler(this.btnDasboard_Click);
            // 
            // btnPembayaran
            // 
            this.btnPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPembayaran.Location = new System.Drawing.Point(0, 231);
            this.btnPembayaran.Name = "btnPembayaran";
            this.btnPembayaran.Size = new System.Drawing.Size(230, 43);
            this.btnPembayaran.TabIndex = 7;
            this.btnPembayaran.Text = " Pembayaran";
            this.btnPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPembayaran.UseVisualStyleBackColor = true;
            this.btnPembayaran.Click += new System.EventHandler(this.btnPembayaran_Click);
            // 
            // btnKerusakan
            // 
            this.btnKerusakan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKerusakan.Location = new System.Drawing.Point(0, 147);
            this.btnKerusakan.Name = "btnKerusakan";
            this.btnKerusakan.Size = new System.Drawing.Size(230, 43);
            this.btnKerusakan.TabIndex = 6;
            this.btnKerusakan.Text = "Jenis Kerusakan";
            this.btnKerusakan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKerusakan.UseVisualStyleBackColor = true;
            this.btnKerusakan.Click += new System.EventHandler(this.btnKerusakan_Click);
            // 
            // TxtDPK1
            // 
            this.TxtDPK1.Location = new System.Drawing.Point(2, 5);
            this.TxtDPK1.Name = "TxtDPK1";
            this.TxtDPK1.Size = new System.Drawing.Size(227, 22);
            this.TxtDPK1.TabIndex = 5;
            // 
            // BtnlogoutDPK
            // 
            this.BtnlogoutDPK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnlogoutDPK.Location = new System.Drawing.Point(28, 337);
            this.BtnlogoutDPK.Name = "BtnlogoutDPK";
            this.BtnlogoutDPK.Size = new System.Drawing.Size(131, 28);
            this.BtnlogoutDPK.TabIndex = 3;
            this.BtnlogoutDPK.Text = "Logout";
            this.BtnlogoutDPK.UseVisualStyleBackColor = false;
            this.BtnlogoutDPK.Click += new System.EventHandler(this.BtnlogoutDPK_Click);
            // 
            // btnDataService
            // 
            this.btnDataService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataService.Location = new System.Drawing.Point(0, 189);
            this.btnDataService.Name = "btnDataService";
            this.btnDataService.Size = new System.Drawing.Size(230, 43);
            this.btnDataService.TabIndex = 2;
            this.btnDataService.Text = "Data Service";
            this.btnDataService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataService.UseVisualStyleBackColor = true;
            this.btnDataService.Click += new System.EventHandler(this.btnDataService_Click);
            // 
            // btnDataPerangkat
            // 
            this.btnDataPerangkat.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDataPerangkat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataPerangkat.Location = new System.Drawing.Point(0, 105);
            this.btnDataPerangkat.Name = "btnDataPerangkat";
            this.btnDataPerangkat.Size = new System.Drawing.Size(230, 43);
            this.btnDataPerangkat.TabIndex = 1;
            this.btnDataPerangkat.Text = "Data Perangkat";
            this.btnDataPerangkat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataPerangkat.UseVisualStyleBackColor = false;
            this.btnDataPerangkat.Click += new System.EventHandler(this.btnDataPerangkat_Click);
            // 
            // btnDataPelanggan
            // 
            this.btnDataPelanggan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataPelanggan.Location = new System.Drawing.Point(0, 64);
            this.btnDataPelanggan.Name = "btnDataPelanggan";
            this.btnDataPelanggan.Size = new System.Drawing.Size(230, 43);
            this.btnDataPelanggan.TabIndex = 0;
            this.btnDataPelanggan.Text = "Data Pelanggan";
            this.btnDataPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataPelanggan.UseVisualStyleBackColor = true;
            this.btnDataPelanggan.Click += new System.EventHandler(this.btnDataPelanggan_Click);
            // 
            // pnlDPK3
            // 
            this.pnlDPK3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlDPK3.Controls.Add(this.lvwPerangkat);
            this.pnlDPK3.Location = new System.Drawing.Point(251, 92);
            this.pnlDPK3.Name = "pnlDPK3";
            this.pnlDPK3.Size = new System.Drawing.Size(610, 360);
            this.pnlDPK3.TabIndex = 12;
            // 
            // lvwPerangkat
            // 
            this.lvwPerangkat.HideSelection = false;
            this.lvwPerangkat.Location = new System.Drawing.Point(3, 5);
            this.lvwPerangkat.Name = "lvwPerangkat";
            this.lvwPerangkat.Size = new System.Drawing.Size(606, 354);
            this.lvwPerangkat.TabIndex = 0;
            this.lvwPerangkat.UseCompatibleStateImageBehavior = false;
            // 
            // btnRiwayatPembayaran
            // 
            this.btnRiwayatPembayaran.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRiwayatPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRiwayatPembayaran.Location = new System.Drawing.Point(-1, 271);
            this.btnRiwayatPembayaran.Name = "btnRiwayatPembayaran";
            this.btnRiwayatPembayaran.Size = new System.Drawing.Size(230, 43);
            this.btnRiwayatPembayaran.TabIndex = 11;
            this.btnRiwayatPembayaran.Text = "Riwayat Pembayaran";
            this.btnRiwayatPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRiwayatPembayaran.UseVisualStyleBackColor = false;
            this.btnRiwayatPembayaran.Click += new System.EventHandler(this.btnRiwayatPembayaran_Click_1);
            // 
            // Data_Perangkat_Karyawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 481);
            this.Controls.Add(this.pnlDPK3);
            this.Controls.Add(this.pnlDPK1);
            this.Controls.Add(this.pnlDPK2);
            this.Name = "Data_Perangkat_Karyawan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data_Perangkat_KaryawanForm1";
            this.pnlDPK1.ResumeLayout(false);
            this.pnlDPK1.PerformLayout();
            this.pnlDPK2.ResumeLayout(false);
            this.pnlDPK2.PerformLayout();
            this.pnlDPK3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDPK1;
        private System.Windows.Forms.Label lblDPK;
        private System.Windows.Forms.Panel pnlDPK2;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnKerusakan;
        private System.Windows.Forms.TextBox TxtDPK1;
        private System.Windows.Forms.Button BtnlogoutDPK;
        private System.Windows.Forms.Button btnDataService;
        private System.Windows.Forms.Button btnDataPerangkat;
        private System.Windows.Forms.Button btnDataPelanggan;
        private System.Windows.Forms.Panel pnlDPK3;
        private System.Windows.Forms.ListView lvwPerangkat;
        private System.Windows.Forms.Button btnDasboard;
        private System.Windows.Forms.Button btnRiwayatPembayaran;
    }
}