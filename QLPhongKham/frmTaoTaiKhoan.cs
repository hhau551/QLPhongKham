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
    public partial class frmTaoTaiKhoan : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxTenDN.Text == "" || tbxMatKhau.Text == "" || tbxNhapLạiMK.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxTenDN.Text.Length > 20)
                {
                    throw new Exception("Tên đăng nhập không quá 20 kí tự!");
                }
                if (tbxMatKhau.Text.Length > 20)
                {
                    throw new Exception("Mật khẩu không quá 20 ký tự!");
                }

                TAIKHOAN Find = context.TAIKHOANs.FirstOrDefault(x => x.TenDN == tbxTenDN.Text);
                if (Find == null)
                {
                    Find = new TAIKHOAN();
                    Find.TenDN = tbxTenDN.Text;
                    Find.MatKhau = tbxMatKhau.Text;
                    if (tbxNhapLạiMK.Text == tbxMatKhau.Text)
                    {
                        context.TAIKHOANs.Add(Find);
                        context.SaveChanges();
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không trùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmTrangChu trangchu = new frmTrangChu();
            this.Hide();
            trangchu.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tbxMatKhau.UseSystemPasswordChar = false;
                tbxNhapLạiMK.UseSystemPasswordChar = false;
            }
            else
            {
                tbxMatKhau.UseSystemPasswordChar = true;
                tbxNhapLạiMK.UseSystemPasswordChar = true;
            }
        }

        private void frmTaoTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmTrangChu trangchu = new frmTrangChu();
            this.Hide();
            trangchu.ShowDialog();
        }
    }
}
