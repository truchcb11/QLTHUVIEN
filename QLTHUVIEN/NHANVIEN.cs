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
    public partial class NHANVIEN : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<nhanvien> nhanviens;
        public NHANVIEN()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            nhanviens = tv.GetTable<nhanvien>();
            var query = from nv in nhanviens
                        select nv;
            dataGridView1.DataSource = query;
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            nhanvien nv = new nhanvien();
            nv.MaNhanVien = txtMaNV.Text;
            nv.HoTenNV = txtHoTenNV.Text;
            nv.NgaySinh = Convert.ToDateTime(dtpNSNV.Text);
            nv.GioiTinh = rbtNam.Checked == true ? true : false;
            nv.DiaChi = txtDiaChiNV.Text;
            nv.SoDTNV = txtDienThoaiNV.Text;

            nhanvien n = tv.nhanviens.SingleOrDefault(t => t.MaNhanVien == nv.MaNhanVien || t.HoTenNV == nv.HoTenNV);
            if (n != null)
            {
                MessageBox.Show("Bị trùng mã nhân viên hoặc tên nhân viên !"); return;
            }
            if (nv.MaNhanVien.Trim() == "") { MessageBox.Show("Vui lòng nhập mã nhân viên"); return; }
            else if (nv.HoTenNV.Trim() == "") { MessageBox.Show("Vui lòng nhập họ tên"); return; }
            else if (rbtNam.Checked == false && rbtNu.Checked == false) { MessageBox.Show("Vui lòng chọn giới tính"); return; }
            else if (nv.DiaChi.Trim() == "") { MessageBox.Show("Vui lòng nhập địa chỉ"); return; }
            else if (nv.SoDTNV.Trim() == "") { MessageBox.Show("Vui lòng nhập số điên thoại!"); return; };

            nhanviens.InsertOnSubmit(nv);
            tv.SubmitChanges();
            loadData();
            txtMaNV.Clear();
            txtHoTenNV.Clear();
            dtpNSNV.Value = DateTime.Now;
            rbtNam.Checked = false;
            rbtNu.Checked = false;
            txtDiaChiNV.Clear();
            txtDienThoaiNV.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            nhanvien nhv = tv.nhanviens.SingleOrDefault(x => x.MaNhanVien == txtMaNV.Text);
            if (nhv == null) { MessageBox.Show("Vui lòng nhập mã nhân viên cần sửa"); return; }
            else
            {
                nhv.MaNhanVien = txtMaNV.Text;
                nhv.HoTenNV = txtHoTenNV.Text;
                nhv.NgaySinh = Convert.ToDateTime(dtpNSNV.Text);
                nhv.GioiTinh = rbtNam.Checked == true ? true : false;
                nhv.DiaChi = txtDiaChiNV.Text;
                nhv.SoDTNV = txtDienThoaiNV.Text;
                if (nhv.HoTenNV.Trim() == "") { MessageBox.Show("Vui lòng nhập họ tên"); return; }
                else if (rbtNam.Checked == false && rbtNu.Checked == false) { MessageBox.Show("Vui lòng chọn giới tính"); return; }
                else if (nhv.DiaChi.Trim() == "") { MessageBox.Show("Vui lòng nhập địa chỉ"); return; }
                else if (nhv.SoDTNV.Trim() == "") { MessageBox.Show("Vui lòng nhập số điên thoại!"); return; };
                tv.SubmitChanges();
                MessageBox.Show("Chỉnh sửa thành công!");
                loadData();
                txtMaNV.Clear();
                txtHoTenNV.Clear();
                dtpNSNV.Value = DateTime.Now;
                rbtNam.Checked = false;
                rbtNu.Checked = false;
                txtDiaChiNV.Clear();
                txtDienThoaiNV.Clear();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtHoTenNV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtpNSNV.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string gt = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (gt == "True")
            {
               rbtNam.Checked = true;
            }
            else
                rbtNu.Checked = true;
            txtDiaChiNV.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDienThoaiNV.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                var query = from nv in nhanviens
                            where nv.MaNhanVien == txtMaNV.Text
                            select nv;
                foreach (var tg in query)
                    nhanviens.DeleteOnSubmit(tg);
                tv.SubmitChanges();
                loadData();
                txtMaNV.Clear();
                txtHoTenNV.Clear();
                dtpNSNV.Value = DateTime.Now;
                rbtNam.Checked = false;
                rbtNu.Checked = false;
                txtDiaChiNV.Clear();
                txtDienThoaiNV.Clear();
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
