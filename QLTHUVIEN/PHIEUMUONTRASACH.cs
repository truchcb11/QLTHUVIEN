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
    public partial class PHIEUMUONTRASACH : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<phiemmuontra> phiemmuontras;
        Table<nhanvien> nhanviens;
        Table<docgia> docgias;
        Table<sach> saches;
        public PHIEUMUONTRASACH()
        {
            InitializeComponent();
        }
        public void loadNV()
        {
            nhanviens = tv.GetTable<nhanvien>();
            var query = from nv in nhanviens
                        select new { manv = nv.MaNhanVien, tennv = nv.HoTenNV };
            cbxNguoiLapPhieu.DataSource = query;
            cbxNguoiLapPhieu.DisplayMember = "tennv";
            cbxNguoiLapPhieu.ValueMember = "manv";
        }
        public void loadDG()
        {
            docgias = tv.GetTable<docgia>();
            var query = from dg in docgias
                        select new { madg = dg.MaDocGia, tendg = dg.HoTenDG };
            cbxMaDocGia.DataSource = query;
            cbxMaDocGia.DisplayMember = "tendg";
            cbxMaDocGia.ValueMember = "madg";
        }
        public void loadS()
        {
            saches = tv.GetTable<sach>();
            var query = from s in saches
                        select new { mas = s.MaSach, tens = s.TenSach };
            cbxMaSach.DataSource = query;
            cbxMaSach.DisplayMember = "tens";
            cbxMaSach.ValueMember = "mas";
        }
        public void loadData()
        {
            phiemmuontras = tv.GetTable<phiemmuontra>();
            var query = from p in phiemmuontras
                        select p;
            dataGridView1.DataSource = query;
        }

        private void PHIEUMUONTRASACH_Load(object sender, EventArgs e)
        {
            loadData();
            loadDG();
            loadNV();
            loadS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            phiemmuontra p = new phiemmuontra();
            p.MaPhieu = txtMaPhieu.Text;
            p.NgayMuon = Convert.ToDateTime(dtpNgayMuon.Text);
            p.NgayHenTra = Convert.ToDateTime(dtpNgayTra.Text);
            p.MaDocGia = cbxMaDocGia.SelectedValue.ToString();
            p.MaNhanVien = cbxNguoiLapPhieu.SelectedValue.ToString();
            p.MaSach = cbxMaSach.SelectedValue.ToString();
            p.TinhTrangSach = txtTinhTrang.Text;
            phiemmuontra n = tv.phiemmuontras.SingleOrDefault(t => t.MaPhieu == p.MaPhieu);
            if (n != null)
            {
                MessageBox.Show("Bị trùng mã phiếu!"); return;
            }
            if (p.MaPhieu.Trim() == "") { MessageBox.Show("Vui lòng nhập mã phiếu"); return; }
            else if (p.TinhTrangSach.Trim() == "") { MessageBox.Show("Vui lòng nhập tình trạng sách"); return; }
            else if (dtpNgayTra.Text == dtpNgayMuon.Text) { MessageBox.Show("Vui lòng nhập ngày trả sách"); return; };
            

            phiemmuontras.InsertOnSubmit(p);
            tv.SubmitChanges();
            loadData();
            txtMaPhieu.Clear();
            dtpNgayMuon.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now;
            cbxMaDocGia.SelectedIndex = 0;
            cbxNguoiLapPhieu.SelectedIndex = 0;
            cbxMaSach.SelectedIndex = 0;
            txtTinhTrang.Clear();
            txtMaPhieu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            phiemmuontra ph = tv.phiemmuontras.SingleOrDefault(x => x.MaPhieu == txtMaPhieu.Text);
            if (ph == null) { MessageBox.Show("Vui lòng nhập mã phiếu cần sửa"); return; }
            else
            {
                ph.MaPhieu = txtMaPhieu.Text;
                ph.NgayMuon = Convert.ToDateTime(dtpNgayMuon.Text);
                ph.NgayHenTra = Convert.ToDateTime(dtpNgayTra.Text);
                ph.MaDocGia = cbxMaDocGia.SelectedValue.ToString();
                ph.MaNhanVien = cbxNguoiLapPhieu.SelectedValue.ToString();
                ph.MaSach = cbxMaSach.SelectedValue.ToString();
                ph.TinhTrangSach = txtTinhTrang.Text;
                if (ph.TinhTrangSach.Trim() == "") { MessageBox.Show("Vui lòng nhập tình trạng sách"); return; }
                else if (dtpNgayTra.Text == dtpNgayMuon.Text) { MessageBox.Show("Vui lòng nhập ngày trả sách"); return; };
                tv.SubmitChanges();

                MessageBox.Show("Chỉnh sửa thành công!");
                loadData();
                txtMaPhieu.Clear();
                dtpNgayMuon.Value = DateTime.Now;
                dtpNgayTra.Value = DateTime.Now;
                cbxMaDocGia.SelectedIndex = 0;
                cbxNguoiLapPhieu.SelectedIndex = 0;
                cbxMaSach.SelectedIndex = 0;
                txtTinhTrang.Clear();
                txtMaPhieu.Focus();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dtpNgayMuon.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtpNgayTra.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbxMaDocGia.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbxNguoiLapPhieu.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbxMaSach.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTinhTrang.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                var query = from p in phiemmuontras
                            where p.MaPhieu == txtMaPhieu.Text
                            select p;
                foreach (var s in query)
                    phiemmuontras.DeleteOnSubmit(s);
                tv.SubmitChanges();
                loadData();
                txtMaPhieu.Clear();
                dtpNgayMuon.Value = DateTime.Now;
                dtpNgayTra.Value = DateTime.Now;
                cbxMaDocGia.SelectedIndex = 0;
                cbxNguoiLapPhieu.SelectedIndex = 0;
                cbxMaSach.SelectedIndex = 0;
                txtTinhTrang.Clear();
                txtMaPhieu.Focus();
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
