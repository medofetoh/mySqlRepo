
namespace ExaminationUI
{
    partial class StudentChooseCourseExam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxCourses = new System.Windows.Forms.ComboBox();
            this.btnSelectCourse = new System.Windows.Forms.Button();
            this.availableExams = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxCourses
            // 
            this.comboBoxCourses.FormattingEnabled = true;
            this.comboBoxCourses.Location = new System.Drawing.Point(59, 127);
            this.comboBoxCourses.Name = "comboBoxCourses";
            this.comboBoxCourses.Size = new System.Drawing.Size(232, 28);
            this.comboBoxCourses.TabIndex = 0;
            this.comboBoxCourses.SelectedValueChanged += new System.EventHandler(this.comboBoxCourses_SelectedValueChanged);
            // 
            // btnSelectCourse
            // 
            this.btnSelectCourse.Location = new System.Drawing.Point(134, 360);
            this.btnSelectCourse.Name = "btnSelectCourse";
            this.btnSelectCourse.Size = new System.Drawing.Size(94, 29);
            this.btnSelectCourse.TabIndex = 1;
            this.btnSelectCourse.Text = "Enter Exam";
            this.btnSelectCourse.UseVisualStyleBackColor = true;
            this.btnSelectCourse.Click += new System.EventHandler(this.btnSelectCourse_Click);
            // 
            // availableExams
            // 
            this.availableExams.FormattingEnabled = true;
            this.availableExams.Location = new System.Drawing.Point(59, 204);
            this.availableExams.Name = "availableExams";
            this.availableExams.Size = new System.Drawing.Size(232, 28);
            this.availableExams.TabIndex = 2;
            // 
            // StudentChooseCourseExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 541);
            this.Controls.Add(this.availableExams);
            this.Controls.Add(this.btnSelectCourse);
            this.Controls.Add(this.comboBoxCourses);
            this.Name = "StudentChooseCourseExam";
            this.Text = "StudentChooseCourseExam";
            this.Load += new System.EventHandler(this.StudentChooseCourseExam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCourses;
        private System.Windows.Forms.Button btnSelectCourse;
        private System.Windows.Forms.ComboBox availableExams;
    }
}