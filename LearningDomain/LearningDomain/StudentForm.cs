﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningDomain
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Welcome myWelcome = new Welcome();
            myWelcome.Show();
            this.Hide();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
