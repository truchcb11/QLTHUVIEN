using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN
{
    public partial class DangNhap : Form
    {
        QLTVDataContext DK = new QLTVDataContext();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dK = new DangKy();
            dK.ShowDialog();
            this.Hide();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            if (tk.Trim() == "") { MessageBox.Show("Vui lòng nhập tên tài khoản "); return; }
            else if (mk.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu"); return; };
            nguoidung n = DK.nguoidungs.SingleOrDefault(t=>t.Taikhoan == tk && t.Matkhau == mk);
            if(n!=null)
            {
                MessageBox.Show("Đăng nhập thành công!");
                TrangChu f = new TrangChu();
                f.Show();
                this.Hide();
            }    
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }    
        }

        private void btnThoatDN_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

    }
}
