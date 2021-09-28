using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class StudentLogin : Form
    {
        public StudentLogin()
        {
            InitializeComponent();
        }
        StudentManager stud = StudentManager.getInstance();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChooseLogin cL = new ChooseLogin();
            cL.FormClosed += (e, sender) => this.Close();
            cL.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stud.Login(emailTxt.Text, passwordTxt.Text) > 0)
            {
                this.Hide();
                StudentChooseCourseExam stExam = new StudentChooseCourseExam();
                stExam.FormClosed += (e, sender) => this.Close();
                stExam.Show();

            }
            else
                MessageBox.Show("Invaild data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
