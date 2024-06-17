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
    public partial class DOCGIA : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<docgia> docgias;
        public DOCGIA()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            docgias = tv.GetTable<docgia>();
            var query = from dg in docgias
                        select dg;
            dataGridView1.DataSource = query;
        }
        private void DOCGIA_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            docgia dg = new docgia();
            dg.MaDocGia = txtMaDG.Text;
            dg.HoTenDG = txtHoTenDG.Text;
            dg.NgaySinh = Convert.ToDateTime(dtpNSDG.Text);
            dg.GioiTinh = rbnNam.Checked == true ?true :false;
            dg.DiaChi = txtDiaChiDG.Text;

            docgia n = tv.docgias.SingleOrDefault(t => t.MaDocGia == dg.MaDocGia || t.HoTenDG == dg.HoTenDG);
            if (n != null)
            {
                MessageBox.Show("Bị trùng mã độc giả hoặc tên độc giả !"); return;
            }
            if (dg.MaDocGia.Trim() == "") { MessageBox.Show("Vui lòng nhập mã độc giả"); return; }
            else if (dg.HoTenDG.Trim() == "") { MessageBox.Show("Vui lòng nhập họ tên"); return; }
            else if (rbnNam.Checked == false && rbnNu.Checked == false) { MessageBox.Show("Vui lòng chọn giới tính"); return; }
            else if (dg.DiaChi.Trim() == "") { MessageBox.Show("Vui lòng nhập địa chỉ"); return; };

            docgias.InsertOnSubmit(dg);
            tv.SubmitChanges();
            loadData();
            txtMaDG.Clear();
            txtHoTenDG.Clear();
            dtpNSDG.Value =DateTime.Now;
            rbnNam.Checked = false;
            rbnNu.Checked = false;
            txtDiaChiDG.Clear();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDG.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtHoTenDG.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtpNSDG.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string gt = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (gt == "True")
            {
                rbnNam.Checked = true;
            }
            else
                rbnNu.Checked = true;
            txtDiaChiDG.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            docgia doc = tv.docgias.SingleOrDefault(x => x.MaDocGia == txtMaDG.Text);
            if (doc == null) { MessageBox.Show("Vui lòng nhập mã độc giả cần sửa"); return; }
            else
            {
                doc.MaDocGia = txtMaDG.Text;
                doc.HoTenDG = txtHoTenDG.Text;
                doc.NgaySinh = Convert.ToDateTime(dtpNSDG.Text);
                doc.GioiTinh = rbnNam.Checked == true ? true : false;
                doc.DiaChi = txtDiaChiDG.Text;
                if (doc.HoTenDG.Trim() == "") { MessageBox.Show("Vui lòng nhập họ tên độc giả"); return; }
                else if (rbnNam.Checked == false && rbnNu.Checked == false) { MessageBox.Show("Vui lòng chọn giới tính"); return; }
                else if (doc.DiaChi.Trim() == "") { MessageBox.Show("Vui lòng nhập địa chỉ"); return; };
                tv.SubmitChanges();

                MessageBox.Show("Chỉnh sửa thành công!");
                loadData();
                txtMaDG.Clear();
                txtHoTenDG.Clear();
                dtpNSDG.Value = DateTime.Now;
                rbnNam.Checked = false;
                rbnNu.Checked = false;
                txtDiaChiDG.Clear();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                var query = from dg in docgias
                            where dg.MaDocGia == txtMaDG.Text
                            select dg;
                foreach (var tg in query)
                    docgias.DeleteOnSubmit(tg);
                tv.SubmitChanges();
                loadData();
                txtMaDG.Clear();
                txtHoTenDG.Clear();
                dtpNSDG.Value = DateTime.Now;
                rbnNam.Checked = false;
                rbnNu.Checked = false;
                txtDiaChiDG.Clear();
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
