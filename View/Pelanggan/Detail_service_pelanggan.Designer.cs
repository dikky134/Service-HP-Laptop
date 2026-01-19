namespace AplikasiService.View
{
    partial class Detail_service_pelanggan
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
            this.pnlSDP2 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnDataPerangkat = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlSDP1 = new System.Windows.Forms.Panel();
            this.lblDSP = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.lvwDetail = new System.Windows.Forms.ListView();
            this.pnlSDP2.SuspendLayout();
            this.pnlSDP1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSDP2
            // 
            this.pnlSDP2.BackColor = System.Drawing.Color.White;
            this.pnlSDP2.Controls.Add(this.lblNama);
            this.pnlSDP2.Controls.Add(this.btnLogOut);
            this.pnlSDP2.Controls.Add(this.btnPembayaran);
            this.pnlSDP2.Controls.Add(this.btnDataPerangkat);
            this.pnlSDP2.Controls.Add(this.btnDashboard);
            this.pnlSDP2.Location = new System.Drawing.Point(0, 61);
            this.pnlSDP2.Name = "pnlSDP2";
            this.pnlSDP2.Size = new System.Drawing.Size(230, 392);
            this.pnlSDP2.TabIndex = 1;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogOut.Location = new System.Drawing.Point(43, 209);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(131, 28);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnPembayaran
            // 
            this.btnPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPembayaran.Location = new System.Drawing.Point(0, 123);
            this.btnPembayaran.Name = "btnPembayaran";
            this.btnPembayaran.Size = new System.Drawing.Size(230, 43);
            this.btnPembayaran.TabIndex = 2;
            this.btnPembayaran.Text = "Pembayaran";
            this.btnPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPembayaran.UseVisualStyleBackColor = true;
            this.btnPembayaran.Click += new System.EventHandler(this.btnPembayaran_Click);
            // 
            // btnDataPerangkat
            // 
            this.btnDataPerangkat.BackColor = System.Drawing.Color.Gray;
            this.btnDataPerangkat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataPerangkat.Location = new System.Drawing.Point(0, 83);
            this.btnDataPerangkat.Name = "btnDataPerangkat";
            this.btnDataPerangkat.Size = new System.Drawing.Size(230, 43);
            this.btnDataPerangkat.TabIndex = 1;
            this.btnDataPerangkat.Text = "Data Perangkat";
            this.btnDataPerangkat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataPerangkat.UseVisualStyleBackColor = false;
            this.btnDataPerangkat.Click += new System.EventHandler(this.btnDataPerangkat_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Location = new System.Drawing.Point(0, 40);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(233, 43);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlSDP1
            // 
            this.pnlSDP1.BackColor = System.Drawing.Color.White;
            this.pnlSDP1.Controls.Add(this.lblDSP);
            this.pnlSDP1.Location = new System.Drawing.Point(0, 2);
            this.pnlSDP1.Name = "pnlSDP1";
            this.pnlSDP1.Size = new System.Drawing.Size(882, 65);
            this.pnlSDP1.TabIndex = 2;
            // 
            // lblDSP
            // 
            this.lblDSP.AutoSize = true;
            this.lblDSP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSP.Location = new System.Drawing.Point(558, 17);
            this.lblDSP.Name = "lblDSP";
            this.lblDSP.Size = new System.Drawing.Size(279, 31);
            this.lblDSP.TabIndex = 2;
            this.lblDSP.Text = "Detail Service Pelanggan";
            this.lblDSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(5, 16);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(82, 16);
            this.lblNama.TabIndex = 5;
            this.lblNama.Text = "Pelanggan : ";
            // 
            // lvwDetail
            // 
            this.lvwDetail.HideSelection = false;
            this.lvwDetail.Location = new System.Drawing.Point(254, 77);
            this.lvwDetail.Name = "lvwDetail";
            this.lvwDetail.Size = new System.Drawing.Size(616, 364);
            this.lvwDetail.TabIndex = 3;
            this.lvwDetail.UseCompatibleStateImageBehavior = false;
            // 
            // Detail_service_pelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.lvwDetail);
            this.Controls.Add(this.pnlSDP1);
            this.Controls.Add(this.pnlSDP2);
            this.Name = "Detail_service_pelanggan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail_service_pelanggan";
            this.pnlSDP2.ResumeLayout(false);
            this.pnlSDP2.PerformLayout();
            this.pnlSDP1.ResumeLayout(false);
            this.pnlSDP1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSDP2;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnDataPerangkat;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlSDP1;
        private System.Windows.Forms.Label lblDSP;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.ListView lvwDetail;
    }
}