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

namespace QLTHUVIEN
{
    public partial class NHAXUATBAN : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<nhaxuatban> nhaxuatbans;
        public NHAXUATBAN()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            nhaxuatbans = tv.GetTable<nhaxuatban>();
            var query = from nxb in nhaxuatbans
                        select nxb;
            dataGridView1.DataSource = query;
        }

        private void NHAXUATBAN_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            nhaxuatban nxb = new nhaxuatban();
            nxb.MaNhaXB = txtMaNhaXB.Text;
            nxb.TenNhaXB = txtTenNhaXB.Text;
            nxb.DiaChi = txtDiaChiXB.Text;
            nxb.SoDTXB = txtSoDTXB.Text;

            nhaxuatban n = tv.nhaxuatbans.SingleOrDefault(t => t.MaNhaXB == nxb.MaNhaXB || t.TenNhaXB == nxb.TenNhaXB);
            if (n != null)
            {
                MessageBox.Show("Bị trùng mã nhà xuất bản hoặc tên nhà xuất bản !"); return;
            }
            if (nxb.MaNhaXB.Trim() == "") { MessageBox.Show("Vui lòng nhập mã nhà xuất bản"); return; }
            else if (nxb.TenNhaXB.Trim() == "") { MessageBox.Show("Vui lòng nhập tên nhà xuất bản"); return; }
            else if (nxb.DiaChi.Trim() == "") { MessageBox.Show("Vui lòng nhập địa chỉ"); return; }
            else if (nxb.SoDTXB.Trim() == "") { MessageBox.Show("Vui lòng số điện thoại"); return; };

            nhaxuatbans.InsertOnSubmit(nxb);
            tv.SubmitChanges();
            loadData();
            txtMaNhaXB.Clear();
            txtTenNhaXB.Clear();
            txtDiaChiXB.Clear();
            txtSoDTXB.Clear();
            txtMaNhaXB.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            nhaxuatban nha = tv.nhaxuatbans.SingleOrDefault(x => x.MaNhaXB == txtMaNhaXB.Text);
            if(nha == null) { MessageBox.Show("Vui lòng nhập mã nhà xuất bản cần sửa"); return; }
            else
            {
               nha.MaNhaXB = txtMaNhaXB.Text;
               nha.TenNhaXB = txtTenNhaXB.Text;
               nha.DiaChi = txtDiaChiXB.Text;
               nha.SoDTXB = txtSoDTXB.Text;
               if (nha.TenNhaXB.Trim() == "") { MessageBox.Show("Vui lòng nhập tên nhà xuất bản"); return; }
               else if (nha.DiaChi.Trim() == "") { MessageBox.Show("Vui lòng nhập địa chỉ"); return; }
               else if (nha.SoDTXB.Trim() == "") { MessageBox.Show("Vui lòng số điện thoại"); return; };
               tv.SubmitChanges();
               MessageBox.Show("Chỉnh sửa thành công!");
               loadData();
               txtMaNhaXB.Clear();
               txtTenNhaXB.Clear();
               txtDiaChiXB.Clear();
               txtSoDTXB.Clear();
               txtMaNhaXB.Focus();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhaXB.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenNhaXB.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDiaChiXB.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSoDTXB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                var query = from nxb in nhaxuatbans
                            where nxb.MaNhaXB == txtMaNhaXB.Text
                            select nxb;
                foreach (var tg in query)
                    nhaxuatbans.DeleteOnSubmit(tg);
                tv.SubmitChanges();
                loadData();
                txtMaNhaXB.Clear();
                txtTenNhaXB.Clear();
                txtDiaChiXB.Clear();
                txtSoDTXB.Clear();
                txtMaNhaXB.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TrangChu dN = new TrangChu();
            dN.Show();
            this.Hide();
        }
    }
}
