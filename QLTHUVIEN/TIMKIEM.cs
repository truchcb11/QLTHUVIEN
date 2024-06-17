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
    public partial class TIMKIEM : Form
    {
        qltv1DataContext tv = new qltv1DataContext();
        Table<sach> saches;
        Table<docgia> docgias;
        public TIMKIEM()
        {
            InitializeComponent();
        }
        public void loadData1()
        {
            saches = tv.GetTable<sach>();
            var query = from s in saches
                        select s;
            dgvSach.DataSource = query;
        }
        public void loadData2()
        {
            docgias = tv.GetTable<docgia>();
            var query = from dg in docgias
                        select dg;
            dgvDocGia.DataSource = query;
        }

        private void TIMKIEM_Load(object sender, EventArgs e)
        {
            loadData1();
            loadData2();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSach.Checked == true)
            {
                dgvSach.DataSource = tv.saches.Where(p => p.MaSach.Equals(txtNhapTenOrMa.Text));
            }  
            else dgvSach.DataSource = tv.saches.Where(p => p.TenSach.Equals(txtNhapTenOrMa.Text));
        }

        private void btnTim1_Click(object sender, EventArgs e)
        {
            if (rdbMaDG.Checked == true)
            {
                dgvDocGia.DataSource = tv.docgias.Where(p => p.MaDocGia.Equals(txtNhapMAOrTenDG.Text));
            }
            else dgvDocGia.DataSource = tv.docgias.Where(p => p.HoTenDG.Equals(txtNhapMAOrTenDG.Text));
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TrangChu dN = new TrangChu();
            dN.Show();
            this.Hide();
        }

        private void btnThoa_Click(object sender, EventArgs e)
        {
            TrangChu dN = new TrangChu();
            dN.Show();
            this.Hide();
        }
    }
}
