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
    public partial class frmBenhNhan : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmBenhNhan()
        {
            InitializeComponent();
        }

        private void frmBenhNhan_Load(object sender, EventArgs e)
        {
            try
            {
                List<BENHNHAN> listBenhNhan = context.BENHNHANs.ToList();
                List<KHAMBENH> listKhamBenh = context.KHAMBENHs.ToList();
                List<BENH> listBenh = context.BENHs.ToList();
                List<THUOC> listThuoc = context.THUOCs.ToList();
                List<NHANSU> listNhanSu = context.NHANSUs.ToList();
                List<CHUCVU> listChucVu = context.CHUCVUs.ToList();
                FillBenhNhan(listKhamBenh);
                FillBenh(listBenh);
                FillThuoc(listThuoc);
                FillNhanSu(listNhanSu);
                FillChucVu(listChucVu);
                BindGrid(listBenhNhan);
                cbxTenBN.SelectedIndex = 0;
                cbxTenBenh.SelectedIndex = 0;
                cbxTenThuoc.SelectedIndex = 0;
                cbxNguoiKham.SelectedIndex = 0;
                cbxChucVu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillBenhNhan(List<KHAMBENH> listKhamBenh)
        {
            this.cbxTenBN.DataSource = listKhamBenh;
            this.cbxTenBN.DisplayMember = "HoTen";
            this.cbxTenBN.ValueMember = "MaKB";
        }
        private void FillBenh(List<BENH> listBenh)
        {
            this.cbxTenBenh.DataSource = listBenh;
            this.cbxTenBenh.DisplayMember = "TenBenh";
            this.cbxTenBenh.ValueMember = "MaBenh";
        }
        private void FillThuoc(List<THUOC> listThuoc)
        {
            this.cbxTenThuoc.DataSource = listThuoc;
            this.cbxTenThuoc.DisplayMember = "TenThuoc";
            this.cbxTenThuoc.ValueMember = "MaThuoc";
        }
        private void FillNhanSu(List<NHANSU> listNhanSu)
        {
            this.cbxNguoiKham.DataSource = listNhanSu;
            this.cbxNguoiKham.DisplayMember = "HoTen";
            this.cbxNguoiKham.ValueMember = "MaNS";
        }
        private void FillChucVu(List<CHUCVU> listChucVu)
        {
            this.cbxChucVu.DataSource = listChucVu;
            this.cbxChucVu.DisplayMember = "TenCV";
            this.cbxChucVu.ValueMember = "MaCV";
        }
        private void BindGrid(List<BENHNHAN> listBenhNhan)
        {
            dgvQuanLyBenhNhan.Rows.Clear();
            foreach (var item in listBenhNhan)
            {
                int index = dgvQuanLyBenhNhan.Rows.Add();
                dgvQuanLyBenhNhan.Rows[index].Cells[0].Value = item.MaBN;
                dgvQuanLyBenhNhan.Rows[index].Cells[1].Value = item.NgayKham;
                dgvQuanLyBenhNhan.Rows[index].Cells[2].Value = item.KHAMBENH.HoTen;
                dgvQuanLyBenhNhan.Rows[index].Cells[3].Value = item.BENH.TenBenh;
                dgvQuanLyBenhNhan.Rows[index].Cells[4].Value = item.THUOC.TenThuoc;
                dgvQuanLyBenhNhan.Rows[index].Cells[5].Value = item.NHANSU.HoTen;
                dgvQuanLyBenhNhan.Rows[index].Cells[6].Value = item.CHUCVU.TenCV;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxMaBN.Text == "" || dtpNgayKham.Text == "" || cbxTenBN.Text == "" || cbxTenBenh.Text == "" || cbxTenBenh.Text == "" || cbxTenThuoc.Text == "" || cbxNguoiKham.Text == "" || cbxChucVu.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxMaBN.Text.Length > 5)
                {
                    throw new Exception("Mã BN không quá 5 kí tự!");
                }

                BENHNHAN Find = context.BENHNHANs.FirstOrDefault(x => x.MaBN == tbxMaBN.Text);
                if (Find == null)
                {
                    Find = new BENHNHAN();
                    Find.MaBN = tbxMaBN.Text;
                    Find.NgayKham = dtpNgayKham.Value;
                    Find.MaKB = cbxTenBN.SelectedValue.ToString();
                    Find.MaBenh = cbxTenBenh.SelectedValue.ToString();
                    Find.MaThuoc = cbxTenThuoc.SelectedValue.ToString();
                    Find.MaNS = cbxNguoiKham.SelectedValue.ToString();
                    Find.MaCV = cbxChucVu.SelectedValue.ToString();
                    context.BENHNHANs.Add(Find);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaBN.Clear();
                }
                else
                {
                    Find.NgayKham = dtpNgayKham.Value;
                    Find.MaKB = cbxTenBN.SelectedValue.ToString();
                    Find.MaBenh = cbxTenBenh.SelectedValue.ToString();
                    Find.MaThuoc = cbxTenThuoc.SelectedValue.ToString();
                    Find.MaNS = cbxNguoiKham.SelectedValue.ToString();
                    DialogResult dlr = MessageBox.Show("Xác nhận sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxMaBN.Clear();
                    }
                }
                BindGrid(context.BENHNHANs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BENHNHAN Find = context.BENHNHANs.FirstOrDefault(x => x.MaBN == tbxMaBN.Text);
            if (Find == null)
            {
                MessageBox.Show("Không tìm thấy bệnh nhân cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.BENHNHANs.Remove(Find);
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaBN.Clear();
                }
            }
            BindGrid(context.BENHNHANs.ToList());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
            frmTrangChu formChinh = new frmTrangChu();
            this.Hide();
            formChinh.ShowDialog();
        }

        private void dgvQuanLyBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mbn = dgvQuanLyBenhNhan.Rows[e.RowIndex].Cells[0].Value + "";
            BENHNHAN Find = context.BENHNHANs.FirstOrDefault(p => p.MaBN == mbn);
            {
                if (Find != null)
                {
                    tbxMaBN.Text = Find.MaBN;
                    dtpNgayKham.Text = Find.NgayKham.ToString();
                    cbxTenBN.SelectedValue = Find.MaKB;
                    cbxTenBenh.SelectedValue = Find.MaBenh;
                    cbxTenThuoc.SelectedValue = Find.MaThuoc;
                    cbxNguoiKham.SelectedValue = Find.MaNS;
                    cbxChucVu.SelectedValue = Find.MaCV;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tbxTimKiem.Text.Trim();
            BindGrid(context.BENHNHANs.Where(x => x.KHAMBENH.HoTen.Contains(keyword)).ToList());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbxTimKiem.Clear();
            BindGrid(context.BENHNHANs.ToList());
        }

        private void frmBenhNhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
