using BLL.Entities;
using BLL.EntityList;
using BLL.EntityLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BindingSource CrsBindingSource, InstBindingSource;
        CourseManager crs = CourseManager.getInstance();
        CoursesList Courses;
        InstructorsList instructors;
        DataGridViewComboBoxColumn Dc;

        private void saveBtn_Click(object sender, EventArgs e)
        {
            coursesGrdview.EndEdit();
            foreach (var item in Courses)
            {
                Trace.WriteLine(item.State);
            }
        }

        private void coursesGrdview_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Course curs = e.Row.DataBoundItem as Course;
            curs.State = EntityState.Deleted;
            CrsBindingSource.SuspendBinding();
            e.Row.Visible = false;
            CrsBindingSource.ResumeBinding();
            e.Cancel = true;
        }

        private void coursesGrdview_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstructorDashboard instDashboard = new InstructorDashboard();
            instDashboard.FormClosed += (e, sender) => this.Close();
            instDashboard.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Courses = crs.SelectAllCourses();
            CrsBindingSource = new BindingSource(Courses, "");

            instructors = crs.SelectAllInstructors();
            InstBindingSource = new BindingSource(instructors, "");
            coursesGrdview.DataSource = CrsBindingSource;
            Dc = new DataGridViewComboBoxColumn();
            Dc.HeaderText = "Instructor";
            Dc.DataSource = InstBindingSource;
            Dc.DisplayMember = "FullName";
            Dc.ValueMember = "InstID";
            

            Dc.DataPropertyName = "InstID";

            coursesGrdview.Columns.Add(Dc);
            coursesGrdview.Columns["InstID"].Visible = false;

        }
    }
}
