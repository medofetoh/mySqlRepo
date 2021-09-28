using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class ChooseLogin : Form
    {
        public ChooseLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorLogin isLogin = new InstructorLogin();
            isLogin.FormClosed += (e, sender) => this.Close();
            isLogin.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentLogin studLogin = new StudentLogin();
            studLogin.FormClosed += (e, sender) => this.Close();
            studLogin.Show();

        }
    }
}
