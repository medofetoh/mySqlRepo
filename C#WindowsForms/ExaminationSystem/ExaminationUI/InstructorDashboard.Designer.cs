
namespace ExaminationUI
{
    partial class InstructorDashboard
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
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnGenrateExam = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCourses
            // 
            this.btnCourses.Location = new System.Drawing.Point(261, 69);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(153, 100);
            this.btnCourses.TabIndex = 1;
            this.btnCourses.Text = "Courses";
            this.btnCourses.UseVisualStyleBackColor = true;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnGenrateExam
            // 
            this.btnGenrateExam.Location = new System.Drawing.Point(12, 69);
            this.btnGenrateExam.Name = "btnGenrateExam";
            this.btnGenrateExam.Size = new System.Drawing.Size(153, 100);
            this.btnGenrateExam.TabIndex = 2;
            this.btnGenrateExam.Text = "Genrate Exam";
            this.btnGenrateExam.UseVisualStyleBackColor = true;
            this.btnGenrateExam.Click += new System.EventHandler(this.btnGenrateExam_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(523, 69);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(153, 100);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "LogOut";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // InstructorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 284);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnGenrateExam);
            this.Controls.Add(this.btnCourses);
            this.Name = "InstructorDashboard";
            this.Text = "InstructorDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnGenrateExam;
        private System.Windows.Forms.Button btnLogout;
    }
}