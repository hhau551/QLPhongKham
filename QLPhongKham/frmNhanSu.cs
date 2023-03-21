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
    public partial class frmNhanSu : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmNhanSu()
        {
            InitializeComponent();
        }

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            try
            {
                List<NHANSU> listNhanSu = context.NHANSUs.ToList();
                List<KHOA> listKhoa = context.KHOAs.ToList();
                List<CHUCVU> listChucVu = context.CHUCVUs.ToList();
                FillKhoa(listKhoa);
                FillChucVu(listChucVu);
                BindGrid(listNhanSu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillKhoa(List<KHOA> listKhoa)
        {
            this.cbxKhoa.DataSource = listKhoa;
            this.cbxKhoa.DisplayMember = "TenKhoa";
            this.cbxKhoa.ValueMember = "MaKhoa";
        }
        private void FillChucVu(List<CHUCVU> listChucVu)
        {
            this.cbxChucVu.DataSource = listChucVu;
            this.cbxChucVu.DisplayMember = "TenCV";
            this.cbxChucVu.ValueMember = "MaCV";
        }
        private void BindGrid(List<NHANSU> listNhanSu)
        {
            dgvQuanLyNhanSu.Rows.Clear();
            foreach (var item in listNhanSu)
            {
                int index = dgvQuanLyNhanSu.Rows.Add();
                dgvQuanLyNhanSu.Rows[index].Cells[0].Value = item.MaNS;
                dgvQuanLyNhanSu.Rows[index].Cells[1].Value = item.HoTen;
                dgvQuanLyNhanSu.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvQuanLyNhanSu.Rows[index].Cells[3].Value = item.GioiTinh;
                dgvQuanLyNhanSu.Rows[index].Cells[4].Value = item.KHOA.TenKhoa;
                dgvQuanLyNhanSu.Rows[index].Cells[5].Value = item.CHUCVU.TenCV;
                dgvQuanLyNhanSu.Rows[index].Cells[6].Value = item.SDT;
                dgvQuanLyNhanSu.Rows[index].Cells[7].Value = item.NgayVaoLam;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxMaNS.Text == "" || tbxHoTen.Text == "" || dtpNgaySinh.Text == "" || tbxGioiTinh.Text == "" || cbxKhoa.Text == "" || cbxChucVu.Text == "" || tbxSDT.Text == "" || dtpNgayLam.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxMaNS.Text.Length > 5)
                {
                    throw new Exception("Mã NS không quá 5 kí tự!");
                }
                if (tbxSDT.Text.Length != 10)
                {
                    throw new Exception("SĐT không hợp lệ!");
                }

                NHANSU Find = context.NHANSUs.FirstOrDefault(x => x.MaNS == tbxMaNS.Text);
                if (Find == null)
                {
                    Find = new NHANSU();
                    Find.MaNS = tbxMaNS.Text;
                    Find.HoTen = tbxHoTen.Text;
                    Find.NgaySinh = dtpNgaySinh.Value;
                    Find.GioiTinh = tbxGioiTinh.Text;
                    Find.MaKhoa = cbxKhoa.SelectedValue.ToString();
                    Find.MaCV = cbxChucVu.SelectedValue.ToString();
                    Find.SDT = tbxSDT.Text;
                    Find.NgayVaoLam = dtpNgayLam.Value;
                    context.NHANSUs.Add(Find);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaNS.Clear();
                    tbxHoTen.Clear();
                    tbxGioiTinh.Clear();
                    tbxSDT.Clear();
                    tbxTimKiem.Clear();
                }
                else
                {
                    Find.HoTen = tbxHoTen.Text;
                    Find.NgaySinh = dtpNgaySinh.Value;
                    Find.GioiTinh = tbxGioiTinh.Text;
                    Find.MaKhoa = cbxKhoa.SelectedValue.ToString();
                    Find.MaCV = cbxChucVu.SelectedValue.ToString();
                    Find.SDT = tbxSDT.Text;
                    Find.NgayVaoLam = dtpNgayLam.Value;
                    DialogResult dlr = MessageBox.Show("Xác nhận sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxMaNS.Clear();
                        tbxHoTen.Clear();
                        tbxGioiTinh.Clear();
                        tbxSDT.Clear();
                        tbxTimKiem.Clear();
                    }
                }
                BindGrid(context.NHANSUs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            NHANSU Find = context.NHANSUs.FirstOrDefault(x => x.MaNS == tbxMaNS.Text);
            if (Find == null)
            {
                MessageBox.Show("Không tìm thấy nhân sự cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.NHANSUs.Remove(Find);
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaNS.Clear();
                    tbxHoTen.Clear();
                    tbxGioiTinh.Clear();
                    tbxSDT.Clear();
                    tbxTimKiem.Clear();
                }
            }
            BindGrid(context.NHANSUs.ToList());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmTrangChu formChinh = new frmTrangChu();
            this.Hide();
            formChinh.ShowDialog();
        }

        private void dgvQuanLyNhanSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mns = dgvQuanLyNhanSu.Rows[e.RowIndex].Cells[0].Value + "";

            NHANSU Find = context.NHANSUs.FirstOrDefault(p => p.MaNS == mns);
            {
                if (Find != null)
                {
                    tbxMaNS.Text = Find.MaNS;
                    tbxHoTen.Text = Find.HoTen;
                    dtpNgaySinh.Text = Find.NgaySinh.ToString();
                    tbxGioiTinh.Text = Find.GioiTinh;
                    cbxKhoa.SelectedValue = Find.MaKhoa;
                    cbxChucVu.SelectedValue = Find.MaCV;
                    tbxSDT.Text = Find.SDT;
                    dtpNgayLam.Text = Find.NgayVaoLam.ToString();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tbxTimKiem.Text.Trim();
            BindGrid(context.NHANSUs.Where(x => x.HoTen.Contains(keyword)).ToList());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbxTimKiem.Clear();
            BindGrid(context.NHANSUs.ToList());
        }

        private void frmNhanSu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
