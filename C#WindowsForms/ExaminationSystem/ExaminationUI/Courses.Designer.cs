
namespace ExaminationUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.coursesGrdview = new System.Windows.Forms.DataGridView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.coursesGrdview)).BeginInit();
            this.SuspendLayout();
            // 
            // coursesGrdview
            // 
            this.coursesGrdview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coursesGrdview.Location = new System.Drawing.Point(3, 2);
            this.coursesGrdview.Name = "coursesGrdview";
            this.coursesGrdview.RowHeadersWidth = 51;
            this.coursesGrdview.RowTemplate.Height = 29;
            this.coursesGrdview.Size = new System.Drawing.Size(1203, 418);
            this.coursesGrdview.TabIndex = 0;
            this.coursesGrdview.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.coursesGrdview_UserAddedRow);
            this.coursesGrdview.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.coursesGrdview_UserDeletingRow);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(1103, 446);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(94, 29);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 446);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 29);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 508);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.coursesGrdview);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coursesGrdview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView coursesGrdview;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button btnBack;
    }
}

