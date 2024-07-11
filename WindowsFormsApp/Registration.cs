using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblName.Text = txtName.Text;
            lblMessage.Visible = true;
            txtName.Text = string.Empty;
            txtEmailID.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        public void ClearControls()
        {
            lblMessage.Visible = false;
            lblName.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmailID.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
    }
}
