namespace SomerenUI
{
    partial class PopupNewDrink
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbAlcoholic = new System.Windows.Forms.RadioButton();
            this.rbNonAlcoholic = new System.Windows.Forms.RadioButton();
            this.btnAddDrink = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVAT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Alcoholic";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(113, 141);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(153, 20);
            this.tbPrice.TabIndex = 9;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(113, 60);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(153, 20);
            this.tbName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Add a new drink by enetering the following fields";
            // 
            // rbAlcoholic
            // 
            this.rbAlcoholic.AutoSize = true;
            this.rbAlcoholic.Location = new System.Drawing.Point(113, 100);
            this.rbAlcoholic.Name = "rbAlcoholic";
            this.rbAlcoholic.Size = new System.Drawing.Size(43, 17);
            this.rbAlcoholic.TabIndex = 14;
            this.rbAlcoholic.TabStop = true;
            this.rbAlcoholic.Text = "Yes";
            this.rbAlcoholic.UseVisualStyleBackColor = true;
            this.rbAlcoholic.CheckedChanged += new System.EventHandler(this.rbAlcoholic_CheckedChanged);
            // 
            // rbNonAlcoholic
            // 
            this.rbNonAlcoholic.AutoSize = true;
            this.rbNonAlcoholic.Location = new System.Drawing.Point(180, 102);
            this.rbNonAlcoholic.Name = "rbNonAlcoholic";
            this.rbNonAlcoholic.Size = new System.Drawing.Size(39, 17);
            this.rbNonAlcoholic.TabIndex = 15;
            this.rbNonAlcoholic.TabStop = true;
            this.rbNonAlcoholic.Text = "No";
            this.rbNonAlcoholic.UseVisualStyleBackColor = true;
            this.rbNonAlcoholic.CheckedChanged += new System.EventHandler(this.rbNonAlcoholic_CheckedChanged);
            // 
            // btnAddDrink
            // 
            this.btnAddDrink.Location = new System.Drawing.Point(81, 223);
            this.btnAddDrink.Name = "btnAddDrink";
            this.btnAddDrink.Size = new System.Drawing.Size(138, 23);
            this.btnAddDrink.TabIndex = 16;
            this.btnAddDrink.Text = "Add ";
            this.btnAddDrink.UseVisualStyleBackColor = true;
            this.btnAddDrink.Click += new System.EventHandler(this.btnAddDrink_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "VAT";
            // 
            // tbVAT
            // 
            this.tbVAT.Location = new System.Drawing.Point(113, 180);
            this.tbVAT.Name = "tbVAT";
            this.tbVAT.Size = new System.Drawing.Size(153, 20);
            this.tbVAT.TabIndex = 18;
            this.tbVAT.ReadOnly = true;
            // 
            // AddNewDrink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 286);
            this.Controls.Add(this.tbVAT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddDrink);
            this.Controls.Add(this.rbNonAlcoholic);
            this.Controls.Add(this.rbAlcoholic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.Name = "AddNewDrink";
            this.Text = "PopupNewDrink";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbAlcoholic;
        private System.Windows.Forms.RadioButton rbNonAlcoholic;
        private System.Windows.Forms.Button btnAddDrink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVAT;
    }
}
