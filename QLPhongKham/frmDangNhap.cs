using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPhongKham.Model;
namespace QLPhongKham
{
    public partial class frmDangNhap : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TAIKHOAN Find = context.TAIKHOANs.FirstOrDefault(x => x.TenDN == tbxTaiKhoan.Text);
            TAIKHOAN Find1 = context.TAIKHOANs.FirstOrDefault(x => x.MatKhau == tbxMatKhau.Text);
            if (Find == null)
            {
                MessageBox.Show("Sai tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxTaiKhoan.Focus();
            }
            else
            {
                if (Find1 == null)
                {
                    MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxMatKhau.Focus();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmTrangChu formChinh = new frmTrangChu();
                    this.Hide();
                    formChinh.ShowDialog();
                }
            }
        }

        private void ckxHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckxHienThiMatKhau.Checked)
            {
                tbxMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                tbxMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
