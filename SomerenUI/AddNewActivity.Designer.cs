namespace SomerenUI
{
    partial class AddNewActivity
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Description = new System.Windows.Forms.TextBox();
            this.tb_NrOfStudents = new System.Windows.Forms.TextBox();
            this.tb_NrOfSupervisors = new System.Windows.Forms.TextBox();
            this.btn_AddActivity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a new activity by enetering the following fields";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nr. Of Students";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nr. Of Supervisors";
            // 
            // tb_Description
            // 
            this.tb_Description.Location = new System.Drawing.Point(154, 58);
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(141, 20);
            this.tb_Description.TabIndex = 4;
            // 
            // tb_NrOfStudents
            // 
            this.tb_NrOfStudents.Location = new System.Drawing.Point(154, 92);
            this.tb_NrOfStudents.Name = "tb_NrOfStudents";
            this.tb_NrOfStudents.Size = new System.Drawing.Size(141, 20);
            this.tb_NrOfStudents.TabIndex = 5;
            // 
            // tb_NrOfSupervisors
            // 
            this.tb_NrOfSupervisors.Location = new System.Drawing.Point(154, 133);
            this.tb_NrOfSupervisors.Name = "tb_NrOfSupervisors";
            this.tb_NrOfSupervisors.Size = new System.Drawing.Size(141, 20);
            this.tb_NrOfSupervisors.TabIndex = 6;
            // 
            // btn_AddActivity
            // 
            this.btn_AddActivity.Location = new System.Drawing.Point(90, 186);
            this.btn_AddActivity.Name = "btn_AddActivity";
            this.btn_AddActivity.Size = new System.Drawing.Size(131, 23);
            this.btn_AddActivity.TabIndex = 7;
            this.btn_AddActivity.Text = "Add";
            this.btn_AddActivity.UseVisualStyleBackColor = true;
            this.btn_AddActivity.Click += new System.EventHandler(this.btn_AddActivity_Click);
            // 
            // AddNewActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 269);
            this.Controls.Add(this.btn_AddActivity);
            this.Controls.Add(this.tb_NrOfSupervisors);
            this.Controls.Add(this.tb_NrOfStudents);
            this.Controls.Add(this.tb_Description);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNewActivity";
            this.Text = "AddNewActivity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Description;
        private System.Windows.Forms.TextBox tb_NrOfStudents;
        private System.Windows.Forms.TextBox tb_NrOfSupervisors;
        private System.Windows.Forms.Button btn_AddActivity;
    }
}