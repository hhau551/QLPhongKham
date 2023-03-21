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
    public partial class frmBenh : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmBenh()
        {
            InitializeComponent();
        }

        private void frmBenh_Load(object sender, EventArgs e)
        {
            try
            {
                List<BENH> listBenh = context.BENHs.ToList();
                BindGrid(listBenh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<BENH> listBenh)
        {
            dgvQuanLyBenh.Rows.Clear();
            foreach (var item in listBenh)
            {
                int index = dgvQuanLyBenh.Rows.Add();
                dgvQuanLyBenh.Rows[index].Cells[0].Value = item.MaBenh;
                dgvQuanLyBenh.Rows[index].Cells[1].Value = item.TenBenh;
                dgvQuanLyBenh.Rows[index].Cells[2].Value = item.TrieuChung;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxMaBenh.Text == "" || tbxTenBenh.Text == "" || tbxTrieuChung.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxMaBenh.Text.Length > 5)
                {
                    throw new Exception("Mã bệnh không quá 5 kí tự!");
                }

                BENH Find = context.BENHs.FirstOrDefault(x => x.MaBenh == tbxMaBenh.Text);
                if (Find == null)
                {
                    Find = new BENH();
                    Find.MaBenh = tbxMaBenh.Text;
                    Find.TenBenh = tbxTenBenh.Text;
                    Find.TrieuChung = tbxTrieuChung.Text;
                    context.BENHs.Add(Find);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaBenh.Clear();
                    tbxTenBenh.Clear();
                    tbxTrieuChung.Clear();
                }
                else
                {
                    Find.TenBenh = tbxTenBenh.Text;
                    Find.TrieuChung = tbxTrieuChung.Text;
                    DialogResult dlr = MessageBox.Show("Xác nhận sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxMaBenh.Clear();
                        tbxTenBenh.Clear();
                        tbxTrieuChung.Clear();
                    }
                }
                BindGrid(context.BENHs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BENH Find = context.BENHs.FirstOrDefault(x => x.MaBenh == tbxMaBenh.Text);
            if (Find == null)
            {
                MessageBox.Show("Không tìm thấy bệnh cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.BENHs.Remove(Find);
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaBenh.Clear();
                    tbxTenBenh.Clear();
                    tbxTrieuChung.Clear();
                }
            }
            BindGrid(context.BENHs.ToList());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmTrangChu formChinh = new frmTrangChu();
            this.Hide();
            formChinh.ShowDialog();
        }

        private void dgvQuanLyBenh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mb = dgvQuanLyBenh.Rows[e.RowIndex].Cells[0].Value + "";
            BENH Find = context.BENHs.FirstOrDefault(p => p.MaBenh == mb);
            {
                if (Find != null)
                {
                    tbxMaBenh.Text = Find.MaBenh;
                    tbxTenBenh.Text = Find.TenBenh;
                    tbxTrieuChung.Text = Find.TrieuChung.ToString();
                }
            }
        }

        private void frmBenh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
