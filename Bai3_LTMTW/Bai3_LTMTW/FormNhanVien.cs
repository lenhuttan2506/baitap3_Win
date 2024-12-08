using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Bai3_LTMTW
{
    public partial class FormNhanVien : Form
    {
        private FormList parentForm;
        private NhanVien currentNhanVien;
        public FormNhanVien()
        {
            InitializeComponent();
        }


        public FormNhanVien(FormList parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        public FormNhanVien(FormList parent, NhanVien nhanvien)
        {
            InitializeComponent();
            parentForm = parent;
            currentNhanVien = nhanvien;
            txb_msnv.Text = nhanvien.Msnv;
            txb_tennhanvien.Text = nhanvien.TenNhanVien;
            txb_Luong.Text = nhanvien.Luong.ToString();
        }


        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }
        private void btn_DongY_Click(object sender, EventArgs e)
        {
            if (currentNhanVien != null)
            {
                currentNhanVien.Msnv = txb_msnv.Text;
                currentNhanVien.TenNhanVien = txb_tennhanvien.Text;
                currentNhanVien.Luong = decimal.Parse(txb_Luong.Text);
                parentForm.UpdateNhanVien(currentNhanVien);
                this.Close();
            }
            else
            {
                NhanVien nhanvien = new NhanVien
                {
                    Msnv = txb_msnv.Text,
                    TenNhanVien = txb_tennhanvien.Text,
                    Luong = decimal.Parse(txb_Luong.Text)
                };

                parentForm.AddNhanVien(nhanvien);

                this.Close();
            }
        }

        private void btn_Boqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
