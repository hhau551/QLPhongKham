using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongKham
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void hồSơKhámBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhamBenh khambenh = new frmKhamBenh();
            this.Hide();
            khambenh.ShowDialog();
        }

        private void nhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanSu nhansu = new frmNhanSu();
            this.Hide();
            nhansu.ShowDialog();
        }

        private void bệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBenhNhan benhnhan = new frmBenhNhan();
            this.Hide();
            benhnhan.ShowDialog();
        }

        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuoc thuoc = new frmThuoc();
            this.Hide();
            thuoc.ShowDialog();
        }

        private void quảnLýBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBenh benh = new frmBenh();
            this.Hide();
            benh.ShowDialog();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu dichvu = new frmDichVu();
            this.Hide();
            dichvu.ShowDialog();
        }

        private void việnPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVienPhi vienphi = new frmVienPhi();
            this.Hide();
            vienphi.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap dangnhap = new frmDangNhap();
            this.Hide();
            dangnhap.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoTaiKhoan taoTK = new frmTaoTaiKhoan();
            this.Hide();
            taoTK.ShowDialog();
        }
    }
}
