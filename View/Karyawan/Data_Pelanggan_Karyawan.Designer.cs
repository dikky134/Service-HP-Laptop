namespace AplikasiService.View
{
    partial class Data_Pelanggan_Karyawan
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
            this.pnlDP1 = new System.Windows.Forms.Panel();
            this.lblDPP = new System.Windows.Forms.Label();
            this.pnlDP2 = new System.Windows.Forms.Panel();
            this.btnRiwayatPembayaran = new System.Windows.Forms.Button();
            this.btnDasboard = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnKerusakan = new System.Windows.Forms.Button();
            this.TxtDPP = new System.Windows.Forms.TextBox();
            this.BtnlogoutPP1 = new System.Windows.Forms.Button();
            this.btnDataService = new System.Windows.Forms.Button();
            this.btnDataPerangkat = new System.Windows.Forms.Button();
            this.btnDataPelanggan = new System.Windows.Forms.Button();
            this.pnlDP4 = new System.Windows.Forms.Panel();
            this.lvwDataPelanggan = new System.Windows.Forms.ListView();
            this.pnlDP1.SuspendLayout();
            this.pnlDP2.SuspendLayout();
            this.pnlDP4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDP1
            // 
            this.pnlDP1.BackColor = System.Drawing.Color.White;
            this.pnlDP1.Controls.Add(this.lblDPP);
            this.pnlDP1.Location = new System.Drawing.Point(1, 2);
            this.pnlDP1.Name = "pnlDP1";
            this.pnlDP1.Size = new System.Drawing.Size(882, 65);
            this.pnlDP1.TabIndex = 9;
            // 
            // lblDPP
            // 
            this.lblDPP.AutoSize = true;
            this.lblDPP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPP.Location = new System.Drawing.Point(634, 15);
            this.lblDPP.Name = "lblDPP";
            this.lblDPP.Size = new System.Drawing.Size(182, 31);
            this.lblDPP.TabIndex = 2;
            this.lblDPP.Text = "Data Pelanggan";
            this.lblDPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDP2
            // 
            this.pnlDP2.Controls.Add(this.btnRiwayatPembayaran);
            this.pnlDP2.Controls.Add(this.btnDasboard);
            this.pnlDP2.Controls.Add(this.btnPembayaran);
            this.pnlDP2.Controls.Add(this.btnKerusakan);
            this.pnlDP2.Controls.Add(this.TxtDPP);
            this.pnlDP2.Controls.Add(this.BtnlogoutPP1);
            this.pnlDP2.Controls.Add(this.btnDataService);
            this.pnlDP2.Controls.Add(this.btnDataPerangkat);
            this.pnlDP2.Controls.Add(this.btnDataPelanggan);
            this.pnlDP2.Location = new System.Drawing.Point(1, 68);
            this.pnlDP2.Name = "pnlDP2";
            this.pnlDP2.Size = new System.Drawing.Size(230, 405);
            this.pnlDP2.TabIndex = 8;
            // 
            // btnRiwayatPembayaran
            // 
            this.btnRiwayatPembayaran.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRiwayatPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRiwayatPembayaran.Location = new System.Drawing.Point(0, 266);
            this.btnRiwayatPembayaran.Name = "btnRiwayatPembayaran";
            this.btnRiwayatPembayaran.Size = new System.Drawing.Size(230, 43);
            this.btnRiwayatPembayaran.TabIndex = 11;
            this.btnRiwayatPembayaran.Text = "Riwayat Pembayaran";
            this.btnRiwayatPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRiwayatPembayaran.UseVisualStyleBackColor = false;
            this.btnRiwayatPembayaran.Click += new System.EventHandler(this.btnRiwayatPembayaran_Click_1);
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
            this.btnPembayaran.Location = new System.Drawing.Point(0, 224);
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
            this.btnKerusakan.Location = new System.Drawing.Point(0, 141);
            this.btnKerusakan.Name = "btnKerusakan";
            this.btnKerusakan.Size = new System.Drawing.Size(230, 43);
            this.btnKerusakan.TabIndex = 6;
            this.btnKerusakan.Text = "Jenis Kerusakan";
            this.btnKerusakan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKerusakan.UseVisualStyleBackColor = true;
            this.btnKerusakan.Click += new System.EventHandler(this.btnKerusakan_Click);
            // 
            // TxtDPP
            // 
            this.TxtDPP.Location = new System.Drawing.Point(2, 5);
            this.TxtDPP.Name = "TxtDPP";
            this.TxtDPP.Size = new System.Drawing.Size(227, 22);
            this.TxtDPP.TabIndex = 5;
            // 
            // BtnlogoutPP1
            // 
            this.BtnlogoutPP1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnlogoutPP1.Location = new System.Drawing.Point(28, 337);
            this.BtnlogoutPP1.Name = "BtnlogoutPP1";
            this.BtnlogoutPP1.Size = new System.Drawing.Size(131, 28);
            this.BtnlogoutPP1.TabIndex = 3;
            this.BtnlogoutPP1.Text = "Logout";
            this.BtnlogoutPP1.UseVisualStyleBackColor = false;
            this.BtnlogoutPP1.Click += new System.EventHandler(this.BtnlogoutPP1_Click);
            // 
            // btnDataService
            // 
            this.btnDataService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataService.Location = new System.Drawing.Point(0, 183);
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
            this.btnDataPerangkat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataPerangkat.Location = new System.Drawing.Point(0, 101);
            this.btnDataPerangkat.Name = "btnDataPerangkat";
            this.btnDataPerangkat.Size = new System.Drawing.Size(230, 43);
            this.btnDataPerangkat.TabIndex = 1;
            this.btnDataPerangkat.Text = "Data Perangkat";
            this.btnDataPerangkat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataPerangkat.UseVisualStyleBackColor = true;
            this.btnDataPerangkat.Click += new System.EventHandler(this.btnDataPerangkat_Click);
            // 
            // btnDataPelanggan
            // 
            this.btnDataPelanggan.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDataPelanggan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataPelanggan.Location = new System.Drawing.Point(0, 60);
            this.btnDataPelanggan.Name = "btnDataPelanggan";
            this.btnDataPelanggan.Size = new System.Drawing.Size(230, 43);
            this.btnDataPelanggan.TabIndex = 0;
            this.btnDataPelanggan.Text = "Data Pelanggan";
            this.btnDataPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataPelanggan.UseVisualStyleBackColor = false;
            // 
            // pnlDP4
            // 
            this.pnlDP4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlDP4.Controls.Add(this.lvwDataPelanggan);
            this.pnlDP4.Location = new System.Drawing.Point(279, 90);
            this.pnlDP4.Name = "pnlDP4";
            this.pnlDP4.Size = new System.Drawing.Size(538, 383);
            this.pnlDP4.TabIndex = 12;
            // 
            // lvwDataPelanggan
            // 
            this.lvwDataPelanggan.HideSelection = false;
            this.lvwDataPelanggan.Location = new System.Drawing.Point(3, 3);
            this.lvwDataPelanggan.Name = "lvwDataPelanggan";
            this.lvwDataPelanggan.Size = new System.Drawing.Size(532, 377);
            this.lvwDataPelanggan.TabIndex = 0;
            this.lvwDataPelanggan.UseCompatibleStateImageBehavior = false;
            // 
            // Data_Pelanggan_Karyawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 495);
            this.Controls.Add(this.pnlDP4);
            this.Controls.Add(this.pnlDP1);
            this.Controls.Add(this.pnlDP2);
            this.Name = "Data_Pelanggan_Karyawan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data_Pelanggan_Karyawan";
            this.pnlDP1.ResumeLayout(false);
            this.pnlDP1.PerformLayout();
            this.pnlDP2.ResumeLayout(false);
            this.pnlDP2.PerformLayout();
            this.pnlDP4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDP1;
        private System.Windows.Forms.Label lblDPP;
        private System.Windows.Forms.Panel pnlDP2;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnKerusakan;
        private System.Windows.Forms.TextBox TxtDPP;
        private System.Windows.Forms.Button BtnlogoutPP1;
        private System.Windows.Forms.Button btnDataService;
        private System.Windows.Forms.Button btnDataPerangkat;
        private System.Windows.Forms.Button btnDataPelanggan;
        private System.Windows.Forms.Panel pnlDP4;
        private System.Windows.Forms.ListView lvwDataPelanggan;
        private System.Windows.Forms.Button btnDasboard;
        private System.Windows.Forms.Button btnRiwayatPembayaran;
    }
}