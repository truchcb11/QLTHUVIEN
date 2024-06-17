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
    public partial class TACGIA : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<tacgia> tacgias;
        public TACGIA()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            tacgias = tv.GetTable<tacgia>();
            var query = from tg in tacgias
                        select tg;
            dataGridView1.DataSource = query;
        }

        private void TACGIA_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            tacgia tg = new tacgia();
            tg.MaTacGia = txtMaTG.Text;
            tg.HoTenTG = txtHoTenTG.Text;

            tacgia n = tv.tacgias.SingleOrDefault(t => t.MaTacGia == tg.MaTacGia || t.HoTenTG == tg.HoTenTG);
            if (n != null)
            {
                MessageBox.Show("Bị trùng mã tác giả hoặc tên tác giả!"); return;
            }
            if (tg.MaTacGia.Trim() == "") { MessageBox.Show("Vui lòng nhập mã tác giả"); return; }
            else if (tg.HoTenTG.Trim() == "") { MessageBox.Show("Vui lòng nhập tên tác giả"); return; };

            tacgias.InsertOnSubmit(tg);
            tv.SubmitChanges();
            loadData();
            txtMaTG.Clear();
            txtHoTenTG.Clear();
            txtMaTG.Focus();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                var query = from tg in tacgias
                            where tg.MaTacGia == txtMaTG.Text
                            select tg;
                foreach (var tg in query)
                    tacgias.DeleteOnSubmit(tg);
                tv.SubmitChanges();
                loadData();
                txtMaTG.Clear();
                txtHoTenTG.Clear();
                txtMaTG.Focus();
            }             
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTG.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtHoTenTG.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            tacgia tac = tv.tacgias.SingleOrDefault(x => x.MaTacGia == txtMaTG.Text);
            if (tv == null) { MessageBox.Show("Vui lòng nhập mã tác giả cần sửa"); return; }
            else
            {
                tac.MaTacGia = txtMaTG.Text;
                tac.HoTenTG = txtHoTenTG.Text;
                if (tac.HoTenTG.Trim() == "") { MessageBox.Show("Vui lòng nhập tên tác giả"); return; }
                tv.SubmitChanges();

                MessageBox.Show("Chỉnh sửa thành công!");
                loadData();
                txtMaTG.Clear();
                txtHoTenTG.Clear();
                txtMaTG.Focus();
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
