using BLL.EntityManager;
using System;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class InstructorLogin : Form
    {
        public InstructorLogin()
        {
            InitializeComponent();
        }
        InstructorManager manager = InstructorManager.getInstance();
        private void button1_Click(object sender, EventArgs e)
        {
            if (manager.Login(emailTxt.Text, passwordTxt.Text))
            {
                this.Hide();
                InstructorDashboard instDashboard = new InstructorDashboard();
                instDashboard.FormClosed += (e, sender) => this.Close();
                instDashboard.Show();
            }
            else
                MessageBox.Show("Invaild data", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChooseLogin cL = new ChooseLogin();
            cL.FormClosed += (e, sender) => this.Close();
            cL.Show();
        }
    }
}
