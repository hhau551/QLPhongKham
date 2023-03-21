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
    public partial class frmVienPhi : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmVienPhi()
        {
            InitializeComponent();
        }

        private void frmVienPhi_Load(object sender, EventArgs e)
        {
            try
            {
                List<HOADON> listHoaDon = context.HOADONs.ToList();
                List<KHAMBENH> listKhamBenh = context.KHAMBENHs.ToList();
                List<THUOC> listThuoc = context.THUOCs.ToList();
                List<DICHVU> listDichVu = context.DICHVUs.ToList();
                FillMaKB(listKhamBenh);
                FillBenhNhan(listKhamBenh);
                FillThuoc(listThuoc);
                FillDGThuoc(listThuoc);
                FillDichVu(listDichVu);
                FillDGDichVu(listDichVu);
                BindGrid(listHoaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillMaKB(List<KHAMBENH> listKhamBenh)
        {
            this.cbxMaKB.DataSource = listKhamBenh;
            this.cbxMaKB.DisplayMember = "MaKB";
            this.cbxMaKB.ValueMember = "MaKB";
        }
        private void FillBenhNhan(List<KHAMBENH> listKhamBenh)
        {
            this.cbxHoTen.DataSource = listKhamBenh;
            this.cbxHoTen.DisplayMember = "HoTen";
            this.cbxHoTen.ValueMember = "MaKB";
        }
        private void FillThuoc(List<THUOC> listThuoc)
        {
            this.cbxThuoc.DataSource = listThuoc;
            this.cbxThuoc.DisplayMember = "TenThuoc";
            this.cbxThuoc.ValueMember = "MaThuoc";
        }
        private void FillDGThuoc(List<THUOC> listThuoc)
        {
            this.cbxDGThuoc.DataSource = listThuoc;
            this.cbxDGThuoc.DisplayMember = "DonGia";
            this.cbxDGThuoc.ValueMember = "MaThuoc";
        }
        private void FillDichVu(List<DICHVU> listDichVu)
        {
            this.cbxDichVu.DataSource = listDichVu;
            this.cbxDichVu.DisplayMember = "TenDV";
            this.cbxDichVu.ValueMember = "MaDV";
        }
        private void FillDGDichVu(List<DICHVU> listDichVu)
        {
            this.cbxDGDichVu.DataSource = listDichVu;
            this.cbxDGDichVu.DisplayMember = "DonGia";
            this.cbxDGDichVu.ValueMember = "MaDV";
        }
        private void BindGrid(List<HOADON> listHoaDon)
        {
            dgvQuanLyVienPhi.Rows.Clear();
            foreach (var item in listHoaDon)
            {
                int index = dgvQuanLyVienPhi.Rows.Add();
                dgvQuanLyVienPhi.Rows[index].Cells[0].Value = item.MaHD;
                dgvQuanLyVienPhi.Rows[index].Cells[1].Value = item.MaKB;
                dgvQuanLyVienPhi.Rows[index].Cells[2].Value = item.KHAMBENH.HoTen;
                dgvQuanLyVienPhi.Rows[index].Cells[3].Value = item.THUOC.TenThuoc;
                dgvQuanLyVienPhi.Rows[index].Cells[4].Value = item.THUOC.DonGia;
                dgvQuanLyVienPhi.Rows[index].Cells[5].Value = item.DICHVU.TenDV;
                dgvQuanLyVienPhi.Rows[index].Cells[6].Value = item.DICHVU.DonGia;
                dgvQuanLyVienPhi.Rows[index].Cells[7].Value = item.SoLuongDV;
                dgvQuanLyVienPhi.Rows[index].Cells[8].Value = item.ThanhTien;
                dgvQuanLyVienPhi.Rows[index].Cells[9].Value = item.NgayLapHD;
                dgvQuanLyVienPhi.Rows[index].Cells[10].Value = item.TinhTrang;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxMaHD.Text == "" || cbxMaKB.Text == "" || cbxHoTen.Text == "" || cbxThuoc.Text == "" || cbxDGThuoc.Text == "" || cbxDichVu.Text == "" || cbxDGDichVu.Text == "" || tbxSoLuong.Text == "" || dtpNgayLap.Text == "" || tbxTrangThai.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxMaHD.Text.Length > 5)
                {
                    throw new Exception("Mã HD không quá 5 kí tự!");
                }
                if (int.Parse(tbxSoLuong.Text) < 0)
                {
                    throw new Exception("Số lượng không bé hơn 0!");
                }

                HOADON Find = context.HOADONs.FirstOrDefault(x => x.MaHD == tbxMaHD.Text);
                if (Find == null)
                {
                    Find = new HOADON();
                    Find.MaHD = tbxMaHD.Text;
                    Find.MaKB = cbxMaKB.SelectedValue.ToString();
                    Find.HoTen = cbxHoTen.SelectedValue.ToString();
                    Find.MaThuoc = cbxThuoc.SelectedValue.ToString();
                    Find.MaThuoc = cbxDGThuoc.SelectedValue.ToString();
                    Find.MaDV = cbxDichVu.SelectedValue.ToString();
                    Find.MaDV = cbxDGDichVu.SelectedValue.ToString();
                    Find.SoLuongDV = int.Parse(tbxSoLuong.Text);
                    float ThanhTien = float.Parse(cbxDGThuoc.Text) + float.Parse(cbxDGDichVu.Text) * (float)(int.Parse(tbxSoLuong.Text));
                    tbxThanhTien.Text = ThanhTien.ToString();
                    Find.ThanhTien = float.Parse(tbxThanhTien.Text);
                    Find.NgayLapHD = dtpNgayLap.Value;
                    Find.TinhTrang = tbxTrangThai.Text;
                    context.HOADONs.Add(Find);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaHD.Clear();
                    tbxSoLuong.Clear();
                    tbxThanhTien.Clear();
                    tbxTrangThai.Clear();
                    tbxTimKiem.Clear();
                }
                else
                {
                    Find.MaKB = cbxMaKB.SelectedValue.ToString();
                    Find.HoTen = cbxHoTen.SelectedValue.ToString();
                    Find.MaThuoc = cbxThuoc.SelectedValue.ToString();
                    Find.MaThuoc = cbxDGThuoc.SelectedValue.ToString();
                    Find.MaDV = cbxDichVu.SelectedValue.ToString();
                    Find.MaDV = cbxDGDichVu.SelectedValue.ToString();
                    Find.SoLuongDV = int.Parse(tbxSoLuong.Text);
                    float ThanhTien = float.Parse(cbxDGThuoc.Text) + float.Parse(cbxDGDichVu.Text) * (float)(int.Parse(tbxSoLuong.Text));
                    tbxThanhTien.Text = ThanhTien.ToString();
                    Find.ThanhTien = float.Parse(tbxThanhTien.Text);
                    Find.NgayLapHD = dtpNgayLap.Value;
                    Find.TinhTrang = tbxTrangThai.Text;
                    DialogResult dlr = MessageBox.Show("Xác nhận sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxMaHD.Clear();
                        tbxSoLuong.Clear();
                        tbxThanhTien.Clear();
                        tbxTrangThai.Clear();
                        tbxTimKiem.Clear();
                    }
                }
                BindGrid(context.HOADONs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            HOADON Find = context.HOADONs.FirstOrDefault(x => x.MaHD == tbxMaHD.Text);
            if (Find == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.HOADONs.Remove(Find);
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaHD.Clear();
                    tbxSoLuong.Clear();
                    tbxThanhTien.Clear();
                    tbxTrangThai.Clear();
                    tbxTimKiem.Clear();
                }
            }
            BindGrid(context.HOADONs.ToList());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmTrangChu formChinh = new frmTrangChu();
            this.Hide();
            formChinh.ShowDialog();
        }

        private void dgvQuanLyVienPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mhd = dgvQuanLyVienPhi.Rows[e.RowIndex].Cells[0].Value + "";

            HOADON Find = context.HOADONs.FirstOrDefault(p => p.MaHD == mhd);
            {
                if (Find != null)
                {
                    tbxMaHD.Text = Find.MaHD;
                    cbxMaKB.SelectedValue = Find.MaKB;
                    cbxHoTen.SelectedValue = Find.MaKB;
                    cbxThuoc.SelectedValue = Find.MaThuoc;
                    cbxDGThuoc.SelectedValue = Find.MaThuoc;
                    cbxDichVu.SelectedValue = Find.MaDV;
                    tbxSoLuong.Text = Find.SoLuongDV.ToString();
                    tbxThanhTien.Text = Find.ThanhTien.ToString();
                    dtpNgayLap.Text = Find.NgayLapHD.ToString();
                    tbxTrangThai.Text = Find.TinhTrang;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = tbxTimKiem.Text.Trim();
            BindGrid(context.HOADONs.Where(x => x.KHAMBENH.HoTen.Contains(keyword)).ToList());
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbxTimKiem.Clear();
            BindGrid(context.HOADONs.ToList());
        }

        private void frmVienPhi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
