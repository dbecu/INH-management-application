namespace SomerenUI
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SomerenUI));

            this.lbl_Errors = new System.Windows.Forms.Label();
            this.listBoxError = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbl_Errors
            // 
            this.lbl_Errors.AutoSize = true;
            this.lbl_Errors.Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);
            this.lbl_Errors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_Errors.Location = new System.Drawing.Point(41, 32);
            this.lbl_Errors.Name = "lbl_Errors";
            this.lbl_Errors.Size = new System.Drawing.Size(34, 13);
            this.lbl_Errors.TabIndex = 1;
            this.lbl_Errors.Text = "Errors";
            this.lbl_Errors.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxError
            // 
            this.listBoxError.FormattingEnabled = true;
            this.listBoxError.Location = new System.Drawing.Point(44, 80);
            this.listBoxError.Name = "listBoxError";
            this.listBoxError.Size = new System.Drawing.Size(450, 238);
            this.listBoxError.TabIndex = 2;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 343);
            this.Controls.Add(this.listBoxError);
            this.Controls.Add(this.lbl_Errors);
            this.Name = "ErrorForm";
            this.Text = "ErrorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SomerenApp Errors";
            this.Text = "SomerenApp Errors";

        }

        #endregion
        private System.Windows.Forms.Label lbl_Errors;
        private System.Windows.Forms.ListBox listBoxError;
    }
}