﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lbregister_Click(object sender, EventArgs e)
        {
            Registration newform = new Registration();
            newform.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
