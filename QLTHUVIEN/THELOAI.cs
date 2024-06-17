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
    public partial class THELOAI : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<theloai> theloais;
        public THELOAI()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            theloais = tv.GetTable<theloai>();
            var query = from tl in theloais
                        select tl;
            dataGridView1.DataSource = query;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            theloai tl = new theloai();
            tl.MaTheLoai = txtMaTL.Text;
            tl.TenTheLoai = txtTenTL.Text;

            theloai n = tv.theloais.SingleOrDefault(t => t.MaTheLoai == tl.MaTheLoai || t.TenTheLoai == tl.TenTheLoai);
            if (n != null)
            {
                MessageBox.Show("Bị trùng mã thể loại hoặc tên thể loại!"); return;
            }
            if (tl.MaTheLoai.Trim() == "") { MessageBox.Show("Vui lòng nhập mã thể loại"); return; }
            else if (tl.TenTheLoai.Trim() == "") { MessageBox.Show("Vui lòng nhập tên thể loại"); return; };

            theloais.InsertOnSubmit(tl);
            tv.SubmitChanges();
            loadData();
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtMaTL.Focus();
        }
        private void THELOAI_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            theloai the = tv.theloais.SingleOrDefault(x => x.MaTheLoai == txtMaTL.Text);
            if (the == null) { MessageBox.Show("Vui lòng nhập tên thể loại"); return; }
            else
            {
                the.MaTheLoai = txtMaTL.Text;
                the.TenTheLoai = txtTenTL.Text;
                if (the.TenTheLoai.Trim() == "") { MessageBox.Show("Vui lòng nhập tên thể loại"); return; }
                tv.SubmitChanges();

                MessageBox.Show("Chỉnh sửa thành công!");
                loadData();
                txtMaTL.Clear();
                txtTenTL.Clear();
                txtMaTL.Focus();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTL.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenTL.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                var query = from tl in theloais
                            where tl.MaTheLoai == txtMaTL.Text
                            select tl;
                foreach (var tg in query)
                    theloais.DeleteOnSubmit(tg);
                tv.SubmitChanges();
                loadData();
                txtMaTL.Clear();
                txtTenTL.Clear();
                txtMaTL.Focus();
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
