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
    public partial class frmDichVu : Form
    {
        QuanLyPK_DB context = new QuanLyPK_DB();
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                List<DICHVU> listDichVu = context.DICHVUs.ToList();
                BindGrid(listDichVu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<DICHVU> listDichVu)
        {
            dgvQuanLyDV.Rows.Clear();
            foreach (var item in listDichVu)
            {
                int index = dgvQuanLyDV.Rows.Add();
                dgvQuanLyDV.Rows[index].Cells[0].Value = item.MaDV;
                dgvQuanLyDV.Rows[index].Cells[1].Value = item.TenDV;
                dgvQuanLyDV.Rows[index].Cells[2].Value = item.DonGia;
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxMaDV.Text == "" || tbxTenDV.Text == "" || tbxDonGia.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }
                if (tbxMaDV.Text.Length > 5)
                {
                    throw new Exception("Mã DV không quá 5 kí tự!");
                }

                DICHVU Find = context.DICHVUs.FirstOrDefault(x => x.MaDV == tbxMaDV.Text);
                if (Find == null)
                {
                    Find = new DICHVU();
                    Find.MaDV = tbxMaDV.Text;
                    Find.TenDV = tbxTenDV.Text;
                    Find.DonGia = float.Parse(tbxDonGia.Text);
                    context.DICHVUs.Add(Find);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaDV.Clear();
                    tbxTenDV.Clear();
                    tbxDonGia.Clear();
                }
                else
                {
                    Find.TenDV = tbxTenDV.Text;
                    Find.DonGia = float.Parse(tbxDonGia.Text);
                    DialogResult dlr = MessageBox.Show("Xác nhận sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxMaDV.Clear();
                        tbxTenDV.Clear();
                        tbxDonGia.Clear();
                    }
                }
                BindGrid(context.DICHVUs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DICHVU Find = context.DICHVUs.FirstOrDefault(x => x.MaDV == tbxMaDV.Text);
            if (Find == null)
            {
                MessageBox.Show("Không tìm thấy dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                context.DICHVUs.Remove(Find);
                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    context.SaveChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxMaDV.Clear();
                    tbxTenDV.Clear();
                    tbxDonGia.Clear();
                }
            }
            BindGrid(context.DICHVUs.ToList());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmTrangChu formChinh = new frmTrangChu();
            this.Hide();
            formChinh.ShowDialog();
        }

        private void dgvQuanLyDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mdv = dgvQuanLyDV.Rows[e.RowIndex].Cells[0].Value + "";
            DICHVU Find = context.DICHVUs.FirstOrDefault(p => p.MaDV == mdv);
            {
                if (Find != null)
                {
                    tbxMaDV.Text = Find.MaDV;
                    tbxTenDV.Text = Find.TenDV;
                    tbxDonGia.Text = Find.DonGia.ToString();
                }
            }
        }

        private void frmDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
