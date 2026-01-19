namespace AplikasiService.View
{
    partial class Data_Service_Karyawan
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
            this.pnlDSK1 = new System.Windows.Forms.Panel();
            this.lblDSK = new System.Windows.Forms.Label();
            this.pnlDSK3 = new System.Windows.Forms.Panel();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnKerusakan = new System.Windows.Forms.Button();
            this.TxtDSK1 = new System.Windows.Forms.TextBox();
            this.BtnlogoutDSK = new System.Windows.Forms.Button();
            this.btnDataService = new System.Windows.Forms.Button();
            this.BtnDataPerangkat = new System.Windows.Forms.Button();
            this.BtnDataPelanggan = new System.Windows.Forms.Button();
            this.pnlDSK2 = new System.Windows.Forms.Panel();
            this.pnlDSK1.SuspendLayout();
            this.pnlDSK3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDSK1
            // 
            this.pnlDSK1.BackColor = System.Drawing.Color.White;
            this.pnlDSK1.Controls.Add(this.lblDSK);
            this.pnlDSK1.Location = new System.Drawing.Point(2, 3);
            this.pnlDSK1.Name = "pnlDSK1";
            this.pnlDSK1.Size = new System.Drawing.Size(882, 65);
            this.pnlDSK1.TabIndex = 13;
            // 
            // lblDSK
            // 
            this.lblDSK.AutoSize = true;
            this.lblDSK.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSK.Location = new System.Drawing.Point(593, 17);
            this.lblDSK.Name = "lblDSK";
            this.lblDSK.Size = new System.Drawing.Size(161, 31);
            this.lblDSK.TabIndex = 2;
            this.lblDSK.Text = "Detail Service";
            this.lblDSK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDSK3
            // 
            this.pnlDSK3.Controls.Add(this.btnPembayaran);
            this.pnlDSK3.Controls.Add(this.btnKerusakan);
            this.pnlDSK3.Controls.Add(this.TxtDSK1);
            this.pnlDSK3.Controls.Add(this.BtnlogoutDSK);
            this.pnlDSK3.Controls.Add(this.btnDataService);
            this.pnlDSK3.Controls.Add(this.BtnDataPerangkat);
            this.pnlDSK3.Controls.Add(this.BtnDataPelanggan);
            this.pnlDSK3.Location = new System.Drawing.Point(2, 69);
            this.pnlDSK3.Name = "pnlDSK3";
            this.pnlDSK3.Size = new System.Drawing.Size(230, 405);
            this.pnlDSK3.TabIndex = 12;
            // 
            // btnPembayaran
            // 
            this.btnPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPembayaran.Location = new System.Drawing.Point(0, 209);
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
            this.btnKerusakan.Location = new System.Drawing.Point(0, 166);
            this.btnKerusakan.Name = "btnKerusakan";
            this.btnKerusakan.Size = new System.Drawing.Size(230, 43);
            this.btnKerusakan.TabIndex = 6;
            this.btnKerusakan.Text = "Jenis Kerusakan";
            this.btnKerusakan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKerusakan.UseVisualStyleBackColor = true;
            this.btnKerusakan.Click += new System.EventHandler(this.btnKerusakan_Click);
            // 
            // TxtDSK1
            // 
            this.TxtDSK1.Location = new System.Drawing.Point(2, 5);
            this.TxtDSK1.Name = "TxtDSK1";
            this.TxtDSK1.Size = new System.Drawing.Size(227, 22);
            this.TxtDSK1.TabIndex = 5;
            // 
            // BtnlogoutDSK
            // 
            this.BtnlogoutDSK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnlogoutDSK.Location = new System.Drawing.Point(28, 337);
            this.BtnlogoutDSK.Name = "BtnlogoutDSK";
            this.BtnlogoutDSK.Size = new System.Drawing.Size(131, 28);
            this.BtnlogoutDSK.TabIndex = 3;
            this.BtnlogoutDSK.Text = "Logout";
            this.BtnlogoutDSK.UseVisualStyleBackColor = false;
            this.BtnlogoutDSK.Click += new System.EventHandler(this.BtnlogoutDSK_Click);
            // 
            // btnDataService
            // 
            this.btnDataService.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDataService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataService.Location = new System.Drawing.Point(0, 123);
            this.btnDataService.Name = "btnDataService";
            this.btnDataService.Size = new System.Drawing.Size(230, 43);
            this.btnDataService.TabIndex = 2;
            this.btnDataService.Text = "Data Service";
            this.btnDataService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataService.UseVisualStyleBackColor = false;
            this.btnDataService.Click += new System.EventHandler(this.btnDataService_Click);
            // 
            // BtnDataPerangkat
            // 
            this.BtnDataPerangkat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDataPerangkat.Location = new System.Drawing.Point(0, 83);
            this.BtnDataPerangkat.Name = "BtnDataPerangkat";
            this.BtnDataPerangkat.Size = new System.Drawing.Size(230, 43);
            this.BtnDataPerangkat.TabIndex = 1;
            this.BtnDataPerangkat.Text = "Data Perangkat";
            this.BtnDataPerangkat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDataPerangkat.UseVisualStyleBackColor = true;
            this.BtnDataPerangkat.Click += new System.EventHandler(this.btnDataPerangkat_Click);
            // 
            // BtnDataPelanggan
            // 
            this.BtnDataPelanggan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDataPelanggan.Location = new System.Drawing.Point(0, 42);
            this.BtnDataPelanggan.Name = "BtnDataPelanggan";
            this.BtnDataPelanggan.Size = new System.Drawing.Size(230, 43);
            this.BtnDataPelanggan.TabIndex = 0;
            this.BtnDataPelanggan.Text = "Data Pelanggan";
            this.BtnDataPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDataPelanggan.UseVisualStyleBackColor = true;
            this.BtnDataPelanggan.Click += new System.EventHandler(this.btnDataPelanggan_Click);
            // 
            // pnlDSK2
            // 
            this.pnlDSK2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlDSK2.Location = new System.Drawing.Point(278, 110);
            this.pnlDSK2.Name = "pnlDSK2";
            this.pnlDSK2.Size = new System.Drawing.Size(569, 323);
            this.pnlDSK2.TabIndex = 14;
            // 
            // Data_Service_Karyawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 471);
            this.Controls.Add(this.pnlDSK2);
            this.Controls.Add(this.pnlDSK1);
            this.Controls.Add(this.pnlDSK3);
            this.Name = "Data_Service_Karyawan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data_Service_Karyawan";
            this.pnlDSK1.ResumeLayout(false);
            this.pnlDSK1.PerformLayout();
            this.pnlDSK3.ResumeLayout(false);
            this.pnlDSK3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDSK1;
        private System.Windows.Forms.Label lblDSK;
        private System.Windows.Forms.Panel pnlDSK3;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnKerusakan;
        private System.Windows.Forms.TextBox TxtDSK1;
        private System.Windows.Forms.Button BtnlogoutDSK;
        private System.Windows.Forms.Button btnDataService;
        private System.Windows.Forms.Button BtnDataPerangkat;
        private System.Windows.Forms.Button BtnDataPelanggan;
        private System.Windows.Forms.Panel pnlDSK2;
    }
}