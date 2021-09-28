using BLL.Entities;
using BLL.EntityList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class InsGenerateExam : Form
    {
        CourseManager crs = CourseManager.getInstance();
        CoursesList Courses;
        BindingSource CrsBindingSource;
        List<string> examType;
        public InsGenerateExam()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InsGenerateExam_Load(object sender, EventArgs e)
        {
            Courses = crs.SelectAllCourses();
            examType = new List<string>();
            examType.Add("Final");
            examType.Add("Practical");
            CrsBindingSource = new BindingSource(Courses, "");

            comboCourseList.DataSource = CrsBindingSource;
            comboCourseList.DisplayMember = "CourseName";
            comboCourseList.ValueMember = "CourseID";
            comboExamType.DataSource = examType;


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (crs.InsGenerateExam(comboCourseList.SelectedValue.ToString()
                , dateTimePExam.Value.ToString()
                , comboExamType.SelectedValue.ToString()))
            {
                MessageBox.Show("Generated ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                Trace.WriteLine("something went wrong......");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorDashboard instDashboard = new InstructorDashboard();
            instDashboard.FormClosed += (e, sender) => this.Close();
            instDashboard.Show();
        }
    }
}
