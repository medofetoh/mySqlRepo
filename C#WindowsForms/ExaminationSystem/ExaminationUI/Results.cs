using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }
        ExamManager ex = ExamManager.getInstance();
        private void Results_Load(object sender, EventArgs e)
        {
            resultValue.Text = ex.sumOfMarksPerCourse(StudentManager.getInstance().StudentID).ToString();
            totalValue.Text = ex.courseFullMark().ToString();

        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentChooseCourseExam st = new StudentChooseCourseExam();
            st.FormClosed += (e, sender) => this.Close();
            st.Show();
        }
    }
}
