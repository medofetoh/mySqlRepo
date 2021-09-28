
namespace ExaminationUI
{
    partial class Results
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
            this.resultValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.homeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultValue
            // 
            this.resultValue.AutoSize = true;
            this.resultValue.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultValue.ForeColor = System.Drawing.Color.Lime;
            this.resultValue.Location = new System.Drawing.Point(164, 143);
            this.resultValue.Name = "resultValue";
            this.resultValue.Size = new System.Drawing.Size(268, 112);
            this.resultValue.TabIndex = 0;
            this.resultValue.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(438, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "/";
            // 
            // totalValue
            // 
            this.totalValue.AutoSize = true;
            this.totalValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalValue.Location = new System.Drawing.Point(477, 189);
            this.totalValue.Name = "totalValue";
            this.totalValue.Size = new System.Drawing.Size(130, 54);
            this.totalValue.TabIndex = 2;
            this.totalValue.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "your results is";
            // 
            // homeBtn
            // 
            this.homeBtn.Location = new System.Drawing.Point(694, 409);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(94, 29);
            this.homeBtn.TabIndex = 5;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultValue);
            this.Name = "Results";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.Results_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button homeBtn;
    }
}