using System;
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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            TeacherForm myTeacherForm = new TeacherForm();
            myTeacherForm.Show();
            this.Hide();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            StudentForm myStudentForm = new StudentForm();
            myStudentForm.Show();
            this.Hide();
        }
    }
}
