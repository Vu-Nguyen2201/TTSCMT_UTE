namespace QuanLyTTSCMT.Model
{
    partial class FrmXacNhanTraMay
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tùyChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblIdMay = new System.Windows.Forms.Label();
            this.txtIdMayNhan = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbTraMay = new System.Windows.Forms.CheckBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tùyChọnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tùyChọnToolStripMenuItem
            // 
            this.tùyChọnToolStripMenuItem.Name = "tùyChọnToolStripMenuItem";
            this.tùyChọnToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.tùyChọnToolStripMenuItem.Text = "Tùy chọn";
            // 
            // lblIdMay
            // 
            this.lblIdMay.AutoSize = true;
            this.lblIdMay.Location = new System.Drawing.Point(25, 43);
            this.lblIdMay.Name = "lblIdMay";
            this.lblIdMay.Size = new System.Drawing.Size(100, 19);
            this.lblIdMay.TabIndex = 1;
            this.lblIdMay.Text = "Nhập Id máy:";
            // 
            // txtIdMayNhan
            // 
            this.txtIdMayNhan.Location = new System.Drawing.Point(172, 37);
            this.txtIdMayNhan.Name = "txtIdMayNhan";
            this.txtIdMayNhan.Size = new System.Drawing.Size(223, 26);
            this.txtIdMayNhan.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(807, 41);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(112, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(890, 142);
            this.dataGridView1.TabIndex = 4;
            // 
            // cbTraMay
            // 
            this.cbTraMay.AutoSize = true;
            this.cbTraMay.Location = new System.Drawing.Point(29, 300);
            this.cbTraMay.Name = "cbTraMay";
            this.cbTraMay.Size = new System.Drawing.Size(165, 23);
            this.cbTraMay.TabIndex = 5;
            this.cbTraMay.Text = "Xác nhận đã trả máy";
            this.cbTraMay.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(844, 299);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // FrmXacNhanTraMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 366);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cbTraMay);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtIdMayNhan);
            this.Controls.Add(this.lblIdMay);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmXacNhanTraMay";
            this.Text = "FrmXacNhanTraMay";
            this.Load += new System.EventHandler(this.FrmXacNhanTraMay_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tùyChọnToolStripMenuItem;
        private System.Windows.Forms.Label lblIdMay;
        private System.Windows.Forms.TextBox txtIdMayNhan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cbTraMay;
        private System.Windows.Forms.Button btnLuu;
    }
}