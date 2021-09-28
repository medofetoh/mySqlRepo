using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class InstructorDashboard : Form
    {
        public InstructorDashboard()
        {
            InitializeComponent();
        }

        private void btnGenrateExam_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsGenerateExam genExam = new InsGenerateExam();
            genExam.FormClosed += (e, sender) => this.Close();
            genExam.Show();

        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 crs = new Form1();
            crs.FormClosed += (e, sender) => this.Close();
            crs.Show();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorLogin insLogin = new InstructorLogin();
            insLogin.FormClosed += (e, sender) => this.Close();
            insLogin.Show();
        }
    }
}
