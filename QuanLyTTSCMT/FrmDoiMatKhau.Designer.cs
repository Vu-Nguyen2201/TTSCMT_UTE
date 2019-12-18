namespace QuanLyTTSCMT
{
    partial class FrmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoiMatKhau));
            this.lblMatKhauCu = new System.Windows.Forms.Label();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtXacNhanMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblXacNhanMatKhauMoi = new System.Windows.Forms.Label();
            this.btnXacNhanDoiMatKhau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMatKhauCu
            // 
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhauCu.Location = new System.Drawing.Point(76, 17);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Size = new System.Drawing.Size(102, 21);
            this.lblMatKhauCu.TabIndex = 0;
            this.lblMatKhauCu.Text = "Mật khẩu cũ";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauCu.Location = new System.Drawing.Point(238, 14);
            this.txtMatKhauCu.MaxLength = 30;
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(192, 29);
            this.txtMatKhauCu.TabIndex = 3;
            this.txtMatKhauCu.Click += new System.EventHandler(this.txtMatKhauCu_Click);
            this.txtMatKhauCu.TextChanged += new System.EventHandler(this.txtMatKhauCu_TextChanged);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauMoi.Location = new System.Drawing.Point(238, 62);
            this.txtMatKhauMoi.MaxLength = 30;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(192, 29);
            this.txtMatKhauMoi.TabIndex = 5;
            this.txtMatKhauMoi.Click += new System.EventHandler(this.txtMatKhauMoi_Click);
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhauMoi.Location = new System.Drawing.Point(70, 65);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(112, 21);
            this.lblMatKhauMoi.TabIndex = 4;
            this.lblMatKhauMoi.Text = "Mật khẩu mới";
            // 
            // txtXacNhanMatKhauMoi
            // 
            this.txtXacNhanMatKhauMoi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhanMatKhauMoi.Location = new System.Drawing.Point(238, 110);
            this.txtXacNhanMatKhauMoi.MaxLength = 30;
            this.txtXacNhanMatKhauMoi.Name = "txtXacNhanMatKhauMoi";
            this.txtXacNhanMatKhauMoi.Size = new System.Drawing.Size(192, 29);
            this.txtXacNhanMatKhauMoi.TabIndex = 7;
            this.txtXacNhanMatKhauMoi.Click += new System.EventHandler(this.txtXacNhanMatKhauMoi_Click);
            // 
            // lblXacNhanMatKhauMoi
            // 
            this.lblXacNhanMatKhauMoi.AutoSize = true;
            this.lblXacNhanMatKhauMoi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXacNhanMatKhauMoi.Location = new System.Drawing.Point(39, 113);
            this.lblXacNhanMatKhauMoi.Name = "lblXacNhanMatKhauMoi";
            this.lblXacNhanMatKhauMoi.Size = new System.Drawing.Size(185, 21);
            this.lblXacNhanMatKhauMoi.TabIndex = 6;
            this.lblXacNhanMatKhauMoi.Text = "Xác nhận mật khẩu mới";
            // 
            // btnXacNhanDoiMatKhau
            // 
            this.btnXacNhanDoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanDoiMatKhau.Location = new System.Drawing.Point(172, 158);
            this.btnXacNhanDoiMatKhau.Name = "btnXacNhanDoiMatKhau";
            this.btnXacNhanDoiMatKhau.Size = new System.Drawing.Size(137, 56);
            this.btnXacNhanDoiMatKhau.TabIndex = 8;
            this.btnXacNhanDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnXacNhanDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnXacNhanDoiMatKhau.Click += new System.EventHandler(this.btnXacNhanDoiMatKhau_Click);
            // 
            // FrmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 219);
            this.Controls.Add(this.btnXacNhanDoiMatKhau);
            this.Controls.Add(this.txtXacNhanMatKhauMoi);
            this.Controls.Add(this.lblXacNhanMatKhauMoi);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.lblMatKhauMoi);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.lblMatKhauCu);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDoiMatKhau";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmDoiMatKhau";
            this.Load += new System.EventHandler(this.FrmDoiMatKhau_Load);
            this.Enter += new System.EventHandler(this.FrmDoiMatKhau_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtXacNhanMatKhauMoi;
        private System.Windows.Forms.Label lblXacNhanMatKhauMoi;
        private System.Windows.Forms.Button btnXacNhanDoiMatKhau;
    }
}