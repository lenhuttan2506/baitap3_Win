using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Bai3_LTMTW
{
    public partial class FormList : Form
    {

        BindingList<NhanVien> nhanviens;
        private string selectedMsnv;
        public FormList()
        {
            InitializeComponent();
            nhanviens = new BindingList<NhanVien>();
            dtgv_NhanVien.DataSource = nhanviens;
        }

        public void AddNhanVien(NhanVien newNhanVien)
        {
            nhanviens.Add(newNhanVien);
        }

        public void EditNhanVien(string msnv)
        {
            var nhanvienToEdit = nhanviens.FirstOrDefault(nv => nv.Msnv == msnv);

            if (nhanvienToEdit != null)
            {
                FormNhanVien formNhanVien = new FormNhanVien(this, nhanvienToEdit);
                formNhanVien.ShowDialog();

            }
            else
            {
                MessageBox.Show("Employee not found!");
            }
        }

        public void UpdateNhanVien(NhanVien updatedNhanVien)
        {
            var nhanvienToUpdate = nhanviens.FirstOrDefault(nv => nv.Msnv == updatedNhanVien.Msnv);
            if (nhanvienToUpdate != null)
            {
                nhanvienToUpdate.TenNhanVien = updatedNhanVien.TenNhanVien;
                nhanvienToUpdate.Luong = updatedNhanVien.Luong;
                dtgv_NhanVien.Refresh(); 
            }
        }


        private void btn_Them_Click(object sender, EventArgs e)
        {
            FormNhanVien form = new FormNhanVien(this);
            form.ShowDialog();
        }

        private void FormList_Load(object sender, EventArgs e)
        {
            if (dtgv_NhanVien.Columns.Count == 0)
            {
                dtgv_NhanVien.Columns.Add("Msnv", "MSNV");
                dtgv_NhanVien.Columns.Add("TenNhanVien", "Tên nhân viên");
                dtgv_NhanVien.Columns.Add("Luong", "Lương");
            }
        }



        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string msnv = selectedMsnv;
            EditNhanVien(selectedMsnv);
        }

        private void dtgv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                selectedMsnv = dtgv_NhanVien.Rows[e.RowIndex].Cells["Msnv"].Value.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            
                string msnv = selectedMsnv;
                var nhanvienToDelete = nhanviens.FirstOrDefault(nv => nv.Msnv == msnv);
                if (nhanvienToDelete != null)
                {
                    nhanviens.Remove(nhanvienToDelete);
                    dtgv_NhanVien.Refresh();
                }
            
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
