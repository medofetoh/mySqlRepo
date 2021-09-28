
namespace ExaminationUI
{
    partial class InsGenerateExam
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboCourseList = new System.Windows.Forms.ComboBox();
            this.comboExamType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePExam = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Courses List";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboCourseList
            // 
            this.comboCourseList.FormattingEnabled = true;
            this.comboCourseList.Location = new System.Drawing.Point(215, 88);
            this.comboCourseList.Name = "comboCourseList";
            this.comboCourseList.Size = new System.Drawing.Size(151, 28);
            this.comboCourseList.TabIndex = 1;
            // 
            // comboExamType
            // 
            this.comboExamType.FormattingEnabled = true;
            this.comboExamType.Location = new System.Drawing.Point(215, 147);
            this.comboExamType.Name = "comboExamType";
            this.comboExamType.Size = new System.Drawing.Size(151, 28);
            this.comboExamType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Exam Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exam Date";
            // 
            // dateTimePExam
            // 
            this.dateTimePExam.Location = new System.Drawing.Point(215, 206);
            this.dateTimePExam.Name = "dateTimePExam";
            this.dateTimePExam.Size = new System.Drawing.Size(250, 27);
            this.dateTimePExam.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(424, 287);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(94, 29);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate Exam";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 287);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 29);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // InsGenerateExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 341);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dateTimePExam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboExamType);
            this.Controls.Add(this.comboCourseList);
            this.Controls.Add(this.label1);
            this.Name = "InsGenerateExam";
            this.Text = "InsGenerateExam";
            this.Load += new System.EventHandler(this.InsGenerateExam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCourseList;
        private System.Windows.Forms.ComboBox comboExamType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePExam;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnBack;
    }
}