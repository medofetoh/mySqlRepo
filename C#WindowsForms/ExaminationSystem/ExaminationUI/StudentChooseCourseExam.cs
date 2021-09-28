using BLL.Entities;
using BLL.EntityList;
using BLL.EntityLists;
using BLL.EntityManager;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class StudentChooseCourseExam : Form
    {

        ExamManager ex = ExamManager.getInstance();
        CoursesList Courses;
        ExamsList exams;
        BindingSource CrsBindingSource, ExamsBindingSource;
        bool flag=false;

        public StudentChooseCourseExam()
        {
            InitializeComponent();
        }

        private void StudentChooseCourseExam_Load(object sender, EventArgs e)
        {
            Courses = ex.SelectCoursesExams();

            CrsBindingSource = new BindingSource(Courses, "");

            comboBoxCourses.DataSource = CrsBindingSource;
            comboBoxCourses.DisplayMember = "CourseName";
            comboBoxCourses.ValueMember = "CourseID";

            ex.CourseID = comboBoxCourses.SelectedValue.ToString();
            exams = ex.SelectCoursesSpecificExam();
            if (exams.Count == 0)
            {
                availableExams.Enabled = false;
                flag = true;
            }
            else
            {
                ExamsBindingSource = new BindingSource(exams, "");
                availableExams.DataSource = ExamsBindingSource;
                availableExams.DisplayMember = "ExamDatetime";
                availableExams.ValueMember = "ExamID";
                flag = false;
            }


        }

        private void btnSelectCourse_Click(object sender, EventArgs e)
        {
            string selectedExam = availableExams.SelectedValue.ToString();

            if (availableExams.Enabled)
            {
                int tempInt;
                if (int.TryParse(selectedExam ?? "NA", out tempInt))
                    ex.ExamID = tempInt;
                this.Hide();
                StExamRetrival exam = new StExamRetrival();
                exam.FormClosed += (e, sender) => this.Close();
                exam.Show();
            }
            else
            {
                MessageBox.Show("no Avialable exams", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void comboBoxCourses_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedCourse = comboBoxCourses.SelectedValue.ToString();
            ex.CourseID = selectedCourse;
            exams = ex.SelectCoursesSpecificExam();

            if (exams.Count == 0)
            {
                availableExams.Enabled = false;
                
                if (flag)
                {
                    ExamsBindingSource.Clear();
                    availableExams.Items.Clear();
                    flag = true;
                }
                    
            }
            else
            {
                availableExams.Enabled = true;
                ExamsBindingSource = new BindingSource(exams, "");
                availableExams.DataSource = ExamsBindingSource;
                availableExams.DisplayMember = "ExamDatetime";
                availableExams.ValueMember = "ExamID";
                flag = false;

            }

        }

    }
}
