namespace Windows.Forms
{
    partial class frmProductsAE
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
            components = new System.ComponentModel.Container();
            cboCategories = new ComboBox();
            label2 = new Label();
            txtDescription = new TextBox();
            label1 = new Label();
            label3 = new Label();
            txtProductName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            numPrice = new NumericUpDown();
            numStock = new NumericUpDown();
            btnCancel = new Button();
            btnOk = new Button();
            errorProvider1 = new ErrorProvider(components);
            numReorderLevel = new NumericUpDown();
            label6 = new Label();
            numSalePrice = new NumericUpDown();
            label7 = new Label();
            Suspended = new Label();
            checkBoxSuspended = new CheckBox();
            picImage = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            btnSearchImages = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cboCategories
            // 
            cboCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategories.FormattingEnabled = true;
            cboCategories.ItemHeight = 32;
            cboCategories.Location = new Point(220, 224);
            cboCategories.Margin = new Padding(6);
            cboCategories.Name = "cboCategories";
            cboCategories.Size = new Size(327, 40);
            cboCategories.TabIndex = 2;
            cboCategories.SelectedIndexChanged += cboCategories_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 227);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 23;
            label2.Text = "Category: ";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(220, 155);
            txtDescription.Margin = new Padding(6);
            txtDescription.MaxLength = 50;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(610, 39);
            txtDescription.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 158);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 32);
            label1.TabIndex = 22;
            label1.Text = "Description: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 379);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(131, 32);
            label3.TabIndex = 26;
            label3.Text = "Cost Price: ";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(220, 76);
            txtProductName.Margin = new Padding(6);
            txtProductName.MaxLength = 50;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(327, 39);
            txtProductName.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 79);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(179, 32);
            label4.TabIndex = 28;
            label4.Text = "Prodcut Name: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(128, 310);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(83, 32);
            label5.TabIndex = 30;
            label5.Text = "Stock: ";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(220, 379);
            numPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(240, 39);
            numPrice.TabIndex = 4;
            // 
            // numStock
            // 
            numStock.Location = new Point(220, 308);
            numStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(240, 39);
            numStock.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1233, 662);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 73);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(1042, 662);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(165, 73);
            btnOk.TabIndex = 7;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // numReorderLevel
            // 
            numReorderLevel.Location = new Point(691, 306);
            numReorderLevel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numReorderLevel.Name = "numReorderLevel";
            numReorderLevel.Size = new Size(240, 39);
            numReorderLevel.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(518, 308);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(164, 32);
            label6.TabIndex = 35;
            label6.Text = "Reorder Level:";
            // 
            // numSalePrice
            // 
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Location = new Point(691, 379);
            numSalePrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSalePrice.Name = "numSalePrice";
            numSalePrice.Size = new Size(240, 39);
            numSalePrice.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(544, 379);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(138, 32);
            label7.TabIndex = 37;
            label7.Text = "Sales Price: ";
            // 
            // Suspended
            // 
            Suspended.AutoSize = true;
            Suspended.Location = new Point(63, 484);
            Suspended.Name = "Suspended";
            Suspended.Size = new Size(0, 32);
            Suspended.TabIndex = 39;
            // 
            // checkBoxSuspended
            // 
            checkBoxSuspended.AutoSize = true;
            checkBoxSuspended.Location = new Point(220, 503);
            checkBoxSuspended.Name = "checkBoxSuspended";
            checkBoxSuspended.Size = new Size(165, 36);
            checkBoxSuspended.TabIndex = 40;
            checkBoxSuspended.Text = "Suspended";
            checkBoxSuspended.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            picImage.Location = new Point(38, 38);
            picImage.Name = "picImage";
            picImage.Size = new Size(303, 329);
            picImage.TabIndex = 41;
            picImage.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSearchImages
            // 
            btnSearchImages.Location = new Point(1109, 434);
            btnSearchImages.Name = "btnSearchImages";
            btnSearchImages.Size = new Size(215, 46);
            btnSearchImages.TabIndex = 9;
            btnSearchImages.Text = "Search Images";
            btnSearchImages.UseVisualStyleBackColor = true;
            btnSearchImages.Click += btnSearchImages_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picImage);
            groupBox1.Location = new Point(1022, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(376, 378);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            // 
            // frmProductsAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1505, 781);
            Controls.Add(groupBox1);
            Controls.Add(btnSearchImages);
            Controls.Add(checkBoxSuspended);
            Controls.Add(Suspended);
            Controls.Add(numSalePrice);
            Controls.Add(label7);
            Controls.Add(numReorderLevel);
            Controls.Add(label6);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(numStock);
            Controls.Add(numPrice);
            Controls.Add(label5);
            Controls.Add(txtProductName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cboCategories);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(label1);
            Name = "frmProductsAE";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategories;
        private Label label2;
        private TextBox txtDescription;
        private Label label1;
        private Label label3;
        private TextBox txtProductName;
        private Label label4;
        private Label label5;
        private NumericUpDown numPrice;
        private NumericUpDown numStock;
        private Button btnCancel;
        private Button btnOk;
        private ErrorProvider errorProvider1;
        private NumericUpDown numSalePrice;
        private Label label7;
        private NumericUpDown numReorderLevel;
        private Label label6;
        private CheckBox checkBoxSuspended;
        private Label Suspended;
        private PictureBox picImage;
        private Button btnSearchImages;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox1;
    }
}