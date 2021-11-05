using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentBC
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            lbCheckPass.Visible = false;
        }
        DataHandler dh = new DataHandler();
        FileHandler fh = new FileHandler();

        private void txtPasswordReg_TextChanged(object sender, EventArgs e)
        {
            lbCheckPass.Visible = true;
            if (txtPasswordReg.Text == txtConfirmPassword.Text)
            {
                lbCheckPass.ForeColor = Color.Green;
                lbCheckPass.Text = "Passwords match";
            }
            else
            {
                lbCheckPass.ForeColor = Color.Red;
                lbCheckPass.Text = "Passwords mismatch error, Re-try";
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            dh.AddUser(txtUsernameReg.Text, txtPasswordReg.Text);
            fh.Write(dh.Format());
            Close();
        }
    }
}
