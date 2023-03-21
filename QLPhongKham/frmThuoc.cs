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
    public partial class frmThuoc : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmThuoc()
        {
            InitializeComponent();
        }

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            try
            {
                List<THUOC> listThuoc = context.THUOCs.ToList();
                BindGrid(listThuoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<THUOC> listThuoc)
        {
            dgvQuanLyThuoc.Rows.Clear();
            foreach (var item in listThuoc)
            {
                int index = dgvQuanLyThuoc.Rows.Add();
                dgvQuanLyThuoc.Rows[index].Cells[0].Value = item.MaThuoc;
                dgvQuanLyThuoc.Rows[index].Cells[1].Value = item.TenThuoc;
                dgvQuanLyThuoc.Rows[index].Cells[2].Value = item.HSD;
                dgvQuanLyThuoc.Rows[index].Cells[3].Value = item.DonGia;
                dgvQuanLyThuoc.Rows[index].Cells[4].Value = item.SoLuongCon;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxMaThuoc.Text == "" || tbxTenThuoc.Text == "" || tbxHSD.Text == "" || tbxDonGia.Text == "" || tbxSoLuongCon.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxMaThuoc.Text.Length > 5)
                {
                    throw new Exception("Mã thuốc không quá 5 kí tự!");
                }

                THUOC Find = context.THUOCs.FirstOrDefault(x => x.MaThuoc == tbxMaThuoc.Text);
                if (Find == null)
                {
                    Find = new THUOC();
                    Find.MaThuoc = tbxMaThuoc.Text;
                    Find.TenThuoc = tbxTenThuoc.Text;
                    Find.HSD = tbxHSD.Text;
                    Find.DonGia = float.Parse(tbxDonGia.Text);
                    Find.SoLuongCon = int.Parse(tbxSoLuongCon.Text);
                    context.THUOCs.Add(Find);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaThuoc.Clear();
                    tbxTenThuoc.Clear();
                    tbxDonGia.Clear();
                    tbxHSD.Clear();
                    tbxSoLuongCon.Clear();
                }
                else
                {
                    Find.TenThuoc = tbxTenThuoc.Text;
                    Find.HSD = tbxHSD.Text;
                    Find.DonGia = float.Parse(tbxDonGia.Text);
                    Find.SoLuongCon = int.Parse(tbxSoLuongCon.Text);
                    DialogResult dlr = MessageBox.Show("Xác nhận sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxMaThuoc.Clear();
                        tbxTenThuoc.Clear();
                        tbxDonGia.Clear();
                        tbxHSD.Clear();
                        tbxSoLuongCon.Clear();
                    }
                }
                BindGrid(context.THUOCs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            THUOC Find = context.THUOCs.FirstOrDefault(x => x.MaThuoc == tbxMaThuoc.Text);
            if (Find == null)
            {
                MessageBox.Show("Không tìm thấy thuốc cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.THUOCs.Remove(Find);
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaThuoc.Clear();
                    tbxTenThuoc.Clear();
                    tbxDonGia.Clear();
                    tbxHSD.Clear();
                    tbxSoLuongCon.Clear();
                }
            }
            BindGrid(context.THUOCs.ToList());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmTrangChu formChinh = new frmTrangChu();
            this.Hide();
            formChinh.ShowDialog();
        }

        private void dgvQuanLyThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mt = dgvQuanLyThuoc.Rows[e.RowIndex].Cells[0].Value + "";
            THUOC Find = context.THUOCs.FirstOrDefault(p => p.MaThuoc == mt);
            {
                if (Find != null)
                {
                    tbxMaThuoc.Text = Find.MaThuoc;
                    tbxTenThuoc.Text = Find.TenThuoc;
                    tbxHSD.Text = Find.HSD;
                    tbxDonGia.Text = Find.DonGia.ToString();
                    tbxSoLuongCon.Text = Find.SoLuongCon.ToString();
                }
            }
        }

        private void frmThuoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
