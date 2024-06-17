using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Text.RegularExpressions;

namespace QLTHUVIEN
{
    public partial class DangKy : Form
    {
        QLTVDataContext DK = new QLTVDataContext();
        Table<nguoidung> nguoidungs;
        public DangKy()
        {
            InitializeComponent();
        }
        public void loaddata()
        {
            nguoidungs = DK.GetTable<nguoidung>();
            var query = from dN in nguoidungs
                        select dN;
        }
        private void DangKy_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnThoatDK_Click(object sender, EventArgs e)
        {
            DangNhap dN = new DangNhap();
            dN.Show();
            this.Hide();
        }

        public bool CheckAcc (string ac)
        {
            return Regex.IsMatch(ac, "^[a-z0-9]{6,24}$");
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            nguoidung dN = new nguoidung();
            dN.Taikhoan = txtDangkyTK.Text;
            dN.Matkhau = txtDangKyMK.Text;
            dN.Nhaplaimatkhau = txtNhapLaiMK.Text;
            dN.Hoten = txtDKHoTen.Text;
            dN.Quequan = txtQueQuan.Text;
            dN.Gioitinh = rdbNam.Checked == true ? true : false;

            if (!CheckAcc(dN.Taikhoan)) { MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 kí tự và số!"); return; }

            if (!CheckAcc(dN.Matkhau)) { MessageBox.Show("Vui lòng nhập mật khẩu dài 6-24 kí tự và số!"); return; }

            if (dN.Nhaplaimatkhau != dN.Matkhau) { MessageBox.Show("Vui lòng nhập lại mật khẩu chính xác!"); return; }

            nguoidung n = DK.nguoidungs.SingleOrDefault(t => t.Taikhoan == dN.Taikhoan );
            if (n != null)
            {
                MessageBox.Show("Tên đăng nhập đã được sữ dụng!"); return;
            }
            if (dN.Hoten.Trim() == "") { MessageBox.Show("Vui lòng nhập họ tên"); return; }
            else if (dN.Quequan.Trim() == "") { MessageBox.Show("Vui lòng nhập quê quán"); return; }
            else if (rdbNam.Checked == false && rdbNu.Checked == false) { MessageBox.Show("Vui lòng chọn giới tính"); return; };

            nguoidungs.InsertOnSubmit(dN);
            DK.SubmitChanges();
            loaddata();

            MessageBox.Show("Đăng ký tài khoản thành công");
            DangNhap N = new DangNhap();
            N.Show();
            this.Hide();
        }

    }
}
