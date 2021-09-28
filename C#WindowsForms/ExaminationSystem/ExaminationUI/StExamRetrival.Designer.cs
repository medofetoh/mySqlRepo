
namespace ExaminationUI
{
    partial class StExamRetrival
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
            this.questionBody = new System.Windows.Forms.Label();
            this.questionMarks = new System.Windows.Forms.Label();
            this.question2Marks = new System.Windows.Forms.Label();
            this.question2Body = new System.Windows.Forms.Label();
            this.questionChoices = new System.Windows.Forms.ComboBox();
            this.questionChoices2 = new System.Windows.Forms.ComboBox();
            this.next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionBody
            // 
            this.questionBody.AutoSize = true;
            this.questionBody.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.questionBody.Location = new System.Drawing.Point(49, 32);
            this.questionBody.Name = "questionBody";
            this.questionBody.Size = new System.Drawing.Size(65, 25);
            this.questionBody.TabIndex = 3;
            this.questionBody.Text = "label2";
            // 
            // questionMarks
            // 
            this.questionMarks.AutoSize = true;
            this.questionMarks.Location = new System.Drawing.Point(49, 66);
            this.questionMarks.Name = "questionMarks";
            this.questionMarks.Size = new System.Drawing.Size(48, 20);
            this.questionMarks.TabIndex = 4;
            this.questionMarks.Text = "Marks";
            // 
            // question2Marks
            // 
            this.question2Marks.AutoSize = true;
            this.question2Marks.Location = new System.Drawing.Point(49, 239);
            this.question2Marks.Name = "question2Marks";
            this.question2Marks.Size = new System.Drawing.Size(55, 20);
            this.question2Marks.TabIndex = 6;
            this.question2Marks.Text = "Marks: ";
            // 
            // question2Body
            // 
            this.question2Body.AutoSize = true;
            this.question2Body.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.question2Body.Location = new System.Drawing.Point(49, 205);
            this.question2Body.Name = "question2Body";
            this.question2Body.Size = new System.Drawing.Size(65, 25);
            this.question2Body.TabIndex = 5;
            this.question2Body.Text = "label2";
            // 
            // questionChoices
            // 
            this.questionChoices.FormattingEnabled = true;
            this.questionChoices.Location = new System.Drawing.Point(49, 103);
            this.questionChoices.Name = "questionChoices";
            this.questionChoices.Size = new System.Drawing.Size(151, 28);
            this.questionChoices.TabIndex = 7;
            // 
            // questionChoices2
            // 
            this.questionChoices2.FormattingEnabled = true;
            this.questionChoices2.Location = new System.Drawing.Point(49, 283);
            this.questionChoices2.Name = "questionChoices2";
            this.questionChoices2.Size = new System.Drawing.Size(151, 28);
            this.questionChoices2.TabIndex = 8;
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(965, 409);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(94, 29);
            this.next.TabIndex = 9;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // StExamRetrival
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 450);
            this.Controls.Add(this.next);
            this.Controls.Add(this.questionChoices2);
            this.Controls.Add(this.questionChoices);
            this.Controls.Add(this.question2Marks);
            this.Controls.Add(this.question2Body);
            this.Controls.Add(this.questionMarks);
            this.Controls.Add(this.questionBody);
            this.Name = "StExamRetrival";
            this.Text = "StExamRetrival";
            this.Load += new System.EventHandler(this.StExamRetrival_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label questionBody;
        private System.Windows.Forms.Label questionMarks;
        private System.Windows.Forms.Label question2Marks;
        private System.Windows.Forms.Label question2Body;
        private System.Windows.Forms.ComboBox questionChoices;
        private System.Windows.Forms.ComboBox questionChoices2;
        private System.Windows.Forms.Button next;
    }
}