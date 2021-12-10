using DemoLINQToEF.BLL;
using DemoLINQToEF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLINQToEF
{
    public partial class Form1 : Form
    {
        // kbao object from BLL
        NhanVienService nv = new NhanVienService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvNV.DataSource = nv.getAllNhanVien();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            NhanVienModel nvObj = new NhanVienModel();
            nvObj.HoNV = txtHoNV.Text;
            nvObj.TenNV = txtTenNV.Text;
            nvObj.Luong = float.Parse(txtLuong.Text);
            nvObj.MaCV = txtMaCV.Text;
            nvObj.MaBP = txtMaBP.Text;

            nv.InsertNV(nvObj);
            dgvNV.DataSource = nv.getAllNhanVien(); // reload NV
            MessageBox.Show("Insert Success!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Enter MaNV!");
                return;
            }
            NhanVienModel nvObj = new NhanVienModel();

            nvObj.MaNV = txtMaNV.Text;
            nvObj.HoNV = txtHoNV.Text;
            nvObj.TenNV = txtTenNV.Text;
            nvObj.Luong = float.Parse(txtLuong.Text);
            nvObj.MaCV = txtMaCV.Text;
            nvObj.MaBP = txtMaBP.Text;

            nv.UpdateNV(nvObj);
            dgvNV.DataSource = nv.getAllNhanVien(); // reload NV
            MessageBox.Show("Update Success!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Enter MaNV!");
                return;
            }

            nv.DeleteNV(txtMaNV.Text);
            dgvNV.DataSource = nv.getAllNhanVien(); // reload NV
            MessageBox.Show("Delete Success!");
        }
    }
}
