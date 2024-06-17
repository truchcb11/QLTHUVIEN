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
    public partial class SACH : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<sach> saches;
        Table<theloai> theloais;
        Table<tacgia> tacgias;
        Table<nhaxuatban> nhaxuatbans;

        public SACH()
        {
            InitializeComponent();
        }
        public void loadTL()
        {
            theloais = tv.GetTable<theloai>();
            var query = from tl in theloais
                        select new { matl = tl.MaTheLoai, tentl = tl.TenTheLoai };
            cmbMaTheLoai.DataSource = query;
            cmbMaTheLoai.DisplayMember = "tentl";
            cmbMaTheLoai.ValueMember = "matl";
        }
        public void loadTG()
        {
            tacgias = tv.GetTable<tacgia>();
            var query1 = from tg in tacgias
                        select new { matg = tg.MaTacGia, tentg = tg.HoTenTG };
            cmbMaTacGia.DataSource = query1;
            cmbMaTacGia.DisplayMember = "tentg";
            cmbMaTacGia.ValueMember = "matg";
        }
        public void loadNXB()
        {
            nhaxuatbans = tv.GetTable<nhaxuatban>();
            var query2 = from nxb in nhaxuatbans
                        select new { manxb = nxb.MaNhaXB, tennxb = nxb.TenNhaXB };
            cmbMaNhaXB.DataSource = query2;
            cmbMaNhaXB.DisplayMember = "tennxb";
            cmbMaNhaXB.ValueMember = "manxb";
        }
        public void loadData()
        {
            saches = tv.GetTable<sach>();
            var query = from s in saches
                        select s;
            dataGridView1.DataSource = query;
        }

        private void SACH_Load(object sender, EventArgs e)
        {
            loadData();
            loadTL();
            loadTG();
            loadNXB();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            sach s = new sach();
            s.MaSach = txtMaSach.Text;
            s.TenSach = txtTenSach.Text;
            s.NamXB = txtNamXB.Text;
            s.MaNhaXB = cmbMaNhaXB.SelectedValue.ToString();
            s.MaTacGia = cmbMaTacGia.SelectedValue.ToString();
            s.MaTheLoai = cmbMaTheLoai.SelectedValue.ToString();

            sach n = tv.saches.SingleOrDefault(t => t.MaSach == s.MaSach || t.TenSach == s.TenSach);
            if (n != null)
            {
                MessageBox.Show("Bị trùng mã sách hoặc tên sách !"); return;
            }
            if (s.MaSach.Trim() == "") { MessageBox.Show("Vui lòng nhập mã sách"); return; }
            else if (s.TenSach.Trim() == "") { MessageBox.Show("Vui lòng nhập tên sách"); return; }
            else if (s.NamXB.Trim() == "") { MessageBox.Show("Vui lòng nhập năm xuất bản"); return; };

            saches.InsertOnSubmit(s);
            tv.SubmitChanges();
            loadData();
            txtMaSach.Clear();
            txtNamXB.Clear();
            txtTenSach.Clear();
            cmbMaNhaXB.SelectedIndex = 0;
            cmbMaTacGia.SelectedIndex = 0;
            cmbMaTheLoai.SelectedIndex = 0;
            txtMaSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            sach sa = tv.saches.SingleOrDefault(x => x.MaSach == txtMaSach.Text);
            if (sa == null) { MessageBox.Show("Vui lòng nhập mã sách cần sửa"); return; }
            else
            {
                sa.MaSach = txtMaSach.Text;
                sa.TenSach = txtTenSach.Text;
                sa.NamXB = txtNamXB.Text;
                sa.MaTacGia = cmbMaTacGia.SelectedValue.ToString();
                sa.MaTheLoai = cmbMaTheLoai.SelectedValue.ToString();
                sa.MaNhaXB = cmbMaNhaXB.SelectedValue.ToString();
                if (sa.TenSach.Trim() == "") { MessageBox.Show("Vui lòng nhập tên sách"); return; }
                else if (sa.NamXB.Trim() == "") { MessageBox.Show("Vui lòng nhập năm xuất bản"); return; };
                tv.SubmitChanges();

                MessageBox.Show("Chỉnh sửa thành công!");
                loadData();
                txtMaSach.Clear();
                txtNamXB.Clear();
                txtTenSach.Clear();
                cmbMaNhaXB.SelectedIndex = 0;
                cmbMaTacGia.SelectedIndex = 0;
                cmbMaTheLoai.SelectedIndex = 0;
                txtMaSach.Focus();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSach.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenSach.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNamXB.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbMaNhaXB.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();   
            cmbMaTacGia.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cmbMaTheLoai.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                var query = from s in saches
                            where s.MaSach == txtMaSach.Text
                            select s;
                foreach (var s in query)
                    saches.DeleteOnSubmit(s);
                tv.SubmitChanges();
                loadData();
                txtMaSach.Clear();
                txtNamXB.Clear();
                txtTenSach.Clear();
                cmbMaNhaXB.SelectedIndex = 0;
                cmbMaTacGia.SelectedIndex = 0;
                cmbMaTheLoai.SelectedIndex = 0;
                txtMaSach.Focus();
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
