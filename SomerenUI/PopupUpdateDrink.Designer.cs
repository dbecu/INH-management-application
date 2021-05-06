namespace SomerenUI{    partial class PopupUpdateDrink    {
        /// <summary>        /// Required designer variable.        /// </summary>        private System.ComponentModel.IContainer components = null;

        /// <summary>        /// Clean up any resources being used.        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        protected override void Dispose(bool disposing)        {            if (disposing && (components != null))            {                components.Dispose();            }            base.Dispose(disposing);        }


        #region Windows Form Designer generated code
        /// <summary>        /// Required method for Designer support - do not modify        /// the contents of this method with the code editor.        /// </summary>        private void InitializeComponent()        {            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.lbl_Amountsold = new System.Windows.Forms.Label();
            this.btn_UpdateDrink = new System.Windows.Forms.Button();
            this.tb_Price = new System.Windows.Forms.TextBox();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.tb_Amount_Stock = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit the fields of the drink which you want  to update ";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(45, 61);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_Price
            // 
            this.lbl_Price.AutoSize = true;
            this.lbl_Price.Location = new System.Drawing.Point(45, 95);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(31, 13);
            this.lbl_Price.TabIndex = 0;
            this.lbl_Price.Text = "Price";
            // 
            // lbl_Amountsold
            // 
            this.lbl_Amountsold.AutoSize = true;
            this.lbl_Amountsold.Location = new System.Drawing.Point(45, 134);
            this.lbl_Amountsold.Name = "lbl_Amountsold";
            this.lbl_Amountsold.Size = new System.Drawing.Size(85, 13);
            this.lbl_Amountsold.TabIndex = 0;
            this.lbl_Amountsold.Text = "Amount in Stock";
            // 
            // btn_UpdateDrink
            // 
            this.btn_UpdateDrink.Location = new System.Drawing.Point(99, 176);
            this.btn_UpdateDrink.Name = "btn_UpdateDrink";
            this.btn_UpdateDrink.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateDrink.TabIndex = 2;
            this.btn_UpdateDrink.Text = "Update";
            this.btn_UpdateDrink.UseVisualStyleBackColor = true;
            this.btn_UpdateDrink.Click += new System.EventHandler(this.btn_UpdateDrink_Click);
            // 
            // tb_Price
            // 
            this.tb_Price.Location = new System.Drawing.Point(138, 95);
            this.tb_Price.Name = "tb_Price";
            this.tb_Price.Size = new System.Drawing.Size(100, 20);
            this.tb_Price.TabIndex = 3;
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(138, 58);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(100, 20);
            this.tb_Name.TabIndex = 5;
            // 
            // tb_Amount_Stock
            // 
            this.tb_Amount_Stock.Location = new System.Drawing.Point(138, 126);
            this.tb_Amount_Stock.Name = "tb_Amount_Stock";
            this.tb_Amount_Stock.Size = new System.Drawing.Size(100, 20);
            this.tb_Amount_Stock.TabIndex = 6;
            // 
            // PopupUpdateDrink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 235);
            this.Controls.Add(this.tb_Amount_Stock);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.tb_Price);
            this.Controls.Add(this.btn_UpdateDrink);
            this.Controls.Add(this.lbl_Amountsold);
            this.Controls.Add(this.lbl_Price);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.label1);
            this.Name = "PopupUpdateDrink";
            this.Text = "PopupUpdateDrink";
            this.Load += new System.EventHandler(this.PopupUpdateDrink_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label label1;        private System.Windows.Forms.Label lbl_Name;        private System.Windows.Forms.Label lbl_Price;        private System.Windows.Forms.Label lbl_Amountsold;        private System.Windows.Forms.Button btn_UpdateDrink;        private System.Windows.Forms.TextBox tb_Price;        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TextBox tb_Amount_Stock;
    }}