namespace AplikasiService.View
{
    partial class Dashboard_Pelanggan
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
            this.pnldshP1 = new System.Windows.Forms.Panel();
            this.lbldsh = new System.Windows.Forms.Label();
            this.pnldshP2 = new System.Windows.Forms.Panel();
            this.lvwDashboard = new System.Windows.Forms.ListView();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnPerangkat = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.pnldshP3 = new System.Windows.Forms.Panel();
            this.lblNama = new System.Windows.Forms.Label();
            this.pnldshP1.SuspendLayout();
            this.pnldshP2.SuspendLayout();
            this.pnldshP3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnldshP1
            // 
            this.pnldshP1.BackColor = System.Drawing.Color.White;
            this.pnldshP1.Controls.Add(this.lbldsh);
            this.pnldshP1.Location = new System.Drawing.Point(1, 1);
            this.pnldshP1.Name = "pnldshP1";
            this.pnldshP1.Size = new System.Drawing.Size(1235, 65);
            this.pnldshP1.TabIndex = 10;
            // 
            // lbldsh
            // 
            this.lbldsh.AutoSize = true;
            this.lbldsh.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldsh.Location = new System.Drawing.Point(634, 15);
            this.lbldsh.Name = "lbldsh";
            this.lbldsh.Size = new System.Drawing.Size(116, 31);
            this.lbldsh.TabIndex = 2;
            this.lbldsh.Text = "Dasboard";
            this.lbldsh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnldshP2
            // 
            this.pnldshP2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnldshP2.Controls.Add(this.lvwDashboard);
            this.pnldshP2.Location = new System.Drawing.Point(294, 105);
            this.pnldshP2.Name = "pnldshP2";
            this.pnldshP2.Size = new System.Drawing.Size(644, 341);
            this.pnldshP2.TabIndex = 11;
            // 
            // lvwDashboard
            // 
            this.lvwDashboard.HideSelection = false;
            this.lvwDashboard.Location = new System.Drawing.Point(20, 21);
            this.lvwDashboard.Name = "lvwDashboard";
            this.lvwDashboard.Size = new System.Drawing.Size(606, 302);
            this.lvwDashboard.TabIndex = 0;
            this.lvwDashboard.UseCompatibleStateImageBehavior = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Location = new System.Drawing.Point(0, 42);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(230, 43);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnPerangkat
            // 
            this.btnPerangkat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerangkat.Location = new System.Drawing.Point(0, 83);
            this.btnPerangkat.Name = "btnPerangkat";
            this.btnPerangkat.Size = new System.Drawing.Size(230, 43);
            this.btnPerangkat.TabIndex = 1;
            this.btnPerangkat.Text = "Data Perangkat";
            this.btnPerangkat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerangkat.UseVisualStyleBackColor = true;
            this.btnPerangkat.Click += new System.EventHandler(this.btnPerangkat_Click);
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
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogOut.Location = new System.Drawing.Point(28, 337);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(131, 28);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click_1);
            // 
            // pnldshP3
            // 
            this.pnldshP3.Controls.Add(this.lblNama);
            this.pnldshP3.Controls.Add(this.btnLogOut);
            this.pnldshP3.Controls.Add(this.btnPembayaran);
            this.pnldshP3.Controls.Add(this.btnPerangkat);
            this.pnldshP3.Controls.Add(this.btnDashboard);
            this.pnldshP3.Location = new System.Drawing.Point(1, 72);
            this.pnldshP3.Name = "pnldshP3";
            this.pnldshP3.Size = new System.Drawing.Size(230, 405);
            this.pnldshP3.TabIndex = 9;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(11, 10);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(82, 16);
            this.lblNama.TabIndex = 0;
            this.lblNama.Text = "Pelanggan : ";
            // 
            // Dashboard_Pelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 477);
            this.Controls.Add(this.pnldshP3);
            this.Controls.Add(this.pnldshP1);
            this.Controls.Add(this.pnldshP2);
            this.Name = "Dashboard_Pelanggan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard_Pelanggan";
            this.pnldshP1.ResumeLayout(false);
            this.pnldshP1.PerformLayout();
            this.pnldshP2.ResumeLayout(false);
            this.pnldshP3.ResumeLayout(false);
            this.pnldshP3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnldshP1;
        private System.Windows.Forms.Label lbldsh;
        private System.Windows.Forms.Panel pnldshP2;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnPerangkat;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel pnldshP3;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.ListView lvwDashboard;
    }
}