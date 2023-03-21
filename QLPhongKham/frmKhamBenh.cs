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
    public partial class frmKhamBenh : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmKhamBenh()
        {
            InitializeComponent();
        }

        private void frmKhamBenh_Load(object sender, EventArgs e)
        {
            try
            {
                List<KHAMBENH> listKhamBenh = context.KHAMBENHs.ToList();
                BindGrid(listKhamBenh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<KHAMBENH> listKhamBenh)
        {
            dgvQuanLyKhamBenh.Rows.Clear();
            foreach (var item in listKhamBenh)
            {
                int index = dgvQuanLyKhamBenh.Rows.Add();
                dgvQuanLyKhamBenh.Rows[index].Cells[0].Value = item.MaKB;
                dgvQuanLyKhamBenh.Rows[index].Cells[1].Value = item.HoTen;
                dgvQuanLyKhamBenh.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvQuanLyKhamBenh.Rows[index].Cells[3].Value = item.GioiTinh;
                dgvQuanLyKhamBenh.Rows[index].Cells[4].Value = item.DiaChi;
                dgvQuanLyKhamBenh.Rows[index].Cells[5].Value = item.SDT;
                dgvQuanLyKhamBenh.Rows[index].Cells[6].Value = item.BHYT;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxMaKB.Text == "" || tbxHoTen.Text == "" || dtpNgaySinh.Text == "" || tbxGioiTinh.Text == "" || tbxDiaChi.Text == "" || tbxSDT.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxMaKB.Text.Length > 5)
                {
                    throw new Exception("Mã KB không quá 5 kí tự!");
                }
                if (tbxSDT.Text.Length != 10)
                {
                    throw new Exception("SĐT không hợp lệ!");
                }

                KHAMBENH Find = context.KHAMBENHs.FirstOrDefault(x => x.MaKB == tbxMaKB.Text);
                if (Find == null)
                {
                    Find = new KHAMBENH();
                    Find.MaKB = tbxMaKB.Text;
                    Find.HoTen = tbxHoTen.Text;
                    Find.NgaySinh = dtpNgaySinh.Value;
                    Find.GioiTinh = tbxGioiTinh.Text;
                    Find.DiaChi = tbxDiaChi.Text;
                    Find.SDT = tbxSDT.Text;
                    Find.BHYT = tbxBHYT.Text;
                    context.KHAMBENHs.Add(Find);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaKB.Clear();
                    tbxHoTen.Clear();
                    tbxGioiTinh.Clear();
                    tbxDiaChi.Clear();
                    tbxSDT.Clear();
                    tbxBHYT.Clear();
                    tbxTimKiem.Clear();
                }
                else
                {
                    Find.HoTen = tbxHoTen.Text;
                    Find.NgaySinh = dtpNgaySinh.Value;
                    Find.GioiTinh = tbxGioiTinh.Text;
                    Find.DiaChi = tbxDiaChi.Text;
                    Find.SDT = tbxSDT.Text;
                    Find.BHYT = tbxBHYT.Text;
                    DialogResult dlr = MessageBox.Show("Xác nhận sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxMaKB.Clear();
                        tbxHoTen.Clear();
                        tbxGioiTinh.Clear();
                        tbxDiaChi.Clear();
                        tbxSDT.Clear();
                        tbxBHYT.Clear();
                        tbxTimKiem.Clear();
                    }
                }
                BindGrid(context.KHAMBENHs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            KHAMBENH Find = context.KHAMBENHs.FirstOrDefault(x => x.MaKB == tbxMaKB.Text);
            if (Find == null)
            {
                MessageBox.Show("Không tìm thấy nhân sự cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.KHAMBENHs.Remove(Find);
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaKB.Clear();
                    tbxHoTen.Clear();
                    tbxGioiTinh.Clear();
                    tbxDiaChi.Clear();
                    tbxSDT.Clear();
                    tbxBHYT.Clear();
                    tbxTimKiem.Clear();
                }
            }
            BindGrid(context.KHAMBENHs.ToList());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
            frmTrangChu formChinh = new frmTrangChu();
            this.Hide();
            formChinh.ShowDialog();
        }

        private void dgvQuanLyKhamBenh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mkb = dgvQuanLyKhamBenh.Rows[e.RowIndex].Cells[0].Value + "";

            KHAMBENH Find = context.KHAMBENHs.FirstOrDefault(p => p.MaKB == mkb);
            {
                if (Find != null)
                {
                    tbxMaKB.Text = Find.MaKB;
                    tbxHoTen.Text = Find.HoTen;
                    dtpNgaySinh.Text = Find.NgaySinh.ToString();
                    tbxGioiTinh.Text = Find.GioiTinh;
                    tbxDiaChi.Text = Find.DiaChi;
                    tbxSDT.Text = Find.SDT;
                    tbxBHYT.Text = Find.BHYT;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tbxTimKiem.Text.Trim();
            BindGrid(context.KHAMBENHs.Where(x => x.HoTen.Contains(keyword)).ToList());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbxTimKiem.Clear();
            BindGrid(context.KHAMBENHs.ToList());
        }

        private void frmKhamBenh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
