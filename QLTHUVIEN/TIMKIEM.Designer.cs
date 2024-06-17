namespace QLTHUVIEN
{
    partial class TIMKIEM
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtNhapTenOrMa = new System.Windows.Forms.TextBox();
            this.rdbTenSach = new System.Windows.Forms.RadioButton();
            this.rdbMaSach = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoa = new System.Windows.Forms.Button();
            this.btnTim1 = new System.Windows.Forms.Button();
            this.txtNhapMAOrTenDG = new System.Windows.Forms.TextBox();
            this.rdbTenDG = new System.Windows.Forms.RadioButton();
            this.rdbMaDG = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(827, 488);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvSach);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(819, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tìm kiếm sách";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(338, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm Sách";
            // 
            // dgvSach
            // 
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(6, 228);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.Size = new System.Drawing.Size(807, 201);
            this.dgvSach.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.txtNhapTenOrMa);
            this.groupBox1.Controls.Add(this.rdbTenSach);
            this.groupBox1.Controls.Add(this.rdbMaSach);
            this.groupBox1.Location = new System.Drawing.Point(149, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm sách";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(380, 72);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 32);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(380, 22);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 36);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtNhapTenOrMa
            // 
            this.txtNhapTenOrMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapTenOrMa.Location = new System.Drawing.Point(177, 53);
            this.txtNhapTenOrMa.Name = "txtNhapTenOrMa";
            this.txtNhapTenOrMa.Size = new System.Drawing.Size(164, 24);
            this.txtNhapTenOrMa.TabIndex = 2;
            // 
            // rdbTenSach
            // 
            this.rdbTenSach.AutoSize = true;
            this.rdbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTenSach.Location = new System.Drawing.Point(47, 72);
            this.rdbTenSach.Name = "rdbTenSach";
            this.rdbTenSach.Size = new System.Drawing.Size(101, 24);
            this.rdbTenSach.TabIndex = 1;
            this.rdbTenSach.TabStop = true;
            this.rdbTenSach.Text = "Tên Sách";
            this.rdbTenSach.UseVisualStyleBackColor = true;
            // 
            // rdbMaSach
            // 
            this.rdbMaSach.AutoSize = true;
            this.rdbMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMaSach.Location = new System.Drawing.Point(47, 22);
            this.rdbMaSach.Name = "rdbMaSach";
            this.rdbMaSach.Size = new System.Drawing.Size(96, 24);
            this.rdbMaSach.TabIndex = 0;
            this.rdbMaSach.TabStop = true;
            this.rdbMaSach.Text = "Mã Sách";
            this.rdbMaSach.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDocGia);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(819, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tìm kiếm độc giả";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Location = new System.Drawing.Point(6, 239);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.RowHeadersWidth = 51;
            this.dgvDocGia.RowTemplate.Height = 24;
            this.dgvDocGia.Size = new System.Drawing.Size(807, 214);
            this.dgvDocGia.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoa);
            this.groupBox2.Controls.Add(this.btnTim1);
            this.groupBox2.Controls.Add(this.txtNhapMAOrTenDG);
            this.groupBox2.Controls.Add(this.rdbTenDG);
            this.groupBox2.Controls.Add(this.rdbMaDG);
            this.groupBox2.Location = new System.Drawing.Point(172, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 130);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm độc giả";
            // 
            // btnThoa
            // 
            this.btnThoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoa.Location = new System.Drawing.Point(335, 77);
            this.btnThoa.Name = "btnThoa";
            this.btnThoa.Size = new System.Drawing.Size(75, 37);
            this.btnThoa.TabIndex = 4;
            this.btnThoa.Text = "Thoát";
            this.btnThoa.UseVisualStyleBackColor = true;
            this.btnThoa.Click += new System.EventHandler(this.btnThoa_Click);
            // 
            // btnTim1
            // 
            this.btnTim1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim1.Location = new System.Drawing.Point(335, 21);
            this.btnTim1.Name = "btnTim1";
            this.btnTim1.Size = new System.Drawing.Size(75, 41);
            this.btnTim1.TabIndex = 3;
            this.btnTim1.Text = "Tìm";
            this.btnTim1.UseVisualStyleBackColor = true;
            this.btnTim1.Click += new System.EventHandler(this.btnTim1_Click);
            // 
            // txtNhapMAOrTenDG
            // 
            this.txtNhapMAOrTenDG.Location = new System.Drawing.Point(152, 56);
            this.txtNhapMAOrTenDG.Name = "txtNhapMAOrTenDG";
            this.txtNhapMAOrTenDG.Size = new System.Drawing.Size(170, 22);
            this.txtNhapMAOrTenDG.TabIndex = 2;
            // 
            // rdbTenDG
            // 
            this.rdbTenDG.AutoSize = true;
            this.rdbTenDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTenDG.Location = new System.Drawing.Point(36, 77);
            this.rdbTenDG.Name = "rdbTenDG";
            this.rdbTenDG.Size = new System.Drawing.Size(113, 22);
            this.rdbTenDG.TabIndex = 1;
            this.rdbTenDG.TabStop = true;
            this.rdbTenDG.Text = "Tên Độc Giả";
            this.rdbTenDG.UseVisualStyleBackColor = true;
            // 
            // rdbMaDG
            // 
            this.rdbMaDG.AutoSize = true;
            this.rdbMaDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMaDG.Location = new System.Drawing.Point(36, 34);
            this.rdbMaDG.Name = "rdbMaDG";
            this.rdbMaDG.Size = new System.Drawing.Size(109, 22);
            this.rdbMaDG.TabIndex = 0;
            this.rdbMaDG.TabStop = true;
            this.rdbMaDG.Text = "Mã Độc Giả";
            this.rdbMaDG.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "TÌM ĐỘC GIẢ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(333, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "TÌM KIẾM";
            // 
            // TIMKIEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 576);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "TIMKIEM";
            this.Text = "TIMKIEM";
            this.Load += new System.EventHandler(this.TIMKIEM_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTenSach;
        private System.Windows.Forms.RadioButton rdbMaSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtNhapTenOrMa;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoa;
        private System.Windows.Forms.Button btnTim1;
        private System.Windows.Forms.TextBox txtNhapMAOrTenDG;
        private System.Windows.Forms.RadioButton rdbTenDG;
        private System.Windows.Forms.RadioButton rdbMaDG;
        private System.Windows.Forms.Label label3;
    }
}