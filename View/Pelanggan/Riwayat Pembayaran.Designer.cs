namespace AplikasiService.View
{
    partial class Riwayat_Pembayaran
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
            this.pnlRP3 = new System.Windows.Forms.Panel();
            this.lblNama = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnDataPerangkat = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlRP1 = new System.Windows.Forms.Panel();
            this.lblRP1 = new System.Windows.Forms.Label();
            this.pnlRP2 = new System.Windows.Forms.Panel();
            this.lvwRiwayat = new System.Windows.Forms.ListView();
            this.pnlRP3.SuspendLayout();
            this.pnlRP1.SuspendLayout();
            this.pnlRP2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRP3
            // 
            this.pnlRP3.BackColor = System.Drawing.Color.White;
            this.pnlRP3.Controls.Add(this.lblNama);
            this.pnlRP3.Controls.Add(this.btnLogOut);
            this.pnlRP3.Controls.Add(this.btnPembayaran);
            this.pnlRP3.Controls.Add(this.btnDataPerangkat);
            this.pnlRP3.Controls.Add(this.btnDashboard);
            this.pnlRP3.Location = new System.Drawing.Point(3, 74);
            this.pnlRP3.Name = "pnlRP3";
            this.pnlRP3.Size = new System.Drawing.Size(241, 397);
            this.pnlRP3.TabIndex = 5;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(9, 12);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(82, 16);
            this.lblNama.TabIndex = 8;
            this.lblNama.Text = "Pelanggan : ";
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
            this.btnPembayaran.BackColor = System.Drawing.Color.Gray;
            this.btnPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPembayaran.Location = new System.Drawing.Point(0, 123);
            this.btnPembayaran.Name = "btnPembayaran";
            this.btnPembayaran.Size = new System.Drawing.Size(241, 43);
            this.btnPembayaran.TabIndex = 2;
            this.btnPembayaran.Text = "Pembayaran";
            this.btnPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPembayaran.UseVisualStyleBackColor = false;
            this.btnPembayaran.Click += new System.EventHandler(this.btnPembayaran_Click);
            // 
            // btnDataPerangkat
            // 
            this.btnDataPerangkat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataPerangkat.Location = new System.Drawing.Point(0, 83);
            this.btnDataPerangkat.Name = "btnDataPerangkat";
            this.btnDataPerangkat.Size = new System.Drawing.Size(241, 43);
            this.btnDataPerangkat.TabIndex = 1;
            this.btnDataPerangkat.Text = "Data Perangkat";
            this.btnDataPerangkat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDataPerangkat.UseVisualStyleBackColor = true;
            this.btnDataPerangkat.Click += new System.EventHandler(this.btnDataPerangkat_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Location = new System.Drawing.Point(0, 40);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(241, 43);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlRP1
            // 
            this.pnlRP1.BackColor = System.Drawing.Color.White;
            this.pnlRP1.Controls.Add(this.lblRP1);
            this.pnlRP1.Location = new System.Drawing.Point(3, 3);
            this.pnlRP1.Name = "pnlRP1";
            this.pnlRP1.Size = new System.Drawing.Size(882, 65);
            this.pnlRP1.TabIndex = 6;
            // 
            // lblRP1
            // 
            this.lblRP1.AutoSize = true;
            this.lblRP1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRP1.Location = new System.Drawing.Point(332, 15);
            this.lblRP1.Name = "lblRP1";
            this.lblRP1.Size = new System.Drawing.Size(236, 31);
            this.lblRP1.TabIndex = 2;
            this.lblRP1.Text = "Riwayat Pembayaran";
            this.lblRP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRP2
            // 
            this.pnlRP2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlRP2.Controls.Add(this.lvwRiwayat);
            this.pnlRP2.Location = new System.Drawing.Point(283, 114);
            this.pnlRP2.Name = "pnlRP2";
            this.pnlRP2.Size = new System.Drawing.Size(590, 332);
            this.pnlRP2.TabIndex = 7;
            // 
            // lvwRiwayat
            // 
            this.lvwRiwayat.HideSelection = false;
            this.lvwRiwayat.Location = new System.Drawing.Point(3, 3);
            this.lvwRiwayat.Name = "lvwRiwayat";
            this.lvwRiwayat.Size = new System.Drawing.Size(584, 326);
            this.lvwRiwayat.TabIndex = 0;
            this.lvwRiwayat.UseCompatibleStateImageBehavior = false;
            // 
            // Riwayat_Pembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 502);
            this.Controls.Add(this.pnlRP2);
            this.Controls.Add(this.pnlRP1);
            this.Controls.Add(this.pnlRP3);
            this.Name = "Riwayat_Pembayaran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riwayat_Pembayaran";
            this.pnlRP3.ResumeLayout(false);
            this.pnlRP3.PerformLayout();
            this.pnlRP1.ResumeLayout(false);
            this.pnlRP1.PerformLayout();
            this.pnlRP2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRP3;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnDataPerangkat;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel pnlRP1;
        private System.Windows.Forms.Label lblRP1;
        private System.Windows.Forms.Panel pnlRP2;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.ListView lvwRiwayat;
    }
}