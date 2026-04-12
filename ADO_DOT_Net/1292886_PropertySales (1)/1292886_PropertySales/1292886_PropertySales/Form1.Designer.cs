namespace _1292886_PropertySales
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSaveSale = new System.Windows.Forms.Button();
            this.txtPaid = new System.Windows.Forms.CheckBox();
            this.txtSaleDate = new System.Windows.Forms.DateTimePicker();
            this.txtPayment = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtcancel = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtBrowse = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSaveProperty = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtProperty = new System.Windows.Forms.TextBox();
            this.dgvProperty = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.dgvSalesWise = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesWise)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSaveSale);
            this.groupBox1.Controls.Add(this.txtPaid);
            this.groupBox1.Controls.Add(this.txtSaleDate);
            this.groupBox1.Controls.Add(this.txtPayment);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales";
            // 
            // txtSaveSale
            // 
            this.txtSaveSale.Location = new System.Drawing.Point(289, 164);
            this.txtSaveSale.Name = "txtSaveSale";
            this.txtSaveSale.Size = new System.Drawing.Size(74, 26);
            this.txtSaveSale.TabIndex = 5;
            this.txtSaveSale.Text = "Save...";
            this.txtSaveSale.UseVisualStyleBackColor = true;
            this.txtSaveSale.Click += new System.EventHandler(this.txtSaveSale_Click);
            // 
            // txtPaid
            // 
            this.txtPaid.AutoSize = true;
            this.txtPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(90, 173);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(82, 20);
            this.txtPaid.TabIndex = 4;
            this.txtPaid.Text = "Is Paid?";
            this.txtPaid.UseVisualStyleBackColor = true;
            // 
            // txtSaleDate
            // 
            this.txtSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleDate.Location = new System.Drawing.Point(134, 145);
            this.txtSaleDate.Name = "txtSaleDate";
            this.txtSaleDate.Size = new System.Drawing.Size(100, 22);
            this.txtSaleDate.TabIndex = 3;
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.FormattingEnabled = true;
            this.txtPayment.Location = new System.Drawing.Point(134, 118);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(100, 24);
            this.txtPayment.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(134, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(134, 57);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 22);
            this.txtPhone.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(134, 84);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPrice.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sales Date : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Status :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mobile No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Price :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Payment Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Name :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtcancel);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.txtBrowse);
            this.groupBox2.Controls.Add(this.txtImage);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(387, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 205);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client Image";
            // 
            // txtcancel
            // 
            this.txtcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcancel.Location = new System.Drawing.Point(83, 172);
            this.txtcancel.Name = "txtcancel";
            this.txtcancel.Size = new System.Drawing.Size(64, 23);
            this.txtcancel.TabIndex = 5;
            this.txtcancel.Text = "Cancel...";
            this.txtcancel.UseVisualStyleBackColor = true;
            this.txtcancel.Click += new System.EventHandler(this.txtcancel_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(395, 424);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 27);
            this.button4.TabIndex = 5;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtBrowse
            // 
            this.txtBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrowse.Location = new System.Drawing.Point(6, 172);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.Size = new System.Drawing.Size(71, 23);
            this.txtBrowse.TabIndex = 5;
            this.txtBrowse.Text = "Browse...";
            this.txtBrowse.UseVisualStyleBackColor = true;
            this.txtBrowse.Click += new System.EventHandler(this.txtBrowse_Click);
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(6, 23);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(141, 142);
            this.txtImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.txtImage.TabIndex = 0;
            this.txtImage.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSaveProperty);
            this.groupBox3.Controls.Add(this.txtLocation);
            this.groupBox3.Controls.Add(this.txtProperty);
            this.groupBox3.Controls.Add(this.dgvProperty);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(546, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 205);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Property";
            // 
            // txtSaveProperty
            // 
            this.txtSaveProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaveProperty.Location = new System.Drawing.Point(214, 45);
            this.txtSaveProperty.Name = "txtSaveProperty";
            this.txtSaveProperty.Size = new System.Drawing.Size(76, 32);
            this.txtSaveProperty.TabIndex = 5;
            this.txtSaveProperty.Text = "Save..";
            this.txtSaveProperty.UseVisualStyleBackColor = true;
            this.txtSaveProperty.Click += new System.EventHandler(this.txtSaveProperty_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(116, 58);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(84, 22);
            this.txtLocation.TabIndex = 1;
            // 
            // txtProperty
            // 
            this.txtProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProperty.Location = new System.Drawing.Point(9, 56);
            this.txtProperty.Name = "txtProperty";
            this.txtProperty.Size = new System.Drawing.Size(95, 22);
            this.txtProperty.TabIndex = 1;
            // 
            // dgvProperty
            // 
            this.dgvProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperty.Location = new System.Drawing.Point(9, 90);
            this.dgvProperty.Name = "dgvProperty";
            this.dgvProperty.Size = new System.Drawing.Size(292, 109);
            this.dgvProperty.TabIndex = 0;
            this.dgvProperty.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperty_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(130, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Location ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Property Type ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSales);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 240);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sales List";
            // 
            // dgvSales
            // 
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Location = new System.Drawing.Point(6, 23);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.Size = new System.Drawing.Size(516, 211);
            this.dgvSales.TabIndex = 0;
            this.dgvSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellContentClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnViewReport);
            this.groupBox5.Controls.Add(this.dgvSalesWise);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(546, 246);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(307, 240);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sales Wise Property";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(214, 204);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(87, 30);
            this.btnViewReport.TabIndex = 5;
            this.btnViewReport.Text = "Report...";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // dgvSalesWise
            // 
            this.dgvSalesWise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesWise.Location = new System.Drawing.Point(6, 23);
            this.dgvSalesWise.Name = "dgvSalesWise";
            this.dgvSalesWise.Size = new System.Drawing.Size(295, 175);
            this.dgvSalesWise.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(305, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(235, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Property Sales Management";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 489);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Property Sales Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesWise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox txtImage;
        private System.Windows.Forms.DataGridView dgvProperty;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridView dgvSalesWise;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtProperty;
        private System.Windows.Forms.Button txtSaveSale;
        private System.Windows.Forms.CheckBox txtPaid;
        private System.Windows.Forms.DateTimePicker txtSaleDate;
        private System.Windows.Forms.ComboBox txtPayment;
        private System.Windows.Forms.Button txtBrowse;
        private System.Windows.Forms.Button txtSaveProperty;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button txtcancel;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
    }
}

